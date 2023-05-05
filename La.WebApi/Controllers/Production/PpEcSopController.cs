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
    /// SOPController
    /// 
    /// @tableName pp_ec_sop
    /// @author Davis.Cheng
    /// @date 2023-05-03
    /// </summary>
    [Verify]
    [Route("Production/PpEcSop")]
    public class PpEcSopController : BaseController
    {
        /// <summary>
        /// SOP接口
        /// </summary>
        private readonly IPpEcSopService _PpEcSopService;
        /// <summary>
        /// SOPController
        /// </summary>
        public PpEcSopController(IPpEcSopService PpEcSopService)
        {
            _PpEcSopService = PpEcSopService;
        }

        /// <summary>
        /// 查询SOP列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecsop:list")]
        public IActionResult QueryPpEcSop([FromQuery] PpEcSopQueryDto parm)
        {
            var response = _PpEcSopService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询SOP详情
        /// </summary>
        /// <param name="EsId"></param>
        /// <returns></returns>
        [HttpGet("{EsId}")]
        [ActionPermissionFilter(Permission = "pp:ecsop:query")]
        public IActionResult GetPpEcSop(int EsId)
        {
            var response = _PpEcSopService.GetFirst(x => x.EsId == EsId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加SOP
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecsop:add")]
        [Log(Title = "SOP", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSop([FromBody] PpEcSopDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSopService.CheckEntryStringUnique(parm.EsId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增SOP '{parm.EsId}'失败，输入的SOP已存在"));
            }
            var modal = parm.Adapt<PpEcSop>().ToCreate(HttpContext);

            var response = _PpEcSopService.AddPpEcSop(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新SOP
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecsop:edit")]
        [Log(Title = "SOP", BusinessType = BusinessType.UPDATE)]
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
        /// 删除SOP
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecsop:delete")]
        [Log(Title = "SOP", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSop(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpEcSopService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出SOP
        /// </summary>
        /// <returns></returns>
        [Log(Title = "SOP", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecsop:export")]
        public IActionResult Export([FromQuery] PpEcSopQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpEcSopService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "SOP", "SOP");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空SOP
        /// </summary>
        /// <returns></returns>
        [Log(Title = "SOP", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "pp:ecsop:delete")]
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