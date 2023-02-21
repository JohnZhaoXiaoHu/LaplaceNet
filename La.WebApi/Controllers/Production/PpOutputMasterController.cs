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
    /// oph主表Controller
    /// 
    /// @tableName pp_output_master
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-12
    /// </summary>
    [Verify]
    [Route("production/PpOutputMaster")]
    public class PpOutputMasterController : BaseController
    {
        /// <summary>
        /// oph主表接口
        /// </summary>
        private readonly IPpOutputMasterService _PpOutputMasterService;
        /// <summary>
        /// oph主表接口
        /// </summary>
        public PpOutputMasterController(IPpOutputMasterService PpOutputMasterService)
        {
            _PpOutputMasterService = PpOutputMasterService;
        }

        /// <summary>
        /// 查询oph主表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:list")]
        public IActionResult QueryPpOutputMaster([FromQuery] PpOutputMasterQueryDto parm)
        {
            var response = _PpOutputMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询oph主表详情
        /// </summary>
        /// <param name="PomId"></param>
        /// <returns></returns>
        [HttpGet("{PomId}")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:query")]
        public IActionResult GetPpOutputMaster(int PomId)
        {
            var response = _PpOutputMasterService.GetFirst(x => x.PomId == PomId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加oph主表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputmaster:add")]
        [Log(Title = "oph主表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOutputMaster([FromBody] PpOutputMasterDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            // 校验输入项目是否唯一
            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputMasterService.CheckEntryStringUnique(Convert.ToDateTime(parm.PomMfDate).ToString("yyyyMMdd") + parm.PomOrder+ parm.PomMfItem+ parm.PomLineName)))
            {
                return ToResponse(ApiResult.Error($"新增oph主表 '{Convert.ToDateTime(parm.PomMfDate).ToString("yyyy-MM-dd") +","+ parm.PomOrder + "," + parm.PomMfItem + "," + parm.PomLineName}'失败，输入的oph主表已存在"));
            }
            var modal = parm.Adapt<PpOutputMaster>().ToCreate(HttpContext);

            var response = _PpOutputMasterService.AddPpOutputMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新oph主表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputmaster:edit")]
        [Log(Title = "oph主表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOutputMaster([FromBody] PpOutputMasterDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpOutputMaster>().ToUpdate(HttpContext);

            var response = _PpOutputMasterService.UpdatePpOutputMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除oph主表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:delete")]
        [Log(Title = "oph主表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputMaster(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpOutputMasterService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出oph主表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "oph主表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputmaster:export")]
        public IActionResult Export([FromQuery] PpOutputMasterQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpOutputMasterService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "oph主表", "oph主表");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}