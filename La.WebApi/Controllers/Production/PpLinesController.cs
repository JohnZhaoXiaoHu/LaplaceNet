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
    /// 生产班组Controller
    /// 
    /// @tableName pp_lines
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-09
    /// </summary>
    [Verify]
    [Route("Production/PpLines")]
    public class PpLinesController : BaseController
    {
        /// <summary>
        /// 生产班组接口
        /// </summary>
        private readonly IPpLinesService _PpLinesService;

        public PpLinesController(IPpLinesService PpLinesService)
        {
            _PpLinesService = PpLinesService;
        }

        /// <summary>
        /// 查询生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:lines:list")]
        public IActionResult QueryPpLines([FromQuery] PpLinesQueryDto parm)
        {
            var response = _PpLinesService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生产班组详情
        /// </summary>
        /// <param name="PlId"></param>
        /// <returns></returns>
        [HttpGet("{PlId}")]
        [ActionPermissionFilter(Permission = "pp:lines:query")]
        public IActionResult GetPpLines(long PlId)
        {
            var response = _PpLinesService.GetFirst(x => x.PlId == PlId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加生产班组
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:lines:add")]
        [Log(Title = "生产班组", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpLines([FromBody] PpLinesDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
            if (UserConstants.NOT_UNIQUE.Equals(_PpLinesService.CheckEntryStringUnique(parm.PlLineCode)))
            {
                return ToResponse(ApiResult.Error($"新增生产班组 '{parm.PlLineCode}'失败，输入的生产班组已存在"));
            }
            var modal = parm.Adapt<PpLines>().ToCreate(HttpContext);

            var response = _PpLinesService.AddPpLines(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新生产班组
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:lines:edit")]
        [Log(Title = "生产班组", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpLines([FromBody] PpLinesDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpLines>().ToUpdate(HttpContext);

            var response = _PpLinesService.UpdatePpLines(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产班组
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:lines:delete")]
        [Log(Title = "生产班组", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpLines(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpLinesService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出生产班组
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产班组", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:lines:export")]
        public IActionResult Export([FromQuery] PpLinesQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpLinesService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生产班组", "生产班组");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}