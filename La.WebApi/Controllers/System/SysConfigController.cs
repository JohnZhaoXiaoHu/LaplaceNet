using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Extensions;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;
using La.Model.Dto;
using La.Model.System;
using La.Model.System.Dto;
using La.Service.System;

namespace La.WebApi.Controllers.System
{
    /// <summary>
    /// 参数配置Controller
    /// </summary>
    [Verify]
    [Route("system/config")]
    public class SysConfigController : BaseController
    {
        /// <summary>
        /// 参数配置接口
        /// </summary>
        private readonly ISysConfigService _SysConfigService;
        /// <summary>
        /// 参数配置接口
        /// </summary>
        public SysConfigController(ISysConfigService SysConfigService)
        {
            _SysConfigService = SysConfigService;
        }

        /// <summary>
        /// 查询参数配置列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "system:config:list")]
        public IActionResult QuerySysConfig([FromQuery] SysConfigQueryDto parm)
        {
            var predicate = Expressionable.Create<SysConfig>();

            predicate = predicate.AndIF(!parm.ConfigType.IsEmpty(), m => m.ConfigType == parm.ConfigType);
            predicate = predicate.AndIF(!parm.ConfigName.IsEmpty(), m => m.ConfigName.Contains(parm.ConfigType));
            predicate = predicate.AndIF(!parm.ConfigKey.IsEmpty(), m => m.ConfigKey.Contains(parm.ConfigKey));
            predicate = predicate.AndIF(!parm.BeginTime.IsEmpty(), m => m.create_time >= parm.BeginTime);
            predicate = predicate.AndIF(!parm.BeginTime.IsEmpty(), m => m.create_time <= parm.EndTime);

            var response = _SysConfigService.GetPages(predicate.ToExpression(), parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 查询参数配置详情
        /// </summary>
        /// <param name="ConfigId"></param>
        /// <returns></returns>
        [HttpGet("{ConfigId}")]
        [ActionPermissionFilter(Permission = "system:config:query")]
        public IActionResult GetSysConfig(int ConfigId)
        {
            var response = _SysConfigService.GetId(ConfigId);

            return SUCCESS(response);
        }

        /// <summary>
        /// 根据参数键名查询参数值
        /// </summary>
        /// <param name="configKey"></param>
        /// <returns></returns>
        [HttpGet("configKey/{configKey}")]
        [AllowAnonymous]
        public IActionResult GetConfigKey(string configKey)
        {
            var response = _SysConfigService.Queryable().First(f => f.ConfigKey == configKey);

            return SUCCESS(response?.ConfigValue!);
        }

        /// <summary>
        /// 添加参数配置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "system:config:add")]
        [Log(Title = "参数配置添加", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSysConfig([FromBody] SysConfigDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求参数错误");
            }
            var model = parm.Adapt<SysConfig>().ToCreate(HttpContext);

            return SUCCESS(_SysConfigService.Insert(model, it => new
            {
                it.ConfigName,
                it.ConfigKey,
                it.ConfigValue,
                it.ConfigType,
                it.create_by,
                it.create_time,
                it.ReMark,
            }));
        }

        /// <summary>
        /// 更新参数配置
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "system:config:update")]
        [Log(Title = "参数配置修改", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSysConfig([FromBody] SysConfigDto parm)
        {
            if (parm == null)
            {
                throw new CustomException("请求实体不能为空");
            }
            var model = parm.Adapt<SysConfig>().ToUpdate(HttpContext);

            var response = _SysConfigService.Update(w => w.ConfigId == model.ConfigId, it => new SysConfig()
            {
                ConfigName = model.ConfigName,
                ConfigKey = model.ConfigKey,
                ConfigValue = model.ConfigValue,
                ConfigType = model.ConfigType,
                Update_by = model.Update_by,
                Update_time = model.Update_time,
                ReMark = model.ReMark
            });

            return SUCCESS(response);
        }

        /// <summary>
        /// 删除参数配置
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "system:config:remove")]
        [Log(Title = "参数配置删除", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSysConfig(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }
            int sysCount = _SysConfigService.Count(s => s.ConfigType == "Y" && idsArr.Contains(s.ConfigId));
            if (sysCount > 0) { return ToResponse(ApiResult.Error($"删除失败Id： 系统内置参数不能删除！")); }
            var response = _SysConfigService.Delete(idsArr);

            return SUCCESS(response);
        }
    }
}