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
    /// 人事信息Controller
    /// 
    /// @tableName ehr_employee
    /// @author Davis.Cheng
    /// @date 2023-05-04
    /// </summary>
    [Verify]
    [Route("Office/EhrEmployee")]
    public class EhrEmployeeController : BaseController
    {
        /// <summary>
        /// 人事信息接口
        /// </summary>
        private readonly IEhrEmployeeService _EhrEmployeeService;
        /// <summary>
        /// 人事信息Controller
        /// </summary>
        public EhrEmployeeController(IEhrEmployeeService EhrEmployeeService)
        {
            _EhrEmployeeService = EhrEmployeeService;
        }

        /// <summary>
        /// 查询人事信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "ehr:employee:list")]
        public IActionResult QueryEhrEmployee([FromQuery] EhrEmployeeQueryDto parm)
        {
            var response = _EhrEmployeeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询人事信息详情
        /// </summary>
        /// <param name="EeId"></param>
        /// <returns></returns>
        [HttpGet("{EeId}")]
        [ActionPermissionFilter(Permission = "ehr:employee:query")]
        public IActionResult GetEhrEmployee(string EeId)
        {
            var response = _EhrEmployeeService.GetFirst(x => x.EeId == EeId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加人事信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "ehr:employee:add")]
        [Log(Title = "人事信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddEhrEmployee([FromBody] EhrEmployeeDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_EhrEmployeeService.CheckEntryStringUnique(parm.EeId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增人事信息 '{parm.EeId}'失败，输入的人事信息已存在"));
            }
            var modal = parm.Adapt<EhrEmployee>().ToCreate(HttpContext);

            var response = _EhrEmployeeService.AddEhrEmployee(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新人事信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "ehr:employee:edit")]
        [Log(Title = "人事信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateEhrEmployee([FromBody] EhrEmployeeDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<EhrEmployee>().ToUpdate(HttpContext);

            var response = _EhrEmployeeService.UpdateEhrEmployee(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除人事信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "ehr:employee:delete")]
        [Log(Title = "人事信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteEhrEmployee(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _EhrEmployeeService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出人事信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "人事信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "ehr:employee:export")]
        public IActionResult Export([FromQuery] EhrEmployeeQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _EhrEmployeeService.GetList(parm).Result;
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
        [ActionPermissionFilter(Permission = "ehr:employee:delete")]
        [HttpDelete("clean")]
        public ApiResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            _EhrEmployeeService.TruncateEhrEmployee();

            return ToJson(1);
        }

    }
}