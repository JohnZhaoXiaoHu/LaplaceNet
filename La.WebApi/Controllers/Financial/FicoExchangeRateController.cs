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
    /// 汇率表Controller
    /// 
    /// @tableName fico_exchange_rate
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [Verify]
    [Route("financial/FicoExchangeRate")]
    public class FicoExchangeRateController : BaseController
    {
        /// <summary>
        /// 汇率表接口
        /// </summary>
        private readonly IFicoExchangeRateService _FicoExchangeRateService;

        public FicoExchangeRateController(IFicoExchangeRateService FicoExchangeRateService)
        {
            _FicoExchangeRateService = FicoExchangeRateService;
        }

        /// <summary>
        /// 查询汇率表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:list")]
        public IActionResult QueryFicoExchangeRate([FromQuery] FicoExchangeRateQueryDto parm)
        {
            var response = _FicoExchangeRateService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询汇率表详情
        /// </summary>
        /// <param name="ErId"></param>
        /// <returns></returns>
        [HttpGet("{ErId}")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:query")]
        public IActionResult GetFicoExchangeRate(long ErId)
        {
            var response = _FicoExchangeRateService.GetFirst(x => x.ErId == ErId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加汇率表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:exchangerate:add")]
        [Log(Title = "汇率表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoExchangeRate([FromBody] FicoExchangeRateDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            //日期格式转换方便比较
            //string ss = Convert.ToDateTime(parm.ErEffDate).ToString("yyyyMMdd");
        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
            if (UserConstants.NOT_UNIQUE.Equals(_FicoExchangeRateService.CheckEntryStringUnique(Convert.ToDateTime(parm.ErEffDate).ToString("yyyyMMdd") + parm.ErfmCcy)))
            {
                return ToResponse(ApiResult.Error($"新增汇率表 '{Convert.ToDateTime(parm.ErEffDate).ToString("yyyy-MM-dd") + ":"+ parm.ErfmCcy}'失败，输入的汇率表已存在"));
            }
            var modal = parm.Adapt<FicoExchangeRate>().ToCreate(HttpContext);

            var response = _FicoExchangeRateService.AddFicoExchangeRate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新汇率表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:exchangerate:edit")]
        [Log(Title = "汇率表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoExchangeRate([FromBody] FicoExchangeRateDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoExchangeRate>().ToUpdate(HttpContext);

            var response = _FicoExchangeRateService.UpdateFicoExchangeRate(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除汇率表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:delete")]
        [Log(Title = "汇率表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoExchangeRate(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoExchangeRateService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出汇率表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "汇率表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:exchangerate:export")]
        public IActionResult Export([FromQuery] FicoExchangeRateQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoExchangeRateService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "汇率表", "汇率表");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}