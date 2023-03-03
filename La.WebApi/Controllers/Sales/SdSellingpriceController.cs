using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.Sales.ISalesService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 销售价格Controller
    /// 
    /// @tableName sd_sellingprice
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-03
    /// </summary>
    [Verify]
    [Route("sales/SdSellingprice")]
    public class SdSellingpriceController : BaseController
    {
        /// <summary>
        /// 销售价格接口
        /// </summary>
        private readonly ISdSellingpriceService _SdSellingpriceService;
        /// <summary>
        /// 销售价格Controller
        /// </summary>
        public SdSellingpriceController(ISdSellingpriceService SdSellingpriceService)
        {
            _SdSellingpriceService = SdSellingpriceService;
        }

        /// <summary>
        /// 查询销售价格列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:sellingprice:list")]
        public IActionResult QuerySdSellingprice([FromQuery] SdSellingpriceQueryDto parm)
        {
            var response = _SdSellingpriceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询销售价格详情
        /// </summary>
        /// <param name="SpId"></param>
        /// <returns></returns>
        [HttpGet("{SpId}")]
        [ActionPermissionFilter(Permission = "sd:sellingprice:query")]
        public IActionResult GetSdSellingprice(long SpId)
        {
            var response = _SdSellingpriceService.GetFirst(x => x.SpId == SpId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加销售价格
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:sellingprice:add")]
        [Log(Title = "销售价格", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdSellingprice([FromBody] SdSellingpriceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_SdSellingpriceService.CheckEntryStringUnique(parm.SpId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增销售价格 '{parm.SpId}'失败，输入的销售价格已存在"));
            }
            var modal = parm.Adapt<SdSellingprice>().ToCreate(HttpContext);

            var response = _SdSellingpriceService.AddSdSellingprice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新销售价格
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:sellingprice:edit")]
        [Log(Title = "销售价格", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdSellingprice([FromBody] SdSellingpriceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<SdSellingprice>().ToUpdate(HttpContext);

            var response = _SdSellingpriceService.UpdateSdSellingprice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除销售价格
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sd:sellingprice:delete")]
        [Log(Title = "销售价格", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdSellingprice(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SdSellingpriceService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出销售价格
        /// </summary>
        /// <returns></returns>
        [Log(Title = "销售价格", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:sellingprice:export")]
        public IActionResult Export([FromQuery] SdSellingpriceQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _SdSellingpriceService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "销售价格", "销售价格");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}