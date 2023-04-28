using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Models;
using La.Model.System;
using La.Service.System.ISystemService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 电子辞典Controller
    /// 
    /// @tableName sys_et_dict
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    [Verify]
    [Route("System/SysEtDict")]
    public class EtDictController : BaseController
    {
        /// <summary>
        /// 电子辞典接口
        /// </summary>
        private readonly IEtDictService _EtDictService;
        /// <summary>
        /// 电子辞典Controller
        /// </summary>
        public EtDictController(IEtDictService EtDictService)
        {
            _EtDictService = EtDictService;
        }

        /// <summary>
        /// 查询电子辞典列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sys:etdict:list")]
        public IActionResult QueryEtDict([FromQuery] EtDictQueryDto parm)
        {
            var response = _EtDictService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询电子辞典详情
        /// </summary>
        /// <param name="EtGuid"></param>
        /// <returns></returns>
        [HttpGet("{EtGuid}")]
        [ActionPermissionFilter(Permission = "sys:etdict:query")]
        public IActionResult GetEtDict(long EtGuid)
        {
            var response = _EtDictService.GetFirst(x => x.EtGuid == EtGuid);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加电子辞典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sys:etdict:add")]
        [Log(Title = "电子辞典", BusinessType = BusinessType.INSERT)]
        public IActionResult AddEtDict([FromBody] EtDictDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_EtDictService.CheckEntryStringUnique(parm.EtGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增电子辞典 '{parm.EtGuid}'失败，输入的电子辞典已存在"));
            }
            var modal = parm.Adapt<EtDict>().ToCreate(HttpContext);

            var response = _EtDictService.AddEtDict(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新电子辞典
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sys:etdict:edit")]
        [Log(Title = "电子辞典", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateEtDict([FromBody] EtDictDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<EtDict>().ToUpdate(HttpContext);

            var response = _EtDictService.UpdateEtDict(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除电子辞典
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sys:etdict:delete")]
        [Log(Title = "电子辞典", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteEtDict(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _EtDictService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出电子辞典
        /// </summary>
        /// <returns></returns>
        [Log(Title = "电子辞典", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sys:etdict:export")]
        public IActionResult Export([FromQuery] EtDictQueryDto parm)
        {
            parm.PageSize = 100000;
            var list = _EtDictService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "电子辞典", "电子辞典");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空电子辞典
        /// </summary>
        /// <returns></returns>
        [Log(Title = "电子辞典", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "sys:etdict:delete")]
        [HttpDelete("clean")]
        public ApiResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ApiResult.Error("操作失败");
            }
            _EtDictService.TruncateEtDict();

            return ToJson(1);
        }

    }
}