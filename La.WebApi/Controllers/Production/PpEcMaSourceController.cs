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
    /// 主源设变Controller
    /// 
    /// @tableName pp_ec_ma_source
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    [Verify]
    [Route("Production/PpEcMaSource")]
    public class PpEcMaSourceController : BaseController
    {
        /// <summary>
        /// 主源设变接口
        /// </summary>
        private readonly IPpEcMaSourceService _PpEcMaSourceService;
        /// <summary>
        /// 主源设变Controller
        /// </summary>
        public PpEcMaSourceController(IPpEcMaSourceService PpEcMaSourceService)
        {
            _PpEcMaSourceService = PpEcMaSourceService;
        }

        /// <summary>
        /// 查询主源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmasource:list")]
        public IActionResult QueryPpEcMaSource([FromQuery] PpEcMaSourceQueryDto parm)
        {
            var response = _PpEcMaSourceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询主源设变详情
        /// </summary>
        /// <param name="Guid"></param>
        /// <returns></returns>
        [HttpGet("{Guid}")]
        [ActionPermissionFilter(Permission = "pp:ecmasource:query")]
        public IActionResult GetPpEcMaSource(string Guid)
        {
            var response = _PpEcMaSourceService.GetFirst(x => x.Guid == Guid);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加主源设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmasource:add")]
        [Log(Title = "主源设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMaSource([FromBody] PpEcMaSourceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMaSourceService.CheckEntryStringUnique(parm.Guid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增主源设变 '{parm.Guid}'失败，输入的主源设变已存在"));
            }
            var modal = parm.Adapt<PpEcMaSource>().ToCreate(HttpContext);

            var response = _PpEcMaSourceService.AddPpEcMaSource(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新主源设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmasource:edit")]
        [Log(Title = "主源设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMaSource([FromBody] PpEcMaSourceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpEcMaSource>().ToUpdate(HttpContext);

            var response = _PpEcMaSourceService.UpdatePpEcMaSource(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除主源设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmasource:delete")]
        [Log(Title = "主源设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMaSource(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpEcMaSourceService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出主源设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "主源设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmasource:export")]
        public IActionResult Export([FromQuery] PpEcMaSourceQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpEcMaSourceService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "主源设变", "主源设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空主源设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "主源设变", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "pp:ecmasource:delete")]
        [HttpDelete("clean")]
        public ApiResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            _PpEcMaSourceService.TruncatePpEcMaSource();

            return ToJson(1);
        }

    }
}