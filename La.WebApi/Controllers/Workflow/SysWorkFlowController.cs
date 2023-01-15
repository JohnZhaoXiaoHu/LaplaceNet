using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.Workflow.IWorkflowService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 工作流Controller
    /// 
    /// @tableName Sys_WorkFlow
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-15
    /// </summary>
    [Verify]
    [Route("workflow/SysWorkFlow")]
    public class SysWorkFlowController : BaseController
    {
        /// <summary>
        /// 工作流接口
        /// </summary>
        private readonly ISysWorkFlowService _SysWorkFlowService;

        public SysWorkFlowController(ISysWorkFlowService SysWorkFlowService)
        {
            _SysWorkFlowService = SysWorkFlowService;
        }

        /// <summary>
        /// 查询工作流列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sys:workflow:list")]
        public IActionResult QuerySysWorkFlow([FromQuery] SysWorkFlowQueryDto parm)
        {
            var response = _SysWorkFlowService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工作流详情
        /// </summary>
        /// <param name="WorkflowId"></param>
        /// <returns></returns>
        [HttpGet("{WorkflowId}")]
        [ActionPermissionFilter(Permission = "sys:workflow:query")]
        public IActionResult GetSysWorkFlow(Guid WorkflowId)
        {
            var response = _SysWorkFlowService.GetFirst(x => x.WorkflowId == WorkflowId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加工作流
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sys:workflow:add")]
        [Log(Title = "工作流", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSysWorkFlow([FromBody] SysWorkFlowDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
            if (UserConstants.NOT_UNIQUE.Equals(_SysWorkFlowService.CheckEntryStringUnique(parm.WorkflowId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增工作流 '{parm.WorkflowId}'失败，输入的工作流已存在"));
            }
            var modal = parm.Adapt<SysWorkFlow>().ToCreate(HttpContext);

            var response = _SysWorkFlowService.AddSysWorkFlow(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新工作流
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sys:workflow:edit")]
        [Log(Title = "工作流", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSysWorkFlow([FromBody] SysWorkFlowDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<SysWorkFlow>().ToUpdate(HttpContext);

            var response = _SysWorkFlowService.UpdateSysWorkFlow(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工作流
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sys:workflow:delete")]
        [Log(Title = "工作流", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysWorkFlow(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysWorkFlowService.Delete(idsArr);

            return ToResponse(response);
        }



    }
}