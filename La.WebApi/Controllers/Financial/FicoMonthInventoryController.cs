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
    /// 月度存货明细Controller
    /// 
    /// @tableName fico_month_inventory
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [Verify]
    [Route("financial/FicoMonthInventory")]
    public class FicoMonthInventoryController : BaseController
    {
        /// <summary>
        /// 月度存货明细接口
        /// </summary>
        private readonly IFicoMonthInventoryService _FicoMonthInventoryService;
        /// <summary>
        /// 月度存货明细接口
        /// </summary>
        public FicoMonthInventoryController(IFicoMonthInventoryService FicoMonthInventoryService)
        {
            _FicoMonthInventoryService = FicoMonthInventoryService;
        }

        /// <summary>
        /// 查询月度存货明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:monthinventory:list")]
        public IActionResult QueryFicoMonthInventory([FromQuery] FicoMonthInventoryQueryDto parm)
        {
            var response = _FicoMonthInventoryService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询月度存货明细详情
        /// </summary>
        /// <param name="MiId"></param>
        /// <returns></returns>
        [HttpGet("{MiId}")]
        [ActionPermissionFilter(Permission = "fico:monthinventory:query")]
        public IActionResult GetFicoMonthInventory(string MiId)
        {
            var response = _FicoMonthInventoryService.GetFirst(x => x.MiId == MiId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加月度存货明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:monthinventory:add")]
        [Log(Title = "月度存货明细", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoMonthInventory([FromBody] FicoMonthInventoryDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_FicoMonthInventoryService.CheckEntryStringUnique(parm.MiId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增月度存货明细 '{parm.MiId}'失败，输入的月度存货明细已存在"));
            }
            var modal = parm.Adapt<FicoMonthInventory>().ToCreate(HttpContext);

            var response = _FicoMonthInventoryService.AddFicoMonthInventory(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新月度存货明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:monthinventory:edit")]
        [Log(Title = "月度存货明细", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoMonthInventory([FromBody] FicoMonthInventoryDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoMonthInventory>().ToUpdate(HttpContext);

            var response = _FicoMonthInventoryService.UpdateFicoMonthInventory(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除月度存货明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "fico:monthinventory:delete")]
        [Log(Title = "月度存货明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoMonthInventory(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoMonthInventoryService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出月度存货明细
        /// </summary>
        /// <returns></returns>
        [Log(Title = "月度存货明细", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:monthinventory:export")]
        public IActionResult Export([FromQuery] FicoMonthInventoryQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoMonthInventoryService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "月度存货明细", "月度存货明细");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}