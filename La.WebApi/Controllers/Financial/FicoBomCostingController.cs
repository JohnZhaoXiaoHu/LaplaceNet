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
    /// bom成本核算Controller
    /// 
    /// @tableName fico_bom_costing
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [Verify]
    [Route("financial/FicoBomCosting")]
    public class FicoBomCostingController : BaseController
    {
        /// <summary>
        /// bom成本核算接口
        /// </summary>
        private readonly IFicoBomCostingService _FicoBomCostingService;

        public FicoBomCostingController(IFicoBomCostingService FicoBomCostingService)
        {
            _FicoBomCostingService = FicoBomCostingService;
        }

        /// <summary>
        /// 查询bom成本核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:list")]
        public IActionResult QueryFicoBomCosting([FromQuery] FicoBomCostingQueryDto parm)
        {
            var response = _FicoBomCostingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询bom成本核算详情
        /// </summary>
        /// <param name="BcId"></param>
        /// <returns></returns>
        [HttpGet("{BcId}")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:query")]
        public IActionResult GetFicoBomCosting(long BcId)
        {
            var response = _FicoBomCostingService.GetFirst(x => x.BcId == BcId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:bomcosting:add")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBomCosting([FromBody] FicoBomCostingDto parm)
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
            if (UserConstants.NOT_UNIQUE.Equals(_FicoBomCostingService.CheckEntryStringUnique(Convert.ToDateTime(parm.BcBalancedate).ToString("yyyyMMdd") + parm.BcPlant+parm.BcFy+parm.BcFy+parm.BcBomItem)))
            {
                return ToResponse(ApiResult.Error($"新增bom成本核算 '{parm.BcPlant +","+ parm.BcFy + "," + parm.BcFy + "," + parm.BcBomItem}'失败，输入的bom成本核算已存在"));
            }
            var modal = parm.Adapt<FicoBomCosting>().ToCreate(HttpContext);

            var response = _FicoBomCostingService.AddFicoBomCosting(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:bomcosting:edit")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBomCosting([FromBody] FicoBomCostingDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoBomCosting>().ToUpdate(HttpContext);

            var response = _FicoBomCostingService.UpdateFicoBomCosting(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除bom成本核算
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:delete")]
        [Log(Title = "bom成本核算", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBomCosting(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoBomCostingService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出bom成本核算
        /// </summary>
        /// <returns></returns>
        [Log(Title = "bom成本核算", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:bomcosting:export")]
        public IActionResult Export([FromQuery] FicoBomCostingQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoBomCostingService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "bom成本核算", "bom成本核算");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}