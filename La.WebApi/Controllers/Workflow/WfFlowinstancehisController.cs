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
    /// 工作流实例流转历史记录Controller
    /// 
    /// @tableName wf_flowinstancehis
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfFlowinstancehis")]
    public class WfFlowinstancehisController : BaseController
    {
        /// <summary>
        /// 工作流实例流转历史记录接口
        /// </summary>
        private readonly IWfFlowinstancehisService _WfFlowinstancehisService;
        /// <summary>
        /// 工作流实例流转历史记录Controller
        /// </summary>
        public WfFlowinstancehisController(IWfFlowinstancehisService WfFlowinstancehisService)
        {
            _WfFlowinstancehisService = WfFlowinstancehisService;
        }

        /// <summary>
        /// 查询工作流实例流转历史记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "wf:flowinstancehis:list")]
        public IActionResult QueryWfFlowinstancehis([FromQuery] WfFlowinstancehisQueryDto parm)
        {
            var response = _WfFlowinstancehisService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工作流实例流转历史记录详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "wf:flowinstancehis:query")]
        public IActionResult GetWfFlowinstancehis(long Id)
        {
            var response = _WfFlowinstancehisService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加工作流实例流转历史记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "wf:flowinstancehis:add")]
        [Log(Title = "工作流实例流转历史记录", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfFlowinstancehis([FromBody] WfFlowinstancehisDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFlowinstancehisService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增工作流实例流转历史记录 '{parm.Id}'失败，输入的工作流实例流转历史记录已存在"));
            }
            var modal = parm.Adapt<WfFlowinstancehis>().ToCreate(HttpContext);

            var response = _WfFlowinstancehisService.AddWfFlowinstancehis(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新工作流实例流转历史记录
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "wf:flowinstancehis:edit")]
        [Log(Title = "工作流实例流转历史记录", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfFlowinstancehis([FromBody] WfFlowinstancehisDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfFlowinstancehis>().ToUpdate(HttpContext);

            var response = _WfFlowinstancehisService.UpdateWfFlowinstancehis(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工作流实例流转历史记录
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "wf:flowinstancehis:delete")]
        [Log(Title = "工作流实例流转历史记录", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfFlowinstancehis(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFlowinstancehisService.Delete(idsArr);

            return ToResponse(response);
        }



    }
}