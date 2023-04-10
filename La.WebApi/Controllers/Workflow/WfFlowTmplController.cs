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
    /// OA流程模板表Controller
    /// 
    /// @tableName wf_flow_tmpl
    /// @author Davis.Cheng
    /// @date 2023-03-17
    /// </summary>
    [Verify]
    [Route("workflow/WfFlowTmpl")]
    public class WfFlowTmplController : BaseController
    {
        /// <summary>
        /// OA流程模板表接口
        /// </summary>
        private readonly IWfFlowTmplService _WfFlowTmplService;
        /// <summary>
        /// OA流程模板表Controller
        /// </summary>
        public WfFlowTmplController(IWfFlowTmplService WfFlowTmplService)
        {
            _WfFlowTmplService = WfFlowTmplService;
        }

        /// <summary>
        /// 查询OA流程模板表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:wfflowtmpl:list")]
        public IActionResult QueryWfFlowTmpl([FromQuery] WfFlowTmplQueryDto parm)
        {
            var response = _WfFlowTmplService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询OA流程模板表详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "la:wfflowtmpl:query")]
        public IActionResult GetWfFlowTmpl(string Id)
        {
            var response = _WfFlowTmplService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加OA流程模板表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:wfflowtmpl:add")]
        [Log(Title = "OA流程模板表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfFlowTmpl([FromBody] WfFlowTmplDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFlowTmplService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增OA流程模板表 '{parm.Id}'失败，输入的OA流程模板表已存在"));
            }
            var modal = parm.Adapt<WfFlowTmpl>().ToCreate(HttpContext);

            var response = _WfFlowTmplService.AddWfFlowTmpl(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新OA流程模板表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:wfflowtmpl:edit")]
        [Log(Title = "OA流程模板表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfFlowTmpl([FromBody] WfFlowTmplDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfFlowTmpl>().ToUpdate(HttpContext);

            var response = _WfFlowTmplService.UpdateWfFlowTmpl(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除OA流程模板表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:wfflowtmpl:delete")]
        [Log(Title = "OA流程模板表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfFlowTmpl(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFlowTmplService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出OA流程模板表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "OA流程模板表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:wfflowtmpl:export")]
        public IActionResult Export([FromQuery] WfFlowTmplQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfFlowTmplService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "OA流程模板表", "OA流程模板表");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}