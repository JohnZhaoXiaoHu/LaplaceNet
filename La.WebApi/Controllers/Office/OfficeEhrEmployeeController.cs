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
    /// 人事信息
    /// Controller
    /// @tableName office_ehr_employee
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [Verify]
    [Route("office/OfficeEhrEmployee")]
    public class OfficeEhrEmployeeController : BaseController
    {
        /// <summary>
        /// 人事信息接口
        /// </summary>
        private readonly IOfficeEhrEmployeeService _OfficeEhrEmployeeService;

        public OfficeEhrEmployeeController(IOfficeEhrEmployeeService OfficeEhrEmployeeService)
        {
            _OfficeEhrEmployeeService = OfficeEhrEmployeeService;
        }

        /// <summary>
        /// 查询人事信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "office:ehremployee:list")]
        public IActionResult QueryOfficeEhrEmployee([FromQuery] OfficeEhrEmployeeQueryDto parm)
        {
            var response = _OfficeEhrEmployeeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询人事信息详情
        /// </summary>
        /// <param name="EeId"></param>
        /// <returns></returns>
        [HttpGet("{EeId}")]
        [ActionPermissionFilter(Permission = "office:ehremployee:query")]
        public IActionResult GetOfficeEhrEmployee(string EeId)
        {
            var response = _OfficeEhrEmployeeService.GetInfo(EeId);
            
            var info = response.Adapt<OfficeEhrEmployee>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加人事信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "office:ehremployee:add")]
        [Log(Title = "人事信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddOfficeEhrEmployee([FromBody] OfficeEhrEmployeeDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_OfficeEhrEmployeeService.CheckEntryStringUnique(parm.EeId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增人事信息 '{parm.EeId}'失败，输入的人事信息已存在"));
            }
            var modal = parm.Adapt<OfficeEhrEmployee>().ToCreate(HttpContext);

            var response = _OfficeEhrEmployeeService.AddOfficeEhrEmployee(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新人事信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "office:ehremployee:edit")]
        [Log(Title = "人事信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateOfficeEhrEmployee([FromBody] OfficeEhrEmployeeDto parm)
        {
            var modal = parm.Adapt<OfficeEhrEmployee>().ToUpdate(HttpContext);
            var response = _OfficeEhrEmployeeService.UpdateOfficeEhrEmployee(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除人事信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "office:ehremployee:delete")]
        [Log(Title = "人事信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteOfficeEhrEmployee(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _OfficeEhrEmployeeService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出人事信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "人事信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "office:ehremployee:export")]
        public IActionResult Export([FromQuery] OfficeEhrEmployeeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _OfficeEhrEmployeeService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "人事信息", "人事信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空人事信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "人事信息", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "office:ehremployee:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_OfficeEhrEmployeeService.TruncateOfficeEhrEmployee());
        }

    }
}