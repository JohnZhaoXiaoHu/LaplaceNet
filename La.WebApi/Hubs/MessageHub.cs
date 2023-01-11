using La.Infra;
using La.Infra.Constant;
using La.Infra.Model;
using IPTools.Core;
using Microsoft.AspNetCore.SignalR;
using La.WebApi.Extensions;
using La.WebApi.Framework;
using La.Model;
using La.Model.System;
using La.Service.System.IService;
using UAParser;
using JinianNet.JNTemplate;
using La.Infra.Enums;

namespace La.WebApi.Hubs
{
    public class MessageHub : Hub
    {
        //创建用户集合，用于存储所有链接的用户数据
        public static readonly List<OnlineUsers> clientUsers = new();
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly ISysNoticeService SysNoticeService;

        public MessageHub(ISysNoticeService noticeService)
        {
            SysNoticeService = noticeService;
        }

        private ApiResult SendNotice()
        {
            var result = SysNoticeService.GetSysNotices();

            return new ApiResult(200, "success", result);
        }

        #region 客户端连接

        /// <summary>
        /// 客户端连接的时候调用
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            var name = HttpContextExtension.GetName(App.HttpContext);// Context.User.Identity.Name;
            var ip = HttpContextExtension.GetClientUserIp(App.HttpContext);
            var ip_info = IpTool.Search(ip);
            ClientInfo clientInfo = HttpContextExtension.GetClientInfo(App.HttpContext);
            LoginUser loginUser = JwtUtil.GetLoginUser(App.HttpContext);
            var user = clientUsers.Any(u => u.ConnnectionId == Context.ConnectionId);
            //判断用户是否存在，否则添加集合
            if (!user && Context.User!.Identity!.IsAuthenticated)
            {
                OnlineUsers users = new(Context.ConnectionId)
                {
                    //地点
                    LoginLocation = ip_info.City ?? "",
                    //系统
                    Os = clientInfo.OS.ToString() ?? "",
                    //浏览器
                    Browser = clientInfo.UserAgent.ToString() ?? "",
                    //ip
                    Ipaddr = ip ?? "",
                    //时间
                    LoginTime = DateTime.Now,
                    //用户
                    UserName = loginUser.UserName ?? "",
                    //ID
                    UserId= loginUser.UserId,
                };
                clientUsers.Add(users);
                Console.WriteLine($"{DateTime.Now}：{name},{Context.ConnectionId}连接服务端success，当前已连接{clientUsers.Count}个");
                //Clients.All.SendAsync("welcome", $"欢迎您：{name},当前时间：{DateTime.Now}");
                Clients.All.SendAsync(HubsConstant.MoreNotice, SendNotice());
            }

            Clients.All.SendAsync(HubsConstant.OnlineNum, clientUsers.Count);
            Clients.All.SendAsync(HubsConstant.OnlineUser, clientUsers);
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// 连接终止时调用。
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var user = clientUsers.Where(p => p.ConnnectionId == Context.ConnectionId).FirstOrDefault();
            //判断用户是否存在，否则添加集合
            if (user != null)
            {
                clientUsers.Remove(user);
                Clients.All.SendAsync(HubsConstant.OnlineNum, clientUsers.Count);
                Clients.All.SendAsync(HubsConstant.OnlineUser, clientUsers);
                Console.WriteLine($"用户{user?.UserName}离开了，当前已连接{clientUsers.Count}个");
            }
            return base.OnDisconnectedAsync(exception);
        }

        #endregion


        /// <summary>
        /// 注册信息
        /// </summary>
        /// <param name="connectId"></param>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HubMethodName("SendMessage")]
        public async Task SendMessage(string connectId, string userName, string message)
        {
            Console.WriteLine($"{connectId},message={message}");
            
            await Clients.Client(connectId).SendAsync("receiveChat", new { userName, message });
        }
    }
}
