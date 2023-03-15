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
    /// 工厂物料数据Controller
    /// 
    /// @tableName mm_marc
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("material/MmMarc")]
    public class MmMarcController : BaseController
    {
        /// <summary>
        /// 工厂物料数据接口
        /// </summary>
        private readonly IMmMarcService _MmMarcService;
        /// <summary>
        /// 工厂物料数据Controller
        /// </summary>
        public MmMarcController(IMmMarcService MmMarcService)
        {
            _MmMarcService = MmMarcService;
        }

        /// <summary>
        /// 查询工厂物料数据列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:marc:list")]
        public IActionResult QueryMmMarc([FromQuery] MmMarcQueryDto parm)
        {
            var response = _MmMarcService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工厂物料数据详情
        /// </summary>
        /// <param name="MarcID"></param>
        /// <returns></returns>
        [HttpGet("{MarcID}")]
        [ActionPermissionFilter(Permission = "mm:marc:query")]
        public IActionResult GetMmMarc(int MarcID)
        {
            var response = _MmMarcService.GetFirst(x => x.MarcID == MarcID);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加工厂物料数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:marc:add")]
        [Log(Title = "工厂物料数据", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMarc([FromBody] MmMarcDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_MmMarcService.CheckEntryStringUnique(parm.MarcID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增工厂物料数据 '{parm.MarcID}'失败，输入的工厂物料数据已存在"));
            }
            var modal = parm.Adapt<MmMarc>().ToCreate(HttpContext);

            var response = _MmMarcService.AddMmMarc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新工厂物料数据
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:marc:edit")]
        [Log(Title = "工厂物料数据", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMarc([FromBody] MmMarcDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<MmMarc>().ToUpdate(HttpContext);

            var response = _MmMarcService.UpdateMmMarc(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工厂物料数据
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "mm:marc:delete")]
        [Log(Title = "工厂物料数据", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMarc(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _MmMarcService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出工厂物料数据
        /// </summary>
        /// <returns></returns>
        [Log(Title = "工厂物料数据", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:marc:export")]
        public IActionResult Export([FromQuery] MmMarcQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _MmMarcService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "工厂物料数据", "工厂物料数据");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}