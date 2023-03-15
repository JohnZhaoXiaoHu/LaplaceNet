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
using La.Model.Models.Workflow.Flowinstance;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 流程实例模板Controller
    /// 
    /// @tableName wf_flowinstance
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfFlowinstance")]
    public class WfFlowinstanceController : BaseController
    {
        /// <summary>
        /// 流程实例模板接口
        /// </summary>
        private readonly IWfFlowinstanceService _WfFlowinstanceService;
        /// <summary>
        /// 流程实例模板Controller
        /// </summary>
        public WfFlowinstanceController(IWfFlowinstanceService WfFlowinstanceService)
        {
            _WfFlowinstanceService = WfFlowinstanceService;
        }

        /// <summary>
        /// 查询流程实例模板列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfflowinstance:list")]
        public IActionResult QueryWfFlowinstance([FromQuery] WfFlowinstanceQueryDto parm)
        {
            var response = _WfFlowinstanceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询流程实例模板详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "la:wfflowinstance:query")]
        public IActionResult GetWfFlowinstance(long Id)
        {
            var response = _WfFlowinstanceService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加流程实例模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfflowinstance:add")]
        [Log(Title = "流程实例模板", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfFlowinstance([FromBody] WfFlowinstanceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFlowinstanceService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增流程实例模板 '{parm.Id}'失败，输入的流程实例模板已存在"));
            }
            var modal = parm.Adapt<WfFlowinstance>().ToCreate(HttpContext);

            var response = _WfFlowinstanceService.AddWfFlowinstance(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新流程实例模板
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfflowinstance:edit")]
        [Log(Title = "流程实例模板", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfFlowinstance([FromBody] WfFlowinstanceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfFlowinstance>().ToUpdate(HttpContext);

            var response = _WfFlowinstanceService.UpdateWfFlowinstance(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除流程实例模板
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfflowinstance:delete")]
        [Log(Title = "流程实例模板", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfFlowinstance(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFlowinstanceService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出流程实例模板
        /// </summary>
        /// <returns></returns>
        [Log(Title = "流程实例模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfflowinstance:export")]
        public IActionResult Export([FromQuery] WfFlowinstanceQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfFlowinstanceService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "流程实例模板", "流程实例模板");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}