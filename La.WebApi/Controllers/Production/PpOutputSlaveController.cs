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
    /// oph从表Controller
    /// 
    /// @tableName pp_output_slave
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-18
    /// </summary>
    [Verify]
    [Route("production/PpOutputSlave")]
    public class PpOutputSlaveController : BaseController
    {
        /// <summary>
        /// oph从表接口
        /// </summary>
        private readonly IPpOutputSlaveService _PpOutputSlaveService;
        /// <summary>
        /// oph从表接口
        /// </summary>
        public PpOutputSlaveController(IPpOutputSlaveService PpOutputSlaveService)
        {
            _PpOutputSlaveService = PpOutputSlaveService;
        }

        /// <summary>
        /// 查询oph从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:outputslave:list")]
        public IActionResult QueryPpOutputSlave([FromQuery] PpOutputSlaveQueryDto parm)
        {
            var response = _PpOutputSlaveService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询oph从表详情
        /// </summary>
        /// <param name="PosId"></param>
        /// <returns></returns>
        [HttpGet("{PosId}")]
        [ActionPermissionFilter(Permission = "pp:outputslave:query")]
        public IActionResult GetPpOutputSlave(int PosId)
        {
            var response = _PpOutputSlaveService.GetFirst(x => x.PosId == PosId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加oph从表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:outputslave:add")]
        [Log(Title = "oph从表", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpOutputSlave([FromBody] PpOutputSlaveDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            // 校验输入项目是否唯一
            if (UserConstants.NOT_UNIQUE.Equals(_PpOutputSlaveService.CheckEntryStringUnique(parm.PomGuid.ToString() + parm.PosStartEndTime)))
            {
                return ToResponse(ApiResult.Error($"新增oph从表 '{parm.PomGuid +","+ parm.PosStartEndTime}'失败，输入的oph从表已存在"));
            }
            var modal = parm.Adapt<PpOutputSlave>().ToCreate(HttpContext);

            var response = _PpOutputSlaveService.AddPpOutputSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新oph从表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:outputslave:edit")]
        [Log(Title = "oph从表", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpOutputSlave([FromBody] PpOutputSlaveDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpOutputSlave>().ToUpdate(HttpContext);

            var response = _PpOutputSlaveService.UpdatePpOutputSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除oph从表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:outputslave:delete")]
        [Log(Title = "oph从表", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpOutputSlave(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpOutputSlaveService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出oph从表
        /// </summary>
        /// <returns></returns>
        [Log(Title = "oph从表", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:outputslave:export")]
        public IActionResult Export([FromQuery] PpOutputSlaveQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpOutputSlaveService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "oph从表", "oph从表");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}