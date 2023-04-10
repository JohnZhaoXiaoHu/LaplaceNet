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
    /// OA流程分类表Controller
    /// 
    /// @tableName wf_flow_cate
    /// @author Davis.Cheng
    /// @date 2023-03-17
    /// </summary>
    [Verify]
    [Route("workflow/WfFlowCate")]
    public class WfFlowCateController : BaseController
    {
        /// <summary>
        /// OA流程分类表接口
        /// </summary>
        private readonly IWfFlowCateService _WfFlowCateService;
        /// <summary>
        /// OA流程分类表Controller
        /// </summary>
        public WfFlowCateController(IWfFlowCateService WfFlowCateService)
        {
            _WfFlowCateService = WfFlowCateService;
        }

        /// <summary>
        /// 查询OA流程分类表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfflowcate:list")]
        public IActionResult QueryWfFlowCate([FromQuery] WfFlowCateQueryDto parm)
        {
            var response = _WfFlowCateService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询OA流程分类表详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "la:wfflowcate:query")]
        public IActionResult GetWfFlowCate(string Id)
        {
            var response = _WfFlowCateService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加OA流程分类表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfflowcate:add")]
        [Log(Title = "OA流程分类表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfFlowCate([FromBody] WfFlowCateDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFlowCateService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增OA流程分类表 '{parm.Id}'失败，输入的OA流程分类表已存在"));
            }
            var modal = parm.Adapt<WfFlowCate>().ToCreate(HttpContext);

            var response = _WfFlowCateService.AddWfFlowCate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新OA流程分类表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfflowcate:edit")]
        [Log(Title = "OA流程分类表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfFlowCate([FromBody] WfFlowCateDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfFlowCate>().ToUpdate(HttpContext);

            var response = _WfFlowCateService.UpdateWfFlowCate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除OA流程分类表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfflowcate:delete")]
        [Log(Title = "OA流程分类表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfFlowCate(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFlowCateService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出OA流程分类表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OA流程分类表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfflowcate:export")]
        public IActionResult Export([FromQuery] WfFlowCateQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfFlowCateService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "OA流程分类表", "OA流程分类表");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}