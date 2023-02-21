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
    /// 原因类别Controller
    /// 
    /// @tableName pp_cause_type
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-10
    /// </summary>
    [Verify]
    [Route("production/PpCauseType")]
    public class PpCauseTypeController : BaseController
    {
        /// <summary>
        /// 原因类别接口
        /// </summary>
        private readonly IPpCauseTypeService _PpCauseTypeService;
        /// <summary>
        /// 原因类别接口
        /// </summary>
        public PpCauseTypeController(IPpCauseTypeService PpCauseTypeService)
        {
            _PpCauseTypeService = PpCauseTypeService;
        }

        /// <summary>
        /// 查询原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:causetype:list")]
        public IActionResult QueryPpCauseType([FromQuery] PpCauseTypeQueryDto parm)
        {
            var response = _PpCauseTypeService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询原因类别详情
        /// </summary>
        /// <param name="CtId"></param>
        /// <returns></returns>
        [HttpGet("{CtId}")]
        [ActionPermissionFilter(Permission = "pp:causetype:query")]
        public IActionResult GetPpCauseType(long CtId)
        {
            var response = _PpCauseTypeService.GetFirst(x => x.CtId == CtId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加原因类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:causetype:add")]
        [Log(Title = "原因类别", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpCauseType([FromBody] PpCauseTypeDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            // 校验输入项目是否唯一
            if (UserConstants.NOT_UNIQUE.Equals(_PpCauseTypeService.CheckEntryStringUnique(parm.CtId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增原因类别 '{parm.CtId}'失败，输入的原因类别已存在"));
            }
            var modal = parm.Adapt<PpCauseType>().ToCreate(HttpContext);

            var response = _PpCauseTypeService.AddPpCauseType(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新原因类别
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:causetype:edit")]
        [Log(Title = "原因类别", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpCauseType([FromBody] PpCauseTypeDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpCauseType>().ToUpdate(HttpContext);

            var response = _PpCauseTypeService.UpdatePpCauseType(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除原因类别
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:causetype:delete")]
        [Log(Title = "原因类别", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpCauseType(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpCauseTypeService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出原因类别
        /// </summary>
        /// <returns></returns>
        [Log(Title = "原因类别", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:causetype:export")]
        public IActionResult Export([FromQuery] PpCauseTypeQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpCauseTypeService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "原因类别", "原因类别");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}