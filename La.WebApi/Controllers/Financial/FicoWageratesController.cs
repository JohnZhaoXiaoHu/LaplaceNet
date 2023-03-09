using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.Financial.IFinancialService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 工厂工资率Controller
    /// 
    /// @tableName fico_wagerates
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [Verify]
    [Route("financial/FicoWagerates")]
    public class FicoWageratesController : BaseController
    {
        /// <summary>
        /// 工厂工资率接口
        /// </summary>
        private readonly IFicoWageratesService _FicoWageratesService;
        /// <summary>
        /// 工厂工资率Controller
        /// </summary>
        public FicoWageratesController(IFicoWageratesService FicoWageratesService)
        {
            _FicoWageratesService = FicoWageratesService;
        }

        /// <summary>
        /// 查询工厂工资率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:wagerates:list")]
        public IActionResult QueryFicoWagerates([FromQuery] FicoWageratesQueryDto parm)
        {
            var response = _FicoWageratesService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询工厂工资率详情
        /// </summary>
        /// <param name="FwId"></param>
        /// <returns></returns>
        [HttpGet("{FwId}")]
        [ActionPermissionFilter(Permission = "fico:wagerates:query")]
        public IActionResult GetFicoWagerates(int FwId)
        {
            var response = _FicoWageratesService.GetFirst(x => x.FwId == FwId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加工厂工资率
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:wagerates:add")]
        [Log(Title = "工厂工资率", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoWagerates([FromBody] FicoWageratesDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_FicoWageratesService.CheckEntryStringUnique(parm.FwId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增工厂工资率 '{parm.FwId}'失败，输入的工厂工资率已存在"));
            }
            var modal = parm.Adapt<FicoWagerates>().ToCreate(HttpContext);

            var response = _FicoWageratesService.AddFicoWagerates(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新工厂工资率
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:wagerates:edit")]
        [Log(Title = "工厂工资率", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoWagerates([FromBody] FicoWageratesDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoWagerates>().ToUpdate(HttpContext);

            var response = _FicoWageratesService.UpdateFicoWagerates(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除工厂工资率
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "fico:wagerates:delete")]
        [Log(Title = "工厂工资率", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoWagerates(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoWageratesService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出工厂工资率
        /// </summary>
        /// <returns></returns>
        [Log(Title = "工厂工资率", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:wagerates:export")]
        public IActionResult Export([FromQuery] FicoWageratesQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoWageratesService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "工厂工资率", "工厂工资率");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}