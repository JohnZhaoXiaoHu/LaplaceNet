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
    /// 销售凭证Controller
    /// 
    /// @tableName sd_sales_proof
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [Verify]
    [Route("sales/SdSalesProof")]
    public class SdSalesProofController : BaseController
    {
        /// <summary>
        /// 销售凭证接口
        /// </summary>
        private readonly ISdSalesProofService _SdSalesProofService;
        /// <summary>
        /// 销售凭证Controller
        /// </summary>
        public SdSalesProofController(ISdSalesProofService SdSalesProofService)
        {
            _SdSalesProofService = SdSalesProofService;
        }

        /// <summary>
        /// 查询销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:salesproof:list")]
        public IActionResult QuerySdSalesProof([FromQuery] SdSalesProofQueryDto parm)
        {
            var response = _SdSalesProofService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询销售凭证详情
        /// </summary>
        /// <param name="SpId"></param>
        /// <returns></returns>
        [HttpGet("{SpId}")]
        [ActionPermissionFilter(Permission = "sd:salesproof:query")]
        public IActionResult GetSdSalesProof(long SpId)
        {
            var response = _SdSalesProofService.GetFirst(x => x.SpId == SpId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:salesproof:add")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdSalesProof([FromBody] SdSalesProofDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_SdSalesProofService.CheckEntryStringUnique(parm.SpId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增销售凭证 '{parm.SpId}'失败，输入的销售凭证已存在"));
            }
            var modal = parm.Adapt<SdSalesProof>().ToCreate(HttpContext);

            var response = _SdSalesProofService.AddSdSalesProof(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:salesproof:edit")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdSalesProof([FromBody] SdSalesProofDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<SdSalesProof>().ToUpdate(HttpContext);

            var response = _SdSalesProofService.UpdateSdSalesProof(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除销售凭证
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sd:salesproof:delete")]
        [Log(Title = "销售凭证", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdSalesProof(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SdSalesProofService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出销售凭证
        /// </summary>
        /// <returns></returns>
        [Log(Title = "销售凭证", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:salesproof:export")]
        public IActionResult Export([FromQuery] SdSalesProofQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _SdSalesProofService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "销售凭证", "销售凭证");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}