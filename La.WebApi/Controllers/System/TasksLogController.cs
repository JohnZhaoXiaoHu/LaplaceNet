﻿using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Extensions;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using La.WebApi.Filters;
using La.Common;
using La.Model;
using La.Model.System;
using La.Model.System.Dto;
using La.Service.System.IService;

namespace La.WebApi.Controllers.System
{
    /// <summary>
    /// 任务日志
    /// </summary>
    [Verify]
    [Route("/monitor/jobLog")]
    public class TasksLogController : BaseController
    {
        private readonly ISysTasksLogService tasksLogService;

        public TasksLogController(ISysTasksLogService tasksLogService)
        {
            this.tasksLogService = tasksLogService;
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="queryDto"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult GetList([FromQuery] PagerInfo pager, [FromQuery] TasksLogQueryDto queryDto)
        {
            queryDto.BeginTime = DateTimeHelper.GetBeginTime(queryDto.BeginTime, -7);
            queryDto.EndTime = DateTimeHelper.GetBeginTime(queryDto.EndTime, 7);

            var predicate = Expressionable.Create<SysTasksLog>().And(it => it.CreateTime >= queryDto.BeginTime && it.CreateTime <= queryDto.EndTime);
            predicate = predicate.AndIF(queryDto.JobName.IfNotEmpty(), m => m.JobName.Contains(queryDto.JobName));
            predicate = predicate.AndIF(queryDto.JobGroup.IfNotEmpty(), m => m.JobGroup == queryDto.JobGroup);
            predicate = predicate.AndIF(queryDto.Status.IfNotEmpty(), m => m.Status == queryDto.Status);
            predicate = predicate.AndIF(queryDto.JobId.IfNotEmpty(), m => m.JobId == queryDto.JobId);

            var response = tasksLogService.GetPages(predicate.ToExpression(), pager, m => m.CreateTime, OrderByType.Desc);

            return SUCCESS(response, TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 删除定时任务调用日志
        /// </summary>
        /// <param name="jobIds"></param>
        /// <returns></returns>
        [HttpDelete("{jobIds}")]
        [ActionPermissionFilter(Permission = "PRIV_JOBLOG_DELETE")]
        [Log(Title = "删除任务日志", BusinessType = BusinessType.DELETE)]
        public IActionResult Delete(string jobIds)
        {
            long[] jobIdArr = Tools.SpitLongArrary(jobIds);

            int result = tasksLogService.Delete(jobIdArr);

            return ToResponse(ToJson(result, result));
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <returns></returns>
        [HttpDelete("clean")]
        [ActionPermissionFilter(Permission = "PRIV_JOBLOG_REMOVE")]
        [Log(Title = "清空任务日志", BusinessType = BusinessType.CLEAN)]
        public IActionResult Clean()
        {
            tasksLogService.DeleteTable();
            return SUCCESS(1);
        }

        /// <summary>
        /// 定时任务日志导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "定时任务日志导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "PRIV_JOBLOG_EXPORT")]
        public IActionResult Export()
        {
            var list = tasksLogService.GetAll();

            string sFileName = ExportExcel(list, "jobLog", "定时任务日志");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }
    }
}
