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
    /// 顾客信息Controller
    /// 
    /// @tableName sd_customer
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-03
    /// </summary>
    [Verify]
    [Route("sales/SdCustomer")]
    public class SdCustomerController : BaseController
    {
        /// <summary>
        /// 顾客信息接口
        /// </summary>
        private readonly ISdCustomerService _SdCustomerService;
        /// <summary>
        /// 顾客信息Controller
        /// </summary>
        public SdCustomerController(ISdCustomerService SdCustomerService)
        {
            _SdCustomerService = SdCustomerService;
        }

        /// <summary>
        /// 查询顾客信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:customer:list")]
        public IActionResult QuerySdCustomer([FromQuery] SdCustomerQueryDto parm)
        {
            var response = _SdCustomerService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询顾客信息详情
        /// </summary>
        /// <param name="ScId"></param>
        /// <returns></returns>
        [HttpGet("{ScId}")]
        [ActionPermissionFilter(Permission = "sd:customer:query")]
        public IActionResult GetSdCustomer(long ScId)
        {
            var response = _SdCustomerService.GetFirst(x => x.ScId == ScId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加顾客信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:customer:add")]
        [Log(Title = "顾客信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdCustomer([FromBody] SdCustomerDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_SdCustomerService.CheckEntryStringUnique(parm.ScId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增顾客信息 '{parm.ScId}'失败，输入的顾客信息已存在"));
            }
            var modal = parm.Adapt<SdCustomer>().ToCreate(HttpContext);

            var response = _SdCustomerService.AddSdCustomer(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新顾客信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:customer:edit")]
        [Log(Title = "顾客信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdCustomer([FromBody] SdCustomerDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<SdCustomer>().ToUpdate(HttpContext);

            var response = _SdCustomerService.UpdateSdCustomer(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除顾客信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sd:customer:delete")]
        [Log(Title = "顾客信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdCustomer(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SdCustomerService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出顾客信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "顾客信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:customer:export")]
        public IActionResult Export([FromQuery] SdCustomerQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _SdCustomerService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "顾客信息", "顾客信息");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}