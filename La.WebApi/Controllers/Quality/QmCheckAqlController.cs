using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.Quality.IQualityService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 抽样标准Controller
    /// 
    /// @tableName qm_check_aql
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-15
    /// </summary>
    [Verify]
    [Route("quality/QmCheckAql")]
    public class QmCheckAqlController : BaseController
    {
        /// <summary>
        /// 抽样标准接口
        /// </summary>
        private readonly IQmCheckAqlService _QmCheckAqlService;
        /// <summary>
        /// 抽样标准接口
        /// </summary>
        public QmCheckAqlController(IQmCheckAqlService QmCheckAqlService)
        {
            _QmCheckAqlService = QmCheckAqlService;
        }

        /// <summary>
        /// 查询抽样标准列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:checkaql:list")]
        public IActionResult QueryQmCheckAql([FromQuery] QmCheckAqlQueryDto parm)
        {
            var response = _QmCheckAqlService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询抽样标准详情
        /// </summary>
        /// <param name="QcaqlGuid"></param>
        /// <returns></returns>
        [HttpGet("{QcaqlGuid}")]
        [ActionPermissionFilter(Permission = "qm:checkaql:query")]
        public IActionResult GetQmCheckAql(string QcaqlGuid)
        {
            var response = _QmCheckAqlService.GetFirst(x => x.QcaqlGuid == QcaqlGuid);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:checkaql:add")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.INSERT)]
        public IActionResult AddQmCheckAql([FromBody] QmCheckAqlDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            // 校验输入项目是否唯一
            if (UserConstants.NOT_UNIQUE.Equals(_QmCheckAqlService.CheckEntryStringUnique(parm.QcaqlGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增抽样标准 '{parm.QcaqlGuid}'失败，输入的抽样标准已存在"));
            }
            var modal = parm.Adapt<QmCheckAql>().ToCreate(HttpContext);

            var response = _QmCheckAqlService.AddQmCheckAql(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:checkaql:edit")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateQmCheckAql([FromBody] QmCheckAqlDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<QmCheckAql>().ToUpdate(HttpContext);

            var response = _QmCheckAqlService.UpdateQmCheckAql(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除抽样标准
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "qm:checkaql:delete")]
        [Log(Title = "抽样标准", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteQmCheckAql(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _QmCheckAqlService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出抽样标准
        /// </summary>
        /// <returns></returns>
        [Log(Title = "抽样标准", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:checkaql:export")]
        public IActionResult Export([FromQuery] QmCheckAqlQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _QmCheckAqlService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "抽样标准", "抽样标准");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}