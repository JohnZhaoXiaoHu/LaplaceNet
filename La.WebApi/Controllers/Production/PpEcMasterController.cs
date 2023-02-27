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
    /// 主设变信息表Controller
    /// 
    /// @tableName pp_ec_master
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-24
    /// </summary>
    [Verify]
    [Route("production/PpEcMaster")]
    public class PpEcMasterController : BaseController
    {
        /// <summary>
        /// 主设变信息表接口
        /// </summary>
        private readonly IPpEcMasterService _PpEcMasterService;
        /// <summary>
        /// 主设变信息表Controller
        /// </summary>
        public PpEcMasterController(IPpEcMasterService PpEcMasterService)
        {
            _PpEcMasterService = PpEcMasterService;
        }

        /// <summary>
        /// 查询主设变信息表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:list")]
        public IActionResult QueryPpEcMaster([FromQuery] PpEcMasterQueryDto parm)
        {
            var response = _PpEcMasterService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询主设变信息表详情
        /// </summary>
        /// <param name="EmId"></param>
        /// <returns></returns>
        [HttpGet("{EmId}")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:query")]
        public IActionResult GetPpEcMaster(int EmId)
        {
            var response = _PpEcMasterService.GetFirst(x => x.EmId == EmId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加主设变信息表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecmaster:add")]
        [Log(Title = "主设变信息表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcMaster([FromBody] PpEcMasterDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcMasterService.CheckEntryStringUnique(parm.EmEcNo.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增主设变信息表 '{parm.EmEcNo}'失败，输入的主设变信息表已存在"));
            }
            var modal = parm.Adapt<PpEcMaster>().ToCreate(HttpContext);

            var response = _PpEcMasterService.AddPpEcMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新主设变信息表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecmaster:edit")]
        [Log(Title = "主设变信息表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcMaster([FromBody] PpEcMasterDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpEcMaster>().ToUpdate(HttpContext);

            var response = _PpEcMasterService.UpdatePpEcMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除主设变信息表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:delete")]
        [Log(Title = "主设变信息表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcMaster(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpEcMasterService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出主设变信息表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "主设变信息表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecmaster:export")]
        public IActionResult Export([FromQuery] PpEcMasterQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpEcMasterService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "主设变信息表", "主设变信息表");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}