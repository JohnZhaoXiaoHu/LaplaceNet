using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Financial.IFinancialService
{
    /// <summary>
    /// 汇率表service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    public interface IFicoExchangeRateService : IBaseService<FicoExchangeRate>
    {
        PagedInfo<FicoExchangeRateDto> GetList(FicoExchangeRateQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddFicoExchangeRate(FicoExchangeRate parm);

        int UpdateFicoExchangeRate(FicoExchangeRate parm);
        
        void TruncateFicoExchangeRate();
    }
}
