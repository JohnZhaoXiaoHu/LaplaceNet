using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using La.WebApi.Filters;
using La.WebApi.Hubs;
using La.Model;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra;
using La.Service.System;
using La.WebApi.Extensions;

namespace La.WebApi.Controllers.monitor
{
    [Verify]
    [Route("monitor/online")]
    public class SysUserOnlineController : BaseController
    {
        private ILogger<SysUserOnlineController> _logger;
        private IHubContext<Hub> HubContext;

        /// <summary>
        /// 在线日志
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="hub"></param>
        public SysUserOnlineController(ILogger<SysUserOnlineController> logger, IHubContext<MessageHub> hub)
        {
            _logger = logger;
            HubContext = hub;
        }
        //public SysUserOnlineController(IHubContext<Hub> hubContext)
        //{
        //    HubContext = hubContext;
        //}

        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult Index([FromQuery] PagerInfo parm)
        {
            var result = MessageHub.clientUsers
                .OrderByDescending(f => f.LoginTime)
                .Skip(parm.PageNum - 1).Take(parm.PageSize);

            return SUCCESS(new { result, totalNum = MessageHub.clientUsers.Count });
        }
        /// <summary>
        /// 强制退出用户
        /// </summary>
        /// <param name="connnectionId"></param>
        /// <returns></returns>
        //[HttpDelete]
        //[Route("{connnectionId}")]
        [HttpDelete("{connnectionId}")]
        [ActionPermissionFilter(Permission = "monitor:online:forceLogout")]
        [Log(Title = "在线用户", BusinessType = BusinessType.FORCE)]
        public async Task<IActionResult> forceOut(string connnectionId)
        {
            if (MessageHub.clientUsers.Exists(u => u.ConnnectionId == connnectionId))
            {
                //前端接受到这个事件后，触发前端自动退出
                await HubContext.Clients.Client(connnectionId).SendAsync(HubTypeEnum.forceOut.ToString(), "你已被强制退出！");
                return SUCCESS("你已被强制退出！");
            }
            return SUCCESS("操作失败！未发现该连接！");
        }

    }
}
