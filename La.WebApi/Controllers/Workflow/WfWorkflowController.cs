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
    /// 审批流程Controller
    /// 
    /// @tableName wf_workflow
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfWorkflow")]
    public class WfWorkflowController : BaseController
    {
        /// <summary>
        /// 审批流程接口
        /// </summary>
        private readonly IWfWorkflowService _WfWorkflowService;
        /// <summary>
        /// 审批流程Controller
        /// </summary>
        public WfWorkflowController(IWfWorkflowService WfWorkflowService)
        {
            _WfWorkflowService = WfWorkflowService;
        }

        /// <summary>
        /// 查询审批流程列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfworkflow:list")]
        public IActionResult QueryWfWorkflow([FromQuery] WfWorkflowQueryDto parm)
        {
            var response = _WfWorkflowService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询审批流程详情
        /// </summary>
        /// <param name="WorkflowId"></param>
        /// <returns></returns>
        [HttpGet("{WorkflowId}")]
        [ActionPermissionFilter(Permission = "la:wfworkflow:query")]
        public IActionResult GetWfWorkflow(string WorkflowId)
        {
            var response = _WfWorkflowService.GetFirst(x => x.WorkflowId == WorkflowId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加审批流程
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfworkflow:add")]
        [Log(Title = "审批流程", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfWorkflow([FromBody] WfWorkflowDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfWorkflowService.CheckEntryStringUnique(parm.WorkflowId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增审批流程 '{parm.WorkflowId}'失败，输入的审批流程已存在"));
            }
            var modal = parm.Adapt<WfWorkflow>().ToCreate(HttpContext);

            var response = _WfWorkflowService.AddWfWorkflow(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新审批流程
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfworkflow:edit")]
        [Log(Title = "审批流程", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfWorkflow([FromBody] WfWorkflowDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfWorkflow>().ToUpdate(HttpContext);

            var response = _WfWorkflowService.UpdateWfWorkflow(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除审批流程
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfworkflow:delete")]
        [Log(Title = "审批流程", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfWorkflow(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfWorkflowService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出审批流程
        /// </summary>
        /// <returns></returns>
        [Log(Title = "审批流程", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfworkflow:export")]
        public IActionResult Export([FromQuery] WfWorkflowQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfWorkflowService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "审批流程", "审批流程");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}