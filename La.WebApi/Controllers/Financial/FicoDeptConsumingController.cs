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
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [Verify]
    [Route("financial/FicoDeptConsuming")]
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
        [ActionPermissionFilter(Permission = "fico:deptconsuming:list")]
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
        [ActionPermissionFilter(Permission = "fico:deptconsuming:query")]
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
        [ActionPermissionFilter(Permission = "fico:deptconsuming:add")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoDeptConsuming([FromBody] FicoDeptConsumingDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_FicoDeptConsumingService.CheckEntryStringUnique(parm.DcId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增部门消耗 '{parm.DcId}'失败，输入的部门消耗已存在"));
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
        [ActionPermissionFilter(Permission = "fico:deptconsuming:edit")]
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
        [ActionPermissionFilter(Permission = "fico:deptconsuming:delete")]
        [Log(Title = "部门消耗", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoDeptConsuming(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoDeptConsumingService.Delete(idsArr);

            return ToResponse(response);
        }



    }
}