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
    /// 流程使用记录Controller
    /// 
    /// @tableName wf_flow_rece
    /// @author Davis.Cheng
    /// @date 2023-04-10
    /// </summary>
    [Verify]
    [Route("workflow/WfFlowRece")]
    public class WfFlowReceController : BaseController
    {
        /// <summary>
        /// 流程使用记录接口
        /// </summary>
        private readonly IWfFlowReceService _WfFlowReceService;
        /// <summary>
        /// 流程使用记录Controller
        /// </summary>
        public WfFlowReceController(IWfFlowReceService WfFlowReceService)
        {
            _WfFlowReceService = WfFlowReceService;
        }

        /// <summary>
        /// 查询流程使用记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfflowrece:list")]
        public IActionResult QueryWfFlowRece([FromQuery] WfFlowReceQueryDto parm)
        {
            var response = _WfFlowReceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询流程使用记录详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "la:wfflowrece:query")]
        public IActionResult GetWfFlowRece(string Id)
        {
            var response = _WfFlowReceService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加流程使用记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfflowrece:add")]
        [Log(Title = "流程使用记录", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfFlowRece([FromBody] WfFlowReceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFlowReceService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增流程使用记录 '{parm.Id}'失败，输入的流程使用记录已存在"));
            }
            var modal = parm.Adapt<WfFlowRece>().ToCreate(HttpContext);

            var response = _WfFlowReceService.AddWfFlowRece(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新流程使用记录
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfflowrece:edit")]
        [Log(Title = "流程使用记录", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfFlowRece([FromBody] WfFlowReceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfFlowRece>().ToUpdate(HttpContext);

            var response = _WfFlowReceService.UpdateWfFlowRece(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除流程使用记录
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfflowrece:delete")]
        [Log(Title = "流程使用记录", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfFlowRece(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFlowReceService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出流程使用记录
        /// </summary>
        /// <returns></returns>
        [Log(Title = "流程使用记录", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfflowrece:export")]
        public IActionResult Export([FromQuery] WfFlowReceQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfFlowReceService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "流程使用记录", "流程使用记录");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}