using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.Financial.IFinancialService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 财务期间Controller
    /// 
    /// @tableName fico_period
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-06
    /// </summary>
    [Verify]
    [Route("financial/FicoPeriod")]
    public class FicoPeriodController : BaseController
    {
        /// <summary>
        /// 财务期间接口
        /// </summary>
        private readonly IFicoPeriodService _FicoPeriodService;

        public FicoPeriodController(IFicoPeriodService FicoPeriodService)
        {
            _FicoPeriodService = FicoPeriodService;
        }

        /// <summary>
        /// 查询财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:period:list")]
        public IActionResult QueryFicoPeriod([FromQuery] FicoPeriodQueryDto parm)
        {
            var response = _FicoPeriodService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询财务期间详情
        /// </summary>
        /// <param name="FpId"></param>
        /// <returns></returns>
        [HttpGet("{FpId}")]
        [ActionPermissionFilter(Permission = "fico:period:query")]
        public IActionResult GetFicoPeriod(int FpId)
        {
            var response = _FicoPeriodService.GetFirst(x => x.FpId == FpId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加财务期间
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:period:add")]
        [Log(Title = "财务期间", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoPeriod([FromBody] FicoPeriodDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
            if (UserConstants.NOT_UNIQUE.Equals(_FicoPeriodService.CheckEntryStringUnique(parm.FpYm.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增财务期间 '{parm.FpYm}'失败，输入的财务期间已存在"));
            }
            var modal = parm.Adapt<FicoPeriod>().ToCreate(HttpContext);

            var response = _FicoPeriodService.AddFicoPeriod(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新财务期间
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:period:edit")]
        [Log(Title = "财务期间", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoPeriod([FromBody] FicoPeriodDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoPeriod>().ToUpdate(HttpContext);

            var response = _FicoPeriodService.UpdateFicoPeriod(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除财务期间
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "fico:period:delete")]
        [Log(Title = "财务期间", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoPeriod(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoPeriodService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出财务期间
        /// </summary>
        /// <returns></returns>
        [Log(Title = "财务期间", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:period:export")]
        public IActionResult Export([FromQuery] FicoPeriodQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoPeriodService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "财务期间", "财务期间");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}