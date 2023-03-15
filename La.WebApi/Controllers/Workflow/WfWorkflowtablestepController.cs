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
    /// 审批节点Controller
    /// 
    /// @tableName wf_workflowtablestep
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfWorkflowtablestep")]
    public class WfWorkflowtablestepController : BaseController
    {
        /// <summary>
        /// 审批节点接口
        /// </summary>
        private readonly IWfWorkflowtablestepService _WfWorkflowtablestepService;
        /// <summary>
        /// 审批节点Controller
        /// </summary>
        public WfWorkflowtablestepController(IWfWorkflowtablestepService WfWorkflowtablestepService)
        {
            _WfWorkflowtablestepService = WfWorkflowtablestepService;
        }

        /// <summary>
        /// 查询审批节点列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfworkflowtablestep:list")]
        public IActionResult QueryWfWorkflowtablestep([FromQuery] WfWorkflowtablestepQueryDto parm)
        {
            var response = _WfWorkflowtablestepService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询审批节点详情
        /// </summary>
        /// <param name="SysWorkflowtablestepId"></param>
        /// <returns></returns>
        [HttpGet("{SysWorkflowtablestepId}")]
        [ActionPermissionFilter(Permission = "la:wfworkflowtablestep:query")]
        public IActionResult GetWfWorkflowtablestep(string SysWorkflowtablestepId)
        {
            var response = _WfWorkflowtablestepService.GetFirst(x => x.SysWorkflowtablestepId == SysWorkflowtablestepId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加审批节点
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfworkflowtablestep:add")]
        [Log(Title = "审批节点", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfWorkflowtablestep([FromBody] WfWorkflowtablestepDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfWorkflowtablestepService.CheckEntryStringUnique(parm.SysWorkflowtablestepId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增审批节点 '{parm.SysWorkflowtablestepId}'失败，输入的审批节点已存在"));
            }
            var modal = parm.Adapt<WfWorkflowtablestep>().ToCreate(HttpContext);

            var response = _WfWorkflowtablestepService.AddWfWorkflowtablestep(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新审批节点
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfworkflowtablestep:edit")]
        [Log(Title = "审批节点", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfWorkflowtablestep([FromBody] WfWorkflowtablestepDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfWorkflowtablestep>().ToUpdate(HttpContext);

            var response = _WfWorkflowtablestepService.UpdateWfWorkflowtablestep(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除审批节点
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfworkflowtablestep:delete")]
        [Log(Title = "审批节点", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfWorkflowtablestep(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfWorkflowtablestepService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出审批节点
        /// </summary>
        /// <returns></returns>
        [Log(Title = "审批节点", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfworkflowtablestep:export")]
        public IActionResult Export([FromQuery] WfWorkflowtablestepQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfWorkflowtablestepService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "审批节点", "审批节点");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}