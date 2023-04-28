using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.System.ISystemService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 单据编码Controller
    /// 
    /// @tableName sys_ref_strategy
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    [Verify]
    [Route("System/SysRefStrategy")]
    public class RefStrategyController : BaseController
    {
        /// <summary>
        /// 单据编码接口
        /// </summary>
        private readonly IRefStrategyService _RefStrategyService;
        /// <summary>
        /// 单据编码Controller
        /// </summary>
        public RefStrategyController(IRefStrategyService RefStrategyService)
        {
            _RefStrategyService = RefStrategyService;
        }

        /// <summary>
        /// 查询单据编码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sys:refstrategy:list")]
        public IActionResult QueryRefStrategy([FromQuery] RefStrategyQueryDto parm)
        {
            var response = _RefStrategyService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询单据编码详情
        /// </summary>
        /// <param name="RefId"></param>
        /// <returns></returns>
        [HttpGet("{RefId}")]
        [ActionPermissionFilter(Permission = "sys:refstrategy:query")]
        public IActionResult GetRefStrategy(long RefId)
        {
            var response = _RefStrategyService.GetFirst(x => x.RefId == RefId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加单据编码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sys:refstrategy:add")]
        [Log(Title = "单据编码", BusinessType = BusinessType.INSERT)]
        public IActionResult AddRefStrategy([FromBody] RefStrategyDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_RefStrategyService.CheckEntryStringUnique(parm.RefId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增单据编码 '{parm.RefId}'失败，输入的单据编码已存在"));
            }
            var modal = parm.Adapt<RefStrategy>().ToCreate(HttpContext);

            var response = _RefStrategyService.AddRefStrategy(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新单据编码
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sys:refstrategy:edit")]
        [Log(Title = "单据编码", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateRefStrategy([FromBody] RefStrategyDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<RefStrategy>().ToUpdate(HttpContext);

            var response = _RefStrategyService.UpdateRefStrategy(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除单据编码
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sys:refstrategy:delete")]
        [Log(Title = "单据编码", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteRefStrategy(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _RefStrategyService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出单据编码
        /// </summary>
        /// <returns></returns>
        [Log(Title = "单据编码", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sys:refstrategy:export")]
        public IActionResult Export([FromQuery] RefStrategyQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _RefStrategyService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "单据编码", "单据编码");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空单据编码
        /// </summary>
        /// <returns></returns>
        [Log(Title = "单据编码", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "sys:refstrategy:delete")]
        [HttpDelete("clean")]
        public ApiResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            _RefStrategyService.TruncateRefStrategy();

            return ToJson(1);
        }

    }
}