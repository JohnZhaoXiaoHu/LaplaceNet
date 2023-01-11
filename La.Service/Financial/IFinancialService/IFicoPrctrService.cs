using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Financial.IFinancialService
{
    /// <summary>
    /// 利润中心service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-06
    /// </summary>
    public interface IFicoPrctrService : IBaseService<FicoPrctr>
    {
        PagedInfo<FicoPrctrDto> GetList(FicoPrctrQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddFicoPrctr(FicoPrctr parm);

        int UpdateFicoPrctr(FicoPrctr parm);
        
        void TruncateFicoPrctr();
    }
}
