﻿using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;
using La.Model;
using La.Model.System;
using La.Service.System.IService;

namespace La.WebApi.Controllers.monitor
{
    /// <summary>
    /// 系统访问记录
    /// </summary>
    [Verify]
    [Route("/monitor/logininfor")]
    public class SysLogininforController : BaseController
    {
        private ISysLoginService sysLoginService;

        public SysLogininforController(ISysLoginService sysLoginService)
        {
            this.sysLoginService = sysLoginService;
        }

        /// <summary>
        /// 查询登录日志
        /// </summary>
        /// <param name="sysLogininfoDto"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult LoignLogList([FromQuery] SysLogininfor sysLogininfoDto, [FromQuery] PagerInfo pagerInfo)
        {
            var list = sysLoginService.GetLoginLog(sysLogininfoDto, pagerInfo);

            return SUCCESS(list);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        /// <returns></returns>
        [Log(Title = "清空登录日志", BusinessType= BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "monitor:logininfor:remove")]
        [HttpDelete("clean")]
        public IActionResult CleanLoginInfo()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            sysLoginService.TruncateLogininfo();
            return SUCCESS(1);
        }

        /// <summary>
        /// </summary>
        /// <param name="infoIds"></param>
        /// <returns></returns>
        [Log(Title = "删除登录日志", BusinessType = BusinessType.DELETE)]
        [HttpDelete("{infoIds}")]
        [ActionPermissionFilter(Permission = "monitor:logininfor:remove")]
        public IActionResult Remove(string infoIds)
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ApiResult.Error("操作失败"));
            }
            long[] infoIdss = Tools.SpitLongArrary(infoIds);
            return SUCCESS(sysLoginService.DeleteLogininforByIds(infoIdss));
        }

        /// <summary>
        /// 登录日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "登录日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "monitor:logininfor:export")]
        public IActionResult Export([FromQuery] SysLogininfor logininfoDto)
        {
            logininfoDto.BeginTime = DateTimeHelper.GetBeginTime(logininfoDto.BeginTime, -1);
            logininfoDto.EndTime = DateTimeHelper.GetBeginTime(logininfoDto.EndTime, 1);
            var exp = Expressionable.Create<SysLogininfor>()
                .And(it => it.LoginTime >= logininfoDto.BeginTime && it.LoginTime <= logininfoDto.EndTime);

            var list = sysLoginService.Queryable().Where(exp.ToExpression())
                .ToList();

            string sFileName = ExportExcel(list, "loginlog", "登录日志");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }
    }
}
