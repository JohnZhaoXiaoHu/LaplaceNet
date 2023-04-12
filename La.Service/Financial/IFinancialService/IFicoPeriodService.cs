using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Financial.IFinancialService
{
    /// <summary>
    /// 财务期间service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    public interface IFicoPeriodService : IBaseService<FicoPeriod>
    {
        PagedInfo<FicoPeriodDto> GetList(FicoPeriodQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddFicoPeriod(FicoPeriod parm);

        int UpdateFicoPeriod(FicoPeriod parm);
        
        void TruncateFicoPeriod();
    }
}
