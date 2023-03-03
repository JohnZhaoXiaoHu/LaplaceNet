using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Sales.ISalesService
{
    /// <summary>
    /// 顾客信息service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-03
    /// </summary>
    public interface ISdCustomerService : IBaseService<SdCustomer>
    {
        PagedInfo<SdCustomerDto> GetList(SdCustomerQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddSdCustomer(SdCustomer parm);

        int UpdateSdCustomer(SdCustomer parm);
        
        void TruncateSdCustomer();
    }
}
