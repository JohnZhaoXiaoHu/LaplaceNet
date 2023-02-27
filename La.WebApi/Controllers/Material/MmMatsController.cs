using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.Material.IMaterialService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 物料信息Controller
    /// 
    /// @tableName mm_mats
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-25
    /// </summary>
    [Verify]
    [Route("material/MmMats")]
    public class MmMatsController : BaseController
    {
        /// <summary>
        /// 物料信息接口
        /// </summary>
        private readonly IMmMatsService _MmMatsService;
        /// <summary>
        /// 物料信息Controller
        /// </summary>
        public MmMatsController(IMmMatsService MmMatsService)
        {
            _MmMatsService = MmMatsService;
        }

        /// <summary>
        /// 查询物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:mats:list")]
        public IActionResult QueryMmMats([FromQuery] MmMatsQueryDto parm)
        {
            var response = _MmMatsService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询物料信息详情
        /// </summary>
        /// <param name="MmId"></param>
        /// <returns></returns>
        [HttpGet("{MmId}")]
        [ActionPermissionFilter(Permission = "mm:mats:query")]
        public IActionResult GetMmMats(int MmId)
        {
            var response = _MmMatsService.GetFirst(x => x.MmId == MmId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加物料信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:mats:add")]
        [Log(Title = "物料信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMats([FromBody] MmMatsDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_MmMatsService.CheckEntryStringUnique(parm.MmPlnt + parm.MmMatItem)))
            {
                return ToResponse(ApiResult.Error($"新增物料信息 '{parm.MmPlnt +","+ parm.MmMatItem}'失败，输入的物料信息已存在"));
            }
            var modal = parm.Adapt<MmMats>().ToCreate(HttpContext);

            var response = _MmMatsService.AddMmMats(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新物料信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:mats:edit")]
        [Log(Title = "物料信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMats([FromBody] MmMatsDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<MmMats>().ToUpdate(HttpContext);

            var response = _MmMatsService.UpdateMmMats(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除物料信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "mm:mats:delete")]
        [Log(Title = "物料信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMats(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _MmMatsService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出物料信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "物料信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:mats:export")]
        public IActionResult Export([FromQuery] MmMatsQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _MmMatsService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "物料信息", "物料信息");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}