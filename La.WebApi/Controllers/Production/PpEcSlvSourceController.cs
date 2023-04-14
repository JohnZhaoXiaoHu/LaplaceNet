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
    /// 从源设变Controller
    /// 
    /// @tableName pp_ec_slv_source
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    [Verify]
    [Route("Production/PpEcSlvSource")]
    public class PpEcSlvSourceController : BaseController
    {
        /// <summary>
        /// 从源设变接口
        /// </summary>
        private readonly IPpEcSlvSourceService _PpEcSlvSourceService;
        /// <summary>
        /// 从源设变Controller
        /// </summary>
        public PpEcSlvSourceController(IPpEcSlvSourceService PpEcSlvSourceService)
        {
            _PpEcSlvSourceService = PpEcSlvSourceService;
        }

        /// <summary>
        /// 查询从源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslvsource:list")]
        public IActionResult QueryPpEcSlvSource([FromQuery] PpEcSlvSourceQueryDto parm)
        {
            var response = _PpEcSlvSourceService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询从源设变详情
        /// </summary>
        /// <param name="Guid"></param>
        /// <returns></returns>
        [HttpGet("{Guid}")]
        [ActionPermissionFilter(Permission = "pp:ecslvsource:query")]
        public IActionResult GetPpEcSlvSource(string Guid)
        {
            var response = _PpEcSlvSourceService.GetFirst(x => x.Guid == Guid);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加从源设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslvsource:add")]
        [Log(Title = "从源设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlvSource([FromBody] PpEcSlvSourceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlvSourceService.CheckEntryStringUnique(parm.Guid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增从源设变 '{parm.Guid}'失败，输入的从源设变已存在"));
            }
            var modal = parm.Adapt<PpEcSlvSource>().ToCreate(HttpContext);

            var response = _PpEcSlvSourceService.AddPpEcSlvSource(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新从源设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslvsource:edit")]
        [Log(Title = "从源设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlvSource([FromBody] PpEcSlvSourceDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpEcSlvSource>().ToUpdate(HttpContext);

            var response = _PpEcSlvSourceService.UpdatePpEcSlvSource(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除从源设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslvsource:delete")]
        [Log(Title = "从源设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlvSource(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpEcSlvSourceService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出从源设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "从源设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslvsource:export")]
        public IActionResult Export([FromQuery] PpEcSlvSourceQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpEcSlvSourceService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "从源设变", "从源设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空从源设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "从源设变", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "pp:ecslvsource:delete")]
        [HttpDelete("clean")]
        public ApiResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            _PpEcSlvSourceService.TruncatePpEcSlvSource();

            return ToJson(1);
        }

    }
}