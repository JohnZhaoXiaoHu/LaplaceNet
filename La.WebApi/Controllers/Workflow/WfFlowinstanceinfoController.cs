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
    /// 工作流实例操作记录Controller
    /// 
    /// @tableName wf_flowinstanceinfo
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfFlowinstanceinfo")]
    public class WfFlowinstanceinfoController : BaseController
    {
        /// <summary>
        /// 工作流实例操作记录接口
        /// </summary>
        private readonly IWfFlowinstanceinfoService _WfFlowinstanceinfoService;
        /// <summary>
        /// 工作流实例操作记录Controller
        /// </summary>
        public WfFlowinstanceinfoController(IWfFlowinstanceinfoService WfFlowinstanceinfoService)
        {
            _WfFlowinstanceinfoService = WfFlowinstanceinfoService;
        }

        /// <summary>
        /// 查询工作流实例操作记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "wf:flowinstanceinfo:list")]
        public IActionResult QueryWfFlowinstanceinfo([FromQuery] WfFlowinstanceinfoQueryDto parm)
        {
            var response = _WfFlowinstanceinfoService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工作流实例操作记录详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "wf:flowinstanceinfo:query")]
        public IActionResult GetWfFlowinstanceinfo(long Id)
        {
            var response = _WfFlowinstanceinfoService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加工作流实例操作记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "wf:flowinstanceinfo:add")]
        [Log(Title = "工作流实例操作记录", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfFlowinstanceinfo([FromBody] WfFlowinstanceinfoDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFlowinstanceinfoService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增工作流实例操作记录 '{parm.Id}'失败，输入的工作流实例操作记录已存在"));
            }
            var modal = parm.Adapt<WfFlowinstanceinfo>().ToCreate(HttpContext);

            var response = _WfFlowinstanceinfoService.AddWfFlowinstanceinfo(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新工作流实例操作记录
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "wf:flowinstanceinfo:edit")]
        [Log(Title = "工作流实例操作记录", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfFlowinstanceinfo([FromBody] WfFlowinstanceinfoDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfFlowinstanceinfo>().ToUpdate(HttpContext);

            var response = _WfFlowinstanceinfoService.UpdateWfFlowinstanceinfo(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工作流实例操作记录
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "wf:flowinstanceinfo:delete")]
        [Log(Title = "工作流实例操作记录", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfFlowinstanceinfo(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFlowinstanceinfoService.Delete(idsArr);

            return ToResponse(response);
        }



    }
}