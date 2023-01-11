﻿using Microsoft.AspNetCore.Mvc;
using La.WebApi.Filters;
using La.Model.Dto;
using La.WebApi.Hubs;
//using MySqlX.XDevAPI.Common;
using Microsoft.AspNetCore.SignalR;
using La.Model;
using La.Model.System;
using System.Collections.Generic;
using La.Infra.Enums;
using La.Model.System.Dto;
using La.Service.System;
using La.Service.System.IService;
using La.Infra.Attribute;

namespace La.WebApi.Controllers.monitor
{
    /// <summary>
    /// 在线管理
    /// </summary>

    [Verify]
    [Route("monitor/online")]
    //[ApiController]

    public class SysUserOnlineController : BaseController
    {
        private ILogger<SysUserOnlineController> _logger;
        private IHubContext<MessageHub> _hub;
        public SysUserOnlineController(ILogger<SysUserOnlineController> logger, IHubContext<MessageHub> hub)
        {
            _logger = logger;
            _hub = hub;
        }
        /// <summary>
        /// 动态条件获取当前在线用户
        /// </summary>
        /// <param name="online"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "monitor:online:list")]
        public Result PageList([FromQuery] OnlineUsers online)
        {
            var data = MessageHub.clientUsers;
            IEnumerable<OnlineUsers> dataWhere = data.AsEnumerable();

            if (!string.IsNullOrEmpty(online.Ipaddr))
            {
                dataWhere = dataWhere.Where((u) => u.Ipaddr!.Contains(online.Ipaddr!));
            }
            if (!string.IsNullOrEmpty(online.UserName))
            {
                dataWhere = dataWhere.Where((u) => u.UserName!.Contains(online.UserName!));
            }

            return Result.Success().SetData(new PageModel<List<OnlineUsers>>() { Total = data.Count, Data =dataWhere.ToList() });
        }

        //public IActionResult PageList([FromQuery] OnlineUsers online, [FromQuery] PagerInfo pagerInfo)
        //{
        //    var data = MessageHub.clientUsers;
        //    //var list = sysLoginService.GetLoginLog(SysUserOnlineDto, pagerInfo);

        //    return SUCCESS(data, TIME_FORMAT_FULL);
        //}
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
        public async Task<Result> forceLogout(string connnectionId)
        {
            if (MessageHub.clientUsers.Exists(u => u.ConnnectionId == connnectionId))
            {
                //前端接受到这个事件后，触发前端自动退出
                await _hub.Clients.Client(connnectionId).SendAsync(HubTypeEnum.forceOut.ToString(), "你已被强制退出！");
                return Result.Success();
            }
            return Result.Error("操作失败！未发现该连接！");
        }

    }

}