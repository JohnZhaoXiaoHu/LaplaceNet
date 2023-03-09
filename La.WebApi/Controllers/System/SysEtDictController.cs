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
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [Verify]
    [Route("system/SysEtDict")]
    public class SysEtDictController : BaseController
    {
        /// <summary>
        /// 电子辞典接口
        /// </summary>
        private readonly ISysEtDictService _SysEtDictService;
        /// <summary>
        /// 电子辞典Controller
        /// </summary>
        public SysEtDictController(ISysEtDictService SysEtDictService)
        {
            _SysEtDictService = SysEtDictService;
        }

        /// <summary>
        /// 查询电子辞典列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sys:etdict:list")]
        public IActionResult QuerySysEtDict([FromQuery] SysEtDictQueryDto parm)
        {
            var response = _SysEtDictService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询电子辞典详情
        /// </summary>
        /// <param name="EtGuid"></param>
        /// <returns></returns>
        [HttpGet("{EtGuid}")]
        [ActionPermissionFilter(Permission = "sys:etdict:query")]
        public IActionResult GetSysEtDict(long EtGuid)
        {
            var response = _SysEtDictService.GetFirst(x => x.EtGuid == EtGuid);
            
            return SUCCESS(response);
        }

        /// <summary>
        /// 添加电子辞典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sys:etdict:add")]
        [Log(Title = "电子辞典", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSysEtDict([FromBody] SysEtDictDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }

           // 校验输入项目是否唯一

            if (UserConstants.NOT_UNIQUE.Equals(_SysEtDictService.CheckEntryStringUnique(parm.EtGuid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增电子辞典 '{parm.EtGuid}'失败，输入的电子辞典已存在"));
            }
            var modal = parm.Adapt<SysEtDict>().ToCreate(HttpContext);

            var response = _SysEtDictService.AddSysEtDict(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新电子辞典
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sys:etdict:edit")]
        [Log(Title = "电子辞典", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSysEtDict([FromBody] SysEtDictDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var modal = parm.Adapt<SysEtDict>().ToUpdate(HttpContext);

            var response = _SysEtDictService.UpdateSysEtDict(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除电子辞典
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sys:etdict:delete")]
        [Log(Title = "电子辞典", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysEtDict(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysEtDictService.Delete(idsArr);

            return ToResponse(response);
        }



    }
}