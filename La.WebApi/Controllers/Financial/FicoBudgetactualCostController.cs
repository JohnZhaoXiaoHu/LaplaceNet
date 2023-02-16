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
    /// 预算实际明细Controller
    /// 
    /// @tableName fico_budgetactual_cost
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [Verify]
    [Route("financial/FicoBudgetactualCost")]
    public class FicoBudgetactualCostController : BaseController
    {
        /// <summary>
        /// 预算实际明细接口
        /// </summary>
        private readonly IFicoBudgetactualCostService _FicoBudgetactualCostService;

        public FicoBudgetactualCostController(IFicoBudgetactualCostService FicoBudgetactualCostService)
        {
            _FicoBudgetactualCostService = FicoBudgetactualCostService;
        }

        /// <summary>
        /// 查询预算实际明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:list")]
        public IActionResult QueryFicoBudgetactualCost([FromQuery] FicoBudgetactualCostQueryDto parm)
        {
            var response = _FicoBudgetactualCostService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询预算实际明细详情
        /// </summary>
        /// <param name="FbId"></param>
        /// <returns></returns>
        [HttpGet("{FbId}")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:query")]
        public IActionResult GetFicoBudgetactualCost(long FbId)
        {
            var response = _FicoBudgetactualCostService.GetFirst(x => x.FbId == FbId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加预算实际明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:add")]
        [Log(Title = "预算实际明细", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoBudgetactualCost([FromBody] FicoBudgetactualCostDto parm)
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
            if (UserConstants.NOT_UNIQUE.Equals(_FicoBudgetactualCostService.CheckEntryStringUnique(parm.FbId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增预算实际明细 '{parm.FbId}'失败，输入的预算实际明细已存在"));
            }
            var modal = parm.Adapt<FicoBudgetactualCost>().ToCreate(HttpContext);

            var response = _FicoBudgetactualCostService.AddFicoBudgetactualCost(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新预算实际明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:edit")]
        [Log(Title = "预算实际明细", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoBudgetactualCost([FromBody] FicoBudgetactualCostDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoBudgetactualCost>().ToUpdate(HttpContext);

            var response = _FicoBudgetactualCostService.UpdateFicoBudgetactualCost(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除预算实际明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:delete")]
        [Log(Title = "预算实际明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoBudgetactualCost(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoBudgetactualCostService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出预算实际明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "预算实际明细", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:budgetactualcost:export")]
        public IActionResult Export([FromQuery] FicoBudgetactualCostQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoBudgetactualCostService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "预算实际明细", "预算实际明细");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}