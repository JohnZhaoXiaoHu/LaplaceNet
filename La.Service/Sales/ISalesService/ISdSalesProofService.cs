using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Sales.ISalesService
{
    /// <summary>
    /// 销售凭证service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-03
    /// </summary>
    public interface ISdSalesProofService : IBaseService<SdSalesProof>
    {
        PagedInfo<SdSalesProofDto> GetList(SdSalesProofQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddSdSalesProof(SdSalesProof parm);

        int UpdateSdSalesProof(SdSalesProof parm);
        
        void TruncateSdSalesProof();
    }
}
