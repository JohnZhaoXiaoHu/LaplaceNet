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
    /// 从设变Controller
    /// 
    /// @tableName pp_ec_slave
    /// @author Davis.Cheng
    /// @date 2023-05-02
    /// </summary>
    [Verify]
    [Route("Production/PpEcSlave")]
    public class PpEcSlaveController : BaseController
    {
        /// <summary>
        /// 从设变接口
        /// </summary>
        private readonly IPpEcSlaveService _PpEcSlaveService;
        /// <summary>
        /// 从设变Controller
        /// </summary>
        public PpEcSlaveController(IPpEcSlaveService PpEcSlaveService)
        {
            _PpEcSlaveService = PpEcSlaveService;
        }

        /// <summary>
        /// 查询从设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pp:ecslave:list")]
        public IActionResult QueryPpEcSlave([FromQuery] PpEcSlaveQueryDto parm)
        {
            var response = _PpEcSlaveService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询从设变详情
        /// </summary>
        /// <param name="EsId"></param>
        /// <returns></returns>
        [HttpGet("{EsId}")]
        [ActionPermissionFilter(Permission = "pp:ecslave:query")]
        public IActionResult GetPpEcSlave(int EsId)
        {
            var response = _PpEcSlaveService.GetFirst(x => x.EsId == EsId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加从设变
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pp:ecslave:add")]
        [Log(Title = "从设变", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPpEcSlave([FromBody] PpEcSlaveDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_PpEcSlaveService.CheckEntryStringUnique(parm.EsId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增从设变 '{parm.EsId}'失败，输入的从设变已存在"));
            }
            var modal = parm.Adapt<PpEcSlave>().ToCreate(HttpContext);

            var response = _PpEcSlaveService.AddPpEcSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新从设变
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pp:ecslave:edit")]
        [Log(Title = "从设变", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePpEcSlave([FromBody] PpEcSlaveDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<PpEcSlave>().ToUpdate(HttpContext);

            var response = _PpEcSlaveService.UpdatePpEcSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除从设变
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "pp:ecslave:delete")]
        [Log(Title = "从设变", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePpEcSlave(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _PpEcSlaveService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出从设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "从设变", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pp:ecslave:export")]
        public IActionResult Export([FromQuery] PpEcSlaveQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _PpEcSlaveService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "从设变", "从设变");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空从设变
        /// </summary>
        /// <returns></returns>
        [Log(Title = "从设变", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "pp:ecslave:delete")]
        [HttpDelete("clean")]
        public ApiResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            _PpEcSlaveService.TruncatePpEcSlave();

            return ToJson(1);
        }

    }
}