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
    /// 部门消耗Controller
    /// 
    /// @tableName fico_dept_consuming
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    [Verify]
    [Route("Financial/FicoDeptConsuming")]
    public class FicoDeptConsumingController : BaseController
    {
        /// <summary>
        /// 部门消耗接口
        /// </summary>
        private readonly IFicoDeptConsumingService _FicoDeptConsumingService;
        /// <summary>
        /// 部门消耗Controller
        /// </summary>
        public FicoDeptConsumingController(IFicoDeptConsumingService FicoDeptConsumingService)
        {
            _FicoDeptConsumingService = FicoDeptConsumingService;
        }

        /// <summary>
        /// 查询部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:ficodeptconsuming:list")]
        public IActionResult QueryFicoDeptConsuming([FromQuery] FicoDeptConsumingQueryDto parm)
        {
            var response = _FicoDeptConsumingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询部门消耗详情
        /// </summary>
        /// <param name="DcId"></param>
        /// <returns></returns>
        [HttpGet("{DcId}")]
        [ActionPermissionFilter(Permission = "la:ficodeptconsuming:query")]
        public IActionResult GetFicoDeptConsuming(long DcId)
        {
            var response = _FicoDeptConsumingService.GetFirst(x => x.DcId == DcId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:ficodeptconsuming:add")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoDeptConsuming([FromBody] FicoDeptConsumingDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_FicoDeptConsumingService.CheckEntryStringUnique(parm.DcYm+parm.DcCostCode+parm.DcPlant+parm.DcMateriel+parm.DcStorageLocation+parm.DcMoveType)))
            {
                return ToResponse(ApiResult.Error($"新增部门消耗 '{parm.DcYm +","+ parm.DcCostCode + "," + parm.DcPlant + "," + parm.DcMateriel + "," + parm.DcStorageLocation + "," + parm.DcMoveType}'失败，输入的部门消耗已存在"));
            }
            var modal = parm.Adapt<FicoDeptConsuming>().ToCreate(HttpContext);

            var response = _FicoDeptConsumingService.AddFicoDeptConsuming(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:ficodeptconsuming:edit")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoDeptConsuming([FromBody] FicoDeptConsumingDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoDeptConsuming>().ToUpdate(HttpContext);

            var response = _FicoDeptConsumingService.UpdateFicoDeptConsuming(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除部门消耗
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:ficodeptconsuming:delete")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoDeptConsuming(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoDeptConsumingService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出部门消耗
        /// </summary>
        /// <returns></returns>
        [Log(Title = "部门消耗", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:ficodeptconsuming:export")]
        public IActionResult Export([FromQuery] FicoDeptConsumingQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoDeptConsumingService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "部门消耗", "部门消耗");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}