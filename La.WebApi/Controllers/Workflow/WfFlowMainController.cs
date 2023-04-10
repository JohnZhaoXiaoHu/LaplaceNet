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
    /// OA流程实例表Controller
    /// 
    /// @tableName wf_flow_main
    /// @author Davis.Cheng
    /// @date 2023-03-17
    /// </summary>
    [Verify]
    [Route("workflow/WfFlowMain")]
    public class WfFlowMainController : BaseController
    {
        /// <summary>
        /// OA流程实例表接口
        /// </summary>
        private readonly IWfFlowMainService _WfFlowMainService;
        /// <summary>
        /// OA流程实例表Controller
        /// </summary>
        public WfFlowMainController(IWfFlowMainService WfFlowMainService)
        {
            _WfFlowMainService = WfFlowMainService;
        }

        /// <summary>
        /// 查询OA流程实例表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfflowmain:list")]
        public IActionResult QueryWfFlowMain([FromQuery] WfFlowMainQueryDto parm)
        {
            var response = _WfFlowMainService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询OA流程实例表详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "la:wfflowmain:query")]
        public IActionResult GetWfFlowMain(string Id)
        {
            var response = _WfFlowMainService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加OA流程实例表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfflowmain:add")]
        [Log(Title = "OA流程实例表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfFlowMain([FromBody] WfFlowMainDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFlowMainService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增OA流程实例表 '{parm.Id}'失败，输入的OA流程实例表已存在"));
            }
            var modal = parm.Adapt<WfFlowMain>().ToCreate(HttpContext);

            var response = _WfFlowMainService.AddWfFlowMain(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新OA流程实例表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfflowmain:edit")]
        [Log(Title = "OA流程实例表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfFlowMain([FromBody] WfFlowMainDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfFlowMain>().ToUpdate(HttpContext);

            var response = _WfFlowMainService.UpdateWfFlowMain(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除OA流程实例表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfflowmain:delete")]
        [Log(Title = "OA流程实例表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfFlowMain(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFlowMainService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出OA流程实例表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OA流程实例表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfflowmain:export")]
        public IActionResult Export([FromQuery] WfFlowMainQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfFlowMainService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "OA流程实例表", "OA流程实例表");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}