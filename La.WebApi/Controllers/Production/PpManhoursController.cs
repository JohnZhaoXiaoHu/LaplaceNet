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
    /// 标准工时Controller
    /// 
    /// @tableName pp_manhours
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [Verify]
    [Route("production/PpManhours")]
    public class PpManhoursController : BaseController
    {
        /// <summary>
        /// 标准工时接口
        /// </summary>
        private readonly IPpManhoursService _PpManhoursService;
        /// <summary>
        /// 标准工时Controller
        /// </summary>
        public PpManhoursController(IPpManhoursService PpManhoursService)
        {
            _PpManhoursService = PpManhoursService;
        }

        /// <summary>
        /// 查询标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:manhours:list")]
        public IActionResult QueryPpManhours([FromQuery] PpManhoursQueryDto parm)
        {
            var response = _PpManhoursService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询标准工时详情
        /// </summary>
        /// <param name="MhId"></param>
        /// <returns></returns>
        [HttpGet("{MhId}")]
        [ActionPermissionFilter(Permission = "pp:manhours:query")]
        public IActionResult GetPpManhours(long MhId)
        {
            var response = _PpManhoursService.GetFirst(x => x.MhId == MhId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加标准工时
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:manhours:add")]
        [Log(Title = "标准工时", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpManhours([FromBody] PpManhoursDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_PpManhoursService.CheckEntryStringUnique(parm.MhId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增标准工时 '{parm.MhId}'失败，输入的标准工时已存在"));
            }
            var modal = parm.Adapt<PpManhours>().ToCreate(HttpContext);

            var response = _PpManhoursService.AddPpManhours(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新标准工时
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:manhours:edit")]
        [Log(Title = "标准工时", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpManhours([FromBody] PpManhoursDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpManhours>().ToUpdate(HttpContext);

            var response = _PpManhoursService.UpdatePpManhours(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除标准工时
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:manhours:delete")]
        [Log(Title = "标准工时", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpManhours(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpManhoursService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出标准工时
        /// </summary>
        /// <returns></returns>
        [Log(Title = "标准工时", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:manhours:export")]
        public IActionResult Export([FromQuery] PpManhoursQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpManhoursService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "标准工时", "标准工时");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}