using La.Infra;
using La.Infra.Attribute;
using La.Infra.Enums;
using La.Infra.Model;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using La.Model.Dto;
using La.Model.Sales;
using La.Service.Sales.ISalesService;
using La.WebApi.Extensions;
using La.WebApi.Filters;
using La.Common;

//创建时间：2023-07-20
namespace La.WebApi.Controllers
{
    /// <summary>
    /// 客户信息
    /// </summary>
    [Verify]
    [Route("sales/SdClient")]
    public class SdClientController : BaseController
    {
        /// <summary>
        /// 客户信息接口
        /// </summary>
        private readonly ISdClientService _SdClientService;

        public SdClientController(ISdClientService SdClientService)
        {
            _SdClientService = SdClientService;
        }

        /// <summary>
        /// 查询客户信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "sd:client:list")]
        public IActionResult QuerySdClient([FromQuery] SdClientQueryDto parm)
        {
            var response = _SdClientService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询客户信息详情
        /// </summary>
        /// <param name="ScId"></param>
        /// <returns></returns>
        [HttpGet("{ScId}")]
        [ActionPermissionFilter(Permission = "sd:client:query")]
        public IActionResult GetSdClient(long ScId)
        {
            var response = _SdClientService.GetInfo(ScId);
            
            var info = response.Adapt<SdClient>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加客户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "sd:client:add")]
        [Log(Title = "客户信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSdClient([FromBody] SdClientDto parm)
        {
            var modal = parm.Adapt<SdClient>().ToCreate(HttpContext);

            var response = _SdClientService.AddSdClient(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "sd:client:edit")]
        [Log(Title = "客户信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSdClient([FromBody] SdClientDto parm)
        {
            var modal = parm.Adapt<SdClient>().ToUpdate(HttpContext);
            var response = _SdClientService.UpdateSdClient(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "sd:client:delete")]
        [Log(Title = "客户信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSdClient(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SdClientService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 导出客户信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "客户信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "sd:client:export")]
        public IActionResult Export([FromQuery] SdClientQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SdClientService.GetList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "客户信息", "客户信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空客户信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "客户信息", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "sd:client:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_SdClientService.TruncateSdClient());
        }

    }
}