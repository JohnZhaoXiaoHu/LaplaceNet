using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.Office.IOfficeService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 单据编码Controller
    /// 
    /// @tableName office_numbering_rules
    /// @author Davis.Ching
    /// @date 2023-05-16
    /// </summary>
    [Verify]
    [Route("Office/OfficeNumberingRules")]
    public class OfficeNumberingRulesController : BaseController
    {
        /// <summary>
        /// 单据编码接口
        /// </summary>
        private readonly IOfficeNumberingRulesService _OfficeNumberingRulesService;
        /// <summary>
        /// 单据编码Controller
        /// </summary>
        public OfficeNumberingRulesController(IOfficeNumberingRulesService OfficeNumberingRulesService)
        {
            _OfficeNumberingRulesService = OfficeNumberingRulesService;
        }

        /// <summary>
        /// 查询单据编码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "office:numberingrules:list")]
        public IActionResult QueryOfficeNumberingRules([FromQuery] OfficeNumberingRulesQueryDto parm)
        {
            var response = _OfficeNumberingRulesService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询单据编码详情
        /// </summary>
        /// <param name="RefId"></param>
        /// <returns></returns>
        [HttpGet("{RefId}")]
        [ActionPermissionFilter(Permission = "office:numberingrules:query")]
        public IActionResult GetOfficeNumberingRules(long RefId)
        {
            var response = _OfficeNumberingRulesService.GetFirst(x => x.RefId == RefId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加单据编码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "office:numberingrules:add")]
        [Log(Title = "单据编码", BusinessType = BusinessType.INSERT)]
        public IActionResult AddOfficeNumberingRules([FromBody] OfficeNumberingRulesDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_OfficeNumberingRulesService.CheckEntryStringUnique(parm.RefId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增单据编码 '{parm.RefId}'失败，输入的单据编码已存在"));
            }
            var modal = parm.Adapt<OfficeNumberingRules>().ToCreate(HttpContext);

            var response = _OfficeNumberingRulesService.AddOfficeNumberingRules(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新单据编码
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "office:numberingrules:edit")]
        [Log(Title = "单据编码", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateOfficeNumberingRules([FromBody] OfficeNumberingRulesDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<OfficeNumberingRules>().ToUpdate(HttpContext);

            var response = _OfficeNumberingRulesService.UpdateOfficeNumberingRules(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除单据编码
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "office:numberingrules:delete")]
        [Log(Title = "单据编码", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteOfficeNumberingRules(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _OfficeNumberingRulesService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出单据编码
        /// </summary>
        /// <returns></returns>
        [Log(Title = "单据编码", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "office:numberingrules:export")]
        public IActionResult Export([FromQuery] OfficeNumberingRulesQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _OfficeNumberingRulesService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "单据编码", "单据编码");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}