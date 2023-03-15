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
    /// @tableName wf_workflowtable
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfWorkflowtable")]
    public class WfWorkflowtableController : BaseController
    {
        /// <summary>
        /// 审批流程接口
        /// </summary>
        private readonly IWfWorkflowtableService _WfWorkflowtableService;
        /// <summary>
        /// 审批流程Controller
        /// </summary>
        public WfWorkflowtableController(IWfWorkflowtableService WfWorkflowtableService)
        {
            _WfWorkflowtableService = WfWorkflowtableService;
        }

        /// <summary>
        /// 查询审批流程列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfworkflowtable:list")]
        public IActionResult QueryWfWorkflowtable([FromQuery] WfWorkflowtableQueryDto parm)
        {
            var response = _WfWorkflowtableService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询审批流程详情
        /// </summary>
        /// <param name="WorkflowtableId"></param>
        /// <returns></returns>
        [HttpGet("{WorkflowtableId}")]
        [ActionPermissionFilter(Permission = "la:wfworkflowtable:query")]
        public IActionResult GetWfWorkflowtable(string WorkflowtableId)
        {
            var response = _WfWorkflowtableService.GetFirst(x => x.WorkflowtableId == WorkflowtableId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加审批流程
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfworkflowtable:add")]
        [Log(Title = "审批流程", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfWorkflowtable([FromBody] WfWorkflowtableDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfWorkflowtableService.CheckEntryStringUnique(parm.WorkflowtableId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增审批流程 '{parm.WorkflowtableId}'失败，输入的审批流程已存在"));
            }
            var modal = parm.Adapt<WfWorkflowtable>().ToCreate(HttpContext);

            var response = _WfWorkflowtableService.AddWfWorkflowtable(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新审批流程
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfworkflowtable:edit")]
        [Log(Title = "审批流程", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfWorkflowtable([FromBody] WfWorkflowtableDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfWorkflowtable>().ToUpdate(HttpContext);

            var response = _WfWorkflowtableService.UpdateWfWorkflowtable(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除审批流程
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfworkflowtable:delete")]
        [Log(Title = "审批流程", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfWorkflowtable(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfWorkflowtableService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出审批流程
        /// </summary>
        /// <returns></returns>
        [Log(Title = "审批流程", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfworkflowtable:export")]
        public IActionResult Export([FromQuery] WfWorkflowtableQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfWorkflowtableService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "审批流程", "审批流程");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}