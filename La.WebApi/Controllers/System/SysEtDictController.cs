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
using La.Infra.Extensions;
using Microsoft.AspNetCore.Authorization;
using La.Model;

namespace La.WebApi.Controllers
{
    /// <summary>
    /// 电子技术辞典Controller
    /// 
    /// @tableName sys_et_dict
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-10
    /// </summary>
    [Verify]
    [Route("system/EtDict")]
    public class SysEtDictController : BaseController
    {
        /// <summary>
        /// 电子技术辞典接口
        /// </summary>
        private readonly IEtDictService _SysEtDictService;

        public SysEtDictController(IEtDictService EtDictService)
        {
            _SysEtDictService = EtDictService;
        }

        /// <summary>
        /// 查询电子技术辞典列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sys:etdict:list")]
        public IActionResult QuerySysEtDict([FromQuery] EtDictQueryDto parm)
        {

            if (parm.ShowMode == 2)
            {
                PagedInfo<dynamic> pagedInfo = new()
                {
                    Result = _SysEtDictService.GetListToPivot(parm)
                };

                return SUCCESS(pagedInfo);
            }

            return SUCCESS(_SysEtDictService.GetList(parm));
        }

        //跟下面的冲突 GeSysEtDict(long Id)

        /// <summary>
        /// 查询电子技术辞典详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //[HttpGet("{Id}")]
        //[ActionPermissionFilter(Permission = "sys:etdict:query")]
        //public IActionResult GetSysEtDict(long Id)
        //{
        //    var response = _SysEtDictService.GetFirst(x => x.Id == Id);

        //    return SUCCESS(response);
        //}
        /// <summary>
        /// 查询多语言配置列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/{lang}")]
        [AllowAnonymous]
        public IActionResult QuerySysEtDicts(string lang)
        {
            var msgList = _SysEtDictService.GetSysEtDictList(new EtDictQueryDto() { EtLangcode = lang });

            return SUCCESS(_SysEtDictService.SetSysEtDict(msgList));
        }

        /// <summary>
        /// 查询多语言配置详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "system:etdict:query")]
        public IActionResult GeSysEtDict(long Id)
        {
            var response = _SysEtDictService.GetFirst(x => x.Id == Id);

            var list = _SysEtDictService.GetList(x => x.EtPhrase == response.EtPhrase);
            var vo = list.Adapt<List<EtDictDto>>();
            var modal = new EtDictDto() { EtPhrase = response.EtPhrase, EtDictList = vo };
            return SUCCESS(modal);
        }

        /// <summary>
        /// 查询多语言配置详情
        /// </summary>
        /// <param name="langKey"></param>
        /// <returns></returns>
        [HttpGet("key/{langKey}")]
        [ActionPermissionFilter(Permission = "system:etdict:query")]

            public IActionResult GetSysEtDictByKey(string langKey)
        {
            var list = _SysEtDictService.GetList(x => x.EtPhrase == langKey);
            var vo = list.Adapt<List<EtDictDto>>();
            var modal = new EtDictDto() { EtPhrase = langKey, EtDictList = vo };

            return SUCCESS(modal);
        }

        /// <summary>
        /// 更新多语言配置
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "system:etdict:edit")]
        [Log(Title = "多语言配置", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSysEtDict([FromBody] EtDictDto parm)
        {
            if (parm == null || parm.EtPhrase.IsEmpty())
            {
                throw new CustomException("请求实体不能为空");
            }

            _SysEtDictService.StorageSysEtDict(parm);

            return ToResponse(1);
        }

        /// <summary>
        /// 删除多语言配置
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "system:etdict:delete")]
        [Log(Title = "多语言配置", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysEtDict(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SysEtDictService.Delete(idsArr);

            return ToResponse(response);
        }
        /// <summary>
        /// 添加电子技术辞典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sys:etdict:add")]
        [Log(Title = "电子技术辞典", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSysEtDict([FromBody] EtDictDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
            if (UserConstants.NOT_UNIQUE.Equals(_SysEtDictService.CheckEntryStringUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增电子技术辞典 '{parm.Id}'失败，输入的电子技术辞典已存在"));
            }
            var modal = parm.Adapt<EtDict>().ToCreate(HttpContext);

            var response = _SysEtDictService.AddSysEtDict(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新电子技术辞典
        /// </summary>
        /// <returns></returns>
        //[HttpPut]
        //[ActionPermissionFilter(Permission = "sys:etdict:edit")]
        //[Log(Title = "电子技术辞典", BusinessType = BusinessType.UPDATE)]
        //public IActionResult UpdateSysEtDict([FromBody] EtDictDto parm)
        //{
        //    if (parm == null)
        //    {
        //        throw new CustomException("请求实体不能为空");
        //    }
        //    var modal = parm.Adapt<EtDict>().ToUpdate(HttpContext);

        //    var response = _SysEtDictService.UpdateSysEtDict(modal);

        //    return ToResponse(response);
        //}

        /// <summary>
        /// 删除电子技术辞典
        /// </summary>
        /// <returns></returns>
        //[HttpDelete("{ids}")]
        //[ActionPermissionFilter(Permission = "sys:etdict:delete")]
        //[Log(Title = "电子技术辞典", BusinessType = BusinessType.DELETE)]
        //public IActionResult DeleteSysEtDict(string ids)
        //{
        //    int[] idsArr = Tools.SpitIntArrary(ids);
        //    if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

        //    var response = _SysEtDictService.Delete(idsArr);

        //    return ToResponse(response);
        //}



    }
}