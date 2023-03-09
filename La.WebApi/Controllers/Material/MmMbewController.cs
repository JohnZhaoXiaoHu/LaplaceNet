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
    /// 物料评估Controller
    /// 
    /// @tableName mm_mbew
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [Verify]
    [Route("material/MmMbew")]
    public class MmMbewController : BaseController
    {
        /// <summary>
        /// 物料评估接口
        /// </summary>
        private readonly IMmMbewService _MmMbewService;
        /// <summary>
        /// 物料评估Controller
        /// </summary>
        public MmMbewController(IMmMbewService MmMbewService)
        {
            _MmMbewService = MmMbewService;
        }

        /// <summary>
        /// 查询物料评估列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "mm:mbew:list")]
        public IActionResult QueryMmMbew([FromQuery] MmMbewQueryDto parm)
        {
            var response = _MmMbewService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询物料评估详情
        /// </summary>
        /// <param name="MbewID"></param>
        /// <returns></returns>
        [HttpGet("{MbewID}")]
        [ActionPermissionFilter(Permission = "mm:mbew:query")]
        public IActionResult GetMmMbew(int MbewID)
        {
            var response = _MmMbewService.GetFirst(x => x.MbewID == MbewID);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加物料评估
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "mm:mbew:add")]
        [Log(Title = "物料评估", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMmMbew([FromBody] MmMbewDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_MmMbewService.CheckEntryStringUnique(parm.MbewID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增物料评估 '{parm.MbewID}'失败，输入的物料评估已存在"));
            }
            var modal = parm.Adapt<MmMbew>().ToCreate(HttpContext);

            var response = _MmMbewService.AddMmMbew(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新物料评估
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "mm:mbew:edit")]
        [Log(Title = "物料评估", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMmMbew([FromBody] MmMbewDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<MmMbew>().ToUpdate(HttpContext);

            var response = _MmMbewService.UpdateMmMbew(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除物料评估
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "mm:mbew:delete")]
        [Log(Title = "物料评估", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMmMbew(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _MmMbewService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出物料评估
        /// </summary>
        /// <returns></returns>
        [Log(Title = "物料评估", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "mm:mbew:export")]
        public IActionResult Export([FromQuery] MmMbewQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _MmMbewService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "物料评估", "物料评估");
            return ExportExcel(result.Item2, result.Item1);
        }


    }
}