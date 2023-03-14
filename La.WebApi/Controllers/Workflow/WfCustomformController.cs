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
    /// 自定义表单Controller
    /// 
    /// @tableName wf_customform
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("workflow/WfCustomform")]
    public class WfCustomformController : BaseController
    {
        /// <summary>
        /// 自定义表单接口
        /// </summary>
        private readonly IWfCustomformService _WfCustomformService;
        /// <summary>
        /// 自定义表单Controller
        /// </summary>
        public WfCustomformController(IWfCustomformService WfCustomformService)
        {
            _WfCustomformService = WfCustomformService;
        }

        /// <summary>
        /// 查询自定义表单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "wf:customform:list")]
        public IActionResult QueryWfCustomform([FromQuery] WfCustomformQueryDto parm)
        {
            var response = _WfCustomformService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询自定义表单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "wf:customform:query")]
        public IActionResult GetWfCustomform(long Id)
        {
            var response = _WfCustomformService.GetFirst(x => x.Id == Id);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加自定义表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "wf:customform:add")]
        [Log(Title = "自定义表单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWfCustomform([FromBody] WfCustomformDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_WfCustomformService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增自定义表单 '{parm.Id}'失败，输入的自定义表单已存在"));
            }
            var modal = parm.Adapt<WfCustomform>().ToCreate(HttpContext);

            var response = _WfCustomformService.AddWfCustomform(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新自定义表单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "wf:customform:edit")]
        [Log(Title = "自定义表单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWfCustomform([FromBody] WfCustomformDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<WfCustomform>().ToUpdate(HttpContext);

            var response = _WfCustomformService.UpdateWfCustomform(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除自定义表单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "wf:customform:delete")]
        [Log(Title = "自定义表单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWfCustomform(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _WfCustomformService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出自定义表单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "自定义表单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "wf:customform:export")]
        public IActionResult Export([FromQuery] WfCustomformQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _WfCustomformService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "自定义表单", "自定义表单");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}