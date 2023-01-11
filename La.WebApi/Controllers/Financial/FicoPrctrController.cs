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
    /// 利润中心Controller
    /// 
    /// @tableName fico_prctr
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-11
    /// </summary>
    [Verify]
    [Route("financial/FicoPrctr")]
    public class FicoPrctrController : BaseController
    {
        /// <summary>
        /// 利润中心接口
        /// </summary>
        private readonly IFicoPrctrService _FicoPrctrService;

        public FicoPrctrController(IFicoPrctrService FicoPrctrService)
        {
            _FicoPrctrService = FicoPrctrService;
        }

        /// <summary>
        /// 查询利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:prctr:list")]
        public IActionResult QueryFicoPrctr([FromQuery] FicoPrctrQueryDto parm)
        {
            var response = _FicoPrctrService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询利润中心详情
        /// </summary>
        /// <param name="FpId"></param>
        /// <returns></returns>
        [HttpGet("{FpId}")]
        [ActionPermissionFilter(Permission = "fico:prctr:query")]
        public IActionResult GetFicoPrctr(long FpId)
        {
            var response = _FicoPrctrService.GetFirst(x => x.FpId == FpId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加利润中心
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:prctr:add")]
        [Log(Title = "利润中心", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoPrctr([FromBody] FicoPrctrDto parm)
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
            if (UserConstants.NOT_UNIQUE.Equals(_FicoPrctrService.CheckEntryStringUnique(parm.FpId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增利润中心 '{parm.FpId}'失败，输入的利润中心已存在"));
            }
            var modal = parm.Adapt<FicoPrctr>().ToCreate(HttpContext);

            var response = _FicoPrctrService.AddFicoPrctr(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新利润中心
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:prctr:edit")]
        [Log(Title = "利润中心", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoPrctr([FromBody] FicoPrctrDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoPrctr>().ToUpdate(HttpContext);

            var response = _FicoPrctrService.UpdateFicoPrctr(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除利润中心
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "fico:prctr:delete")]
        [Log(Title = "利润中心", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoPrctr(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoPrctrService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出利润中心
        /// </summary>
        /// <returns></returns>
        [Log(Title = "利润中心", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:prctr:export")]
        public IActionResult Export([FromQuery] FicoPrctrQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoPrctrService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "利润中心", "利润中心");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}