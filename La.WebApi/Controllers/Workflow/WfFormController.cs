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
    /// 表单Controller
    /// 
    /// @tableName wf_form
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfForm")]
    public class WfFormController : BaseController
    {
        /// <summary>
        /// 表单接口
        /// </summary>
        private readonly IWfFormService _WfFormService;
        /// <summary>
        /// 表单Controller
        /// </summary>
        public WfFormController(IWfFormService WfFormService)
        {
            _WfFormService = WfFormService;
        }

        /// <summary>
        /// 查询表单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "wf:form:list")]
        public IActionResult QueryWfForm([FromQuery] WfFormQueryDto parm)
        {
            var response = _WfFormService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询表单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "wf:form:query")]
        public IActionResult GetWfForm(long Id)
        {
            var response = _WfFormService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "wf:form:add")]
        [Log(Title = "表单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfForm([FromBody] WfFormDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfFormService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增表单 '{parm.Id}'失败，输入的表单已存在"));
            }
            var modal = parm.Adapt<WfForm>().ToCreate(HttpContext);

            var response = _WfFormService.AddWfForm(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新表单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "wf:form:edit")]
        [Log(Title = "表单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfForm([FromBody] WfFormDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfForm>().ToUpdate(HttpContext);

            var response = _WfFormService.UpdateWfForm(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除表单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "wf:form:delete")]
        [Log(Title = "表单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfForm(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfFormService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出表单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "表单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "wf:form:export")]
        public IActionResult Export([FromQuery] WfFormQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfFormService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "表单", "表单");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}