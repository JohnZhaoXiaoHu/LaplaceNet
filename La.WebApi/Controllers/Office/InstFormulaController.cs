using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Office;
using La.Model.System;
using La.Service.Office.IOfficeService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 计算公式
    /// Controller
    /// @tableName inst_formula
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [Verify]
    [Route("office/InstFormula")]
    public class InstFormulaController : BaseController
    {
        /// <summary>
        /// 计算公式接口
        /// </summary>
        private readonly IInstFormulaService _InstFormulaService;

        public InstFormulaController(IInstFormulaService InstFormulaService)
        {
            _InstFormulaService = InstFormulaService;
        }

        /// <summary>
        /// 查询计算公式列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inst:formula:list")]
        public IActionResult QueryInstFormula([FromQuery] InstFormulaQueryDto parm)
        {
            var response = _InstFormulaService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询计算公式详情
        /// </summary>
        /// <param name="IfGuid"></param>
        /// <returns></returns>
        [HttpGet("{IfGuid}")]
        [ActionPermissionFilter(Permission = "inst:formula:query")]
        public IActionResult GetInstFormula(string IfGuid)
        {
            var response = _InstFormulaService.GetInfo(IfGuid);
            
            var info = response.Adapt<InstFormula>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加计算公式
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inst:formula:add")]
        [Log(Title = "计算公式", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInstFormula([FromBody] InstFormulaDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_InstFormulaService.CheckEntryStringUnique(parm.IfGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增计算公式 '{parm.IfGuid}'失败，输入的计算公式已存在"));
            }
            var modal = parm.Adapt<InstFormula>().ToCreate(HttpContext);

            var response = _InstFormulaService.AddInstFormula(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新计算公式
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inst:formula:edit")]
        [Log(Title = "计算公式", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInstFormula([FromBody] InstFormulaDto parm)
        {
            var modal = parm.Adapt<InstFormula>().ToUpdate(HttpContext);
            var response = _InstFormulaService.UpdateInstFormula(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除计算公式
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "inst:formula:delete")]
        [Log(Title = "计算公式", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInstFormula(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _InstFormulaService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出计算公式
        /// </summary>
        /// <returns></returns>
        [Log(Title = "计算公式", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inst:formula:export")]
        public IActionResult Export([FromQuery] InstFormulaQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InstFormulaService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "计算公式", "计算公式");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空计算公式
        /// </summary>
        /// <returns></returns>
        [Log(Title = "计算公式", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "inst:formula:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_InstFormulaService.TruncateInstFormula());
        }

    }
}