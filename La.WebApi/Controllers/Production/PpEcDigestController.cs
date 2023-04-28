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
    /// 新旧物料Controller
    /// 
    /// @tableName pp_ec_digest
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    [Verify]
    [Route("Production/PpEcDigest")]
    public class PpEcDigestController : BaseController
    {
        /// <summary>
        /// 新旧物料接口
        /// </summary>
        private readonly IPpEcDigestService _PpEcDigestService;
        /// <summary>
        /// 新旧物料Controller
        /// </summary>
        public PpEcDigestController(IPpEcDigestService PpEcDigestService)
        {
            _PpEcDigestService = PpEcDigestService;
        }

        /// <summary>
        /// 查询新旧物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "la:ppecdigest:list")]
        public IActionResult QueryPpEcDigest([FromQuery] PpEcDigestQueryDto parm)
        {
            var response = _PpEcDigestService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询新旧物料详情
        /// </summary>
        /// <param name="EdId"></param>
        /// <returns></returns>
        [HttpGet("{EdId}")]
        [ActionPermissionFilter(Permission = "la:ppecdigest:query")]
        public IActionResult GetPpEcDigest(int EdId)
        {
            var response = _PpEcDigestService.GetFirst(x => x.EdId == EdId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加新旧物料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "la:ppecdigest:add")]
        [Log(Title = "新旧物料", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcDigest([FromBody] PpEcDigestDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcDigestService.CheckEntryStringUnique(parm.EdId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增新旧物料 '{parm.EdId}'失败，输入的新旧物料已存在"));
            }
            var modal = parm.Adapt<PpEcDigest>().ToCreate(HttpContext);

            var response = _PpEcDigestService.AddPpEcDigest(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新新旧物料
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "la:ppecdigest:edit")]
        [Log(Title = "新旧物料", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcDigest([FromBody] PpEcDigestDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpEcDigest>().ToUpdate(HttpContext);

            var response = _PpEcDigestService.UpdatePpEcDigest(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除新旧物料
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "la:ppecdigest:delete")]
        [Log(Title = "新旧物料", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcDigest(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpEcDigestService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出新旧物料
        /// </summary>
        /// <returns></returns>
        [Log(Title = "新旧物料", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "la:ppecdigest:export")]
        public IActionResult Export([FromQuery] PpEcDigestQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpEcDigestService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "新旧物料", "新旧物料");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空新旧物料
        /// </summary>
        /// <returns></returns>
        [Log(Title = "新旧物料", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "la:ppecdigest:delete")]
        [HttpDelete("clean")]
        public ApiResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            _PpEcDigestService.TruncatePpEcDigest();

            return ToJson(1);
        }

    }
}