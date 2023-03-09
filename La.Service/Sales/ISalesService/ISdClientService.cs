using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Sales.ISalesService
{
    /// <summary>
    /// 客户信息service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
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

        int AddSdClient(SdClient parm);

        int UpdateSdClient(SdClient parm);
        
        void TruncateSdClient();
    }
}
