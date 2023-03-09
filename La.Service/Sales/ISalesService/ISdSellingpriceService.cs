using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Sales.ISalesService
{
    /// <summary>
    /// 销售价格service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    public interface ISdSellingpriceService : IBaseService<SdSellingprice>
    {
        PagedInfo<SdSellingpriceDto> GetList(SdSellingpriceQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddSdSellingprice(SdSellingprice parm);

        int UpdateSdSellingprice(SdSellingprice parm);
        
        void TruncateSdSellingprice();
    }
}
