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
    /// 常规物料数据Controller
    /// 
    /// @tableName mm_mara
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [Verify]
    [Route("material/MmMara")]
    public class MmMaraController : BaseController
    {
        /// <summary>
        /// 常规物料数据接口
        /// </summary>
        private readonly IMmMaraService _MmMaraService;
        /// <summary>
        /// 常规物料数据Controller
        /// </summary>
        public MmMaraController(IMmMaraService MmMaraService)
        {
            _MmMaraService = MmMaraService;
        }

        /// <summary>
        /// 查询常规物料数据列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:mara:list")]
        public IActionResult QueryMmMara([FromQuery] MmMaraQueryDto parm)
        {
            var response = _MmMaraService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询常规物料数据详情
        /// </summary>
        /// <param name="MaraID"></param>
        /// <returns></returns>
        [HttpGet("{MaraID}")]
        [ActionPermissionFilter(Permission = "mm:mara:query")]
        public IActionResult GetMmMara(int MaraID)
        {
            var response = _MmMaraService.GetFirst(x => x.MaraID == MaraID);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加常规物料数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:mara:add")]
        [Log(Title = "常规物料数据", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMara([FromBody] MmMaraDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_MmMaraService.CheckEntryStringUnique(parm.MaraID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增常规物料数据 '{parm.MaraID}'失败，输入的常规物料数据已存在"));
            }
            var modal = parm.Adapt<MmMara>().ToCreate(HttpContext);

            var response = _MmMaraService.AddMmMara(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新常规物料数据
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:mara:edit")]
        [Log(Title = "常规物料数据", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMara([FromBody] MmMaraDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<MmMara>().ToUpdate(HttpContext);

            var response = _MmMaraService.UpdateMmMara(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除常规物料数据
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "mm:mara:delete")]
        [Log(Title = "常规物料数据", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMara(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _MmMaraService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出常规物料数据
        /// </summary>
        /// <returns></returns>
        [Log(Title = "常规物料数据", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:mara:export")]
        public IActionResult Export([FromQuery] MmMaraQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _MmMaraService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "常规物料数据", "常规物料数据");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}