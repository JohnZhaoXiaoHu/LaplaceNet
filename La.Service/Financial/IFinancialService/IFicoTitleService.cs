using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Financial.IFinancialService
{
    /// <summary>
    /// 会计科目service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    public interface IFicoTitleService : IBaseService<FicoTitle>
    {
        PagedInfo<FicoTitleDto> GetList(FicoTitleQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddFicoTitle(FicoTitle parm);

        int UpdateFicoTitle(FicoTitle parm);
        
        void TruncateFicoTitle();
    }
}
