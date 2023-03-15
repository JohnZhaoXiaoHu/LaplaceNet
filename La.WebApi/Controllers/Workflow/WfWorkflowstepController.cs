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
    /// 审批节点配置Controller
    /// 
    /// @tableName wf_workflowstep
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfWorkflowstep")]
    public class WfWorkflowstepController : BaseController
    {
        /// <summary>
        /// 审批节点配置接口
        /// </summary>
        private readonly IWfWorkflowstepService _WfWorkflowstepService;
        /// <summary>
        /// 审批节点配置Controller
        /// </summary>
        public WfWorkflowstepController(IWfWorkflowstepService WfWorkflowstepService)
        {
            _WfWorkflowstepService = WfWorkflowstepService;
        }

        /// <summary>
        /// 查询审批节点配置列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfworkflowstep:list")]
        public IActionResult QueryWfWorkflowstep([FromQuery] WfWorkflowstepQueryDto parm)
        {
            var response = _WfWorkflowstepService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询审批节点配置详情
        /// </summary>
        /// <param name="WorkstepflowId"></param>
        /// <returns></returns>
        [HttpGet("{WorkstepflowId}")]
        [ActionPermissionFilter(Permission = "la:wfworkflowstep:query")]
        public IActionResult GetWfWorkflowstep(string WorkstepflowId)
        {
            var response = _WfWorkflowstepService.GetFirst(x => x.WorkstepflowId == WorkstepflowId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加审批节点配置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfworkflowstep:add")]
        [Log(Title = "审批节点配置", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfWorkflowstep([FromBody] WfWorkflowstepDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfWorkflowstepService.CheckEntryStringUnique(parm.WorkstepflowId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增审批节点配置 '{parm.WorkstepflowId}'失败，输入的审批节点配置已存在"));
            }
            var modal = parm.Adapt<WfWorkflowstep>().ToCreate(HttpContext);

            var response = _WfWorkflowstepService.AddWfWorkflowstep(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新审批节点配置
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfworkflowstep:edit")]
        [Log(Title = "审批节点配置", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfWorkflowstep([FromBody] WfWorkflowstepDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfWorkflowstep>().ToUpdate(HttpContext);

            var response = _WfWorkflowstepService.UpdateWfWorkflowstep(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除审批节点配置
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfworkflowstep:delete")]
        [Log(Title = "审批节点配置", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfWorkflowstep(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfWorkflowstepService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出审批节点配置
        /// </summary>
        /// <returns></returns>
        [Log(Title = "审批节点配置", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfworkflowstep:export")]
        public IActionResult Export([FromQuery] WfWorkflowstepQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfWorkflowstepService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "审批节点配置", "审批节点配置");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}