using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.Production.IProductionService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 生产工单Controller
    /// 
    /// @tableName pp_mfg_order
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-09
    /// </summary>
    [Verify]
    [Route("production/PpMfgOrder")]
    public class PpMfgOrderController : BaseController
    {
        /// <summary>
        /// 生产工单接口
        /// </summary>
        private readonly IPpMfgOrderService _PpMfgOrderService;
        /// <summary>
        /// 生产工单接口
        /// </summary>
        public PpMfgOrderController(IPpMfgOrderService PpMfgOrderService)
        {
            _PpMfgOrderService = PpMfgOrderService;
        }

        /// <summary>
        /// 查询生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:mfgorder:list")]
        public IActionResult QueryPpMfgOrder([FromQuery] PpMfgOrderQueryDto parm)
        {
            var response = _PpMfgOrderService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生产工单详情
        /// </summary>
        /// <param name="MoId"></param>
        /// <returns></returns>
        [HttpGet("{MoId}")]
        [ActionPermissionFilter(Permission = "pp:mfgorder:query")]
        public IActionResult GetPpMfgOrder(long MoId)
        {
            var response = _PpMfgOrderService.GetFirst(x => x.MoId == MoId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:mfgorder:add")]
        [Log(Title = "生产工单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpMfgOrder([FromBody] PpMfgOrderDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            // 校验输入项目是否唯一
            if (UserConstants.NOT_UNIQUE.Equals(_PpMfgOrderService.CheckEntryStringUnique(parm.MoOrderNo.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增生产工单 '{parm.MoOrderNo}'失败，输入的生产工单已存在"));
            }
            var modal = parm.Adapt<PpMfgOrder>().ToCreate(HttpContext);

            var response = _PpMfgOrderService.AddPpMfgOrder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新生产工单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:mfgorder:edit")]
        [Log(Title = "生产工单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpMfgOrder([FromBody] PpMfgOrderDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpMfgOrder>().ToUpdate(HttpContext);

            var response = _PpMfgOrderService.UpdatePpMfgOrder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产工单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:mfgorder:delete")]
        [Log(Title = "生产工单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpMfgOrder(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpMfgOrderService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出生产工单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产工单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:mfgorder:export")]
        public IActionResult Export([FromQuery] PpMfgOrderQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpMfgOrderService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生产工单", "生产工单");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}