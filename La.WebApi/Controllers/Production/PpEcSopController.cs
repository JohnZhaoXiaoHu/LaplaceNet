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
    /// SOP确认Controller
    /// 
    /// @tableName pp_ec_sop
    /// @author Davis.Cheng
    /// @date 2023-04-12
    /// </summary>
    [Verify]
    [Route("Production/PpEcSop")]
    public class PpEcSopController : BaseController
    {
        /// <summary>
        /// SOP确认接口
        /// </summary>
        private readonly IPpEcSopService _PpEcSopService;
        /// <summary>
        /// SOP确认Controller
        /// </summary>
        public PpEcSopController(IPpEcSopService PpEcSopService)
        {
            _PpEcSopService = PpEcSopService;
        }

        /// <summary>
        /// 查询SOP确认列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:ppecsop:list")]
        public IActionResult QueryPpEcSop([FromQuery] PpEcSopQueryDto parm)
        {
            var response = _PpEcSopService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询SOP确认详情
        /// </summary>
        /// <param name="EsId"></param>
        /// <returns></returns>
        [HttpGet("{EsId}")]
        [ActionPermissionFilter(Permission = "la:ppecsop:query")]
        public IActionResult GetPpEcSop(int EsId)
        {
            var response = _PpEcSopService.GetFirst(x => x.EsId == EsId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加SOP确认
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:ppecsop:add")]
        [Log(Title = "SOP确认", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSop([FromBody] PpEcSopDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSopService.CheckEntryStringUnique(parm.EsId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增SOP确认 '{parm.EsId}'失败，输入的SOP确认已存在"));
            }
            var modal = parm.Adapt<PpEcSop>().ToCreate(HttpContext);

            var response = _PpEcSopService.AddPpEcSop(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新SOP确认
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:ppecsop:edit")]
        [Log(Title = "SOP确认", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSop([FromBody] PpEcSopDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpEcSop>().ToUpdate(HttpContext);

            var response = _PpEcSopService.UpdatePpEcSop(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除SOP确认
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:ppecsop:delete")]
        [Log(Title = "SOP确认", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSop(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpEcSopService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出SOP确认
        /// </summary>
        /// <returns></returns>
        [Log(Title = "SOP确认", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:ppecsop:export")]
        public IActionResult Export([FromQuery] PpEcSopQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpEcSopService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "SOP确认", "SOP确认");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空SOP确认
        /// </summary>
        /// <returns></returns>
        [Log(Title = "SOP确认", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "la:ppecsop:delete")]
        [HttpDelete("clean")]
        public ApiResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            _PpEcSopService.TruncatePpEcSop();

            return ToJson(1);
        }

    }
}