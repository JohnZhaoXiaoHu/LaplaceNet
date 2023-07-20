using System;
using La.Model;
using La.Model.Dto;
using La.Model.Sales;
using System.Collections.Generic;

namespace La.Service.Sales.ISalesService
{
    /// <summary>
    /// 客户信息service接口
    /// </summary>
    public interface ISdClientService : IBaseService<SdClient>
    {
        PagedInfo<SdClientDto> GetList(SdClientQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>

        public string CheckEntryStringUnique(string entryString);

        SdClient GetInfo(long ScId);

        int AddSdClient(SdClient parm);

        int UpdateSdClient(SdClient parm);
        
        bool TruncateSdClient();
    }
}
