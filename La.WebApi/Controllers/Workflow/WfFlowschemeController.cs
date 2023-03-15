using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.System;
using La.Service.Workflow.IWorkflowService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;
using La.Model.Models.Workflow.Flowscheme;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 流程Controller
    /// 
    /// @tableName wf_flowscheme
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfFlowscheme")]
    public class WfFlowschemeController : BaseController
    {
        /// <summary>
        /// 流程接口
        /// </summary>
        private readonly IWfFlowschemeService _WfFlowschemeService;
        /// <summary>
        /// 流程Controller
        /// </summary>
        public WfFlowschemeController(IWfFlowschemeService WfFlowschemeService)
        {
            _WfFlowschemeService = WfFlowschemeService;
        }

        /// <summary>
        /// 查询流程列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "wf:flowscheme:list")]
        public IActionResult QueryWfFlowscheme([FromQuery] WfFlowschemeQueryDto parm)
        {
            var response = _WfFlowschemeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询流程详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "wf:flowscheme:query")]
        public IActionResult GetWfFlowscheme(long Id)
        {
            var response = _WfFlowschemeService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加流程
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "wf:flowscheme:add")]
        [Log(Title = "流程", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfFlowscheme([FromBody] WfFlowschemeDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFlowschemeService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增流程 '{parm.Id}'失败，输入的流程已存在"));
            }
            var modal = parm.Adapt<WfFlowscheme>().ToCreate(HttpContext);

            var response = _WfFlowschemeService.AddWfFlowscheme(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新流程
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "wf:flowscheme:edit")]
        [Log(Title = "流程", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfFlowscheme([FromBody] WfFlowschemeDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfFlowscheme>().ToUpdate(HttpContext);

            var response = _WfFlowschemeService.UpdateWfFlowscheme(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除流程
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "wf:flowscheme:delete")]
        [Log(Title = "流程", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfFlowscheme(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFlowschemeService.Delete(idsArr);

            return ToResponse(response);
        }



    }
}