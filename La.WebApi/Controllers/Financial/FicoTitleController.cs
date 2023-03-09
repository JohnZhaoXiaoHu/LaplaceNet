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
    /// 会计科目Controller
    /// 
    /// @tableName fico_title
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [Verify]
    [Route("financial/FicoTitle")]
    public class FicoTitleController : BaseController
    {
        /// <summary>
        /// 会计科目接口
        /// </summary>
        private readonly IFicoTitleService _FicoTitleService;
        /// <summary>
        /// 会计科目Controller
        /// </summary>
        public FicoTitleController(IFicoTitleService FicoTitleService)
        {
            _FicoTitleService = FicoTitleService;
        }

        /// <summary>
        /// 查询会计科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:title:list")]
        public IActionResult QueryFicoTitle([FromQuery] FicoTitleQueryDto parm)
        {
            var response = _FicoTitleService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询会计科目详情
        /// </summary>
        /// <param name="FtId"></param>
        /// <returns></returns>
        [HttpGet("{FtId}")]
        [ActionPermissionFilter(Permission = "fico:title:query")]
        public IActionResult GetFicoTitle(long FtId)
        {
            var response = _FicoTitleService.GetFirst(x => x.FtId == FtId);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加会计科目
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:title:add")]
        [Log(Title = "会计科目", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoTitle([FromBody] FicoTitleDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_FicoTitleService.CheckEntryStringUnique(parm.FtId.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增会计科目 '{parm.FtId}'失败，输入的会计科目已存在"));
            }
            var modal = parm.Adapt<FicoTitle>().ToCreate(HttpContext);

            var response = _FicoTitleService.AddFicoTitle(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新会计科目
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:title:edit")]
        [Log(Title = "会计科目", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoTitle([FromBody] FicoTitleDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<FicoTitle>().ToUpdate(HttpContext);

            var response = _FicoTitleService.UpdateFicoTitle(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除会计科目
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "fico:title:delete")]
        [Log(Title = "会计科目", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoTitle(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _FicoTitleService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出会计科目
        /// </summary>
        /// <returns></returns>
        [Log(Title = "会计科目", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:title:export")]
        public IActionResult Export([FromQuery] FicoTitleQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _FicoTitleService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "会计科目", "会计科目");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}