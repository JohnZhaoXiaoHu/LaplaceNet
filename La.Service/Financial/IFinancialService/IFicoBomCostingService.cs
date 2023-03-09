using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Financial.IFinancialService
{
    /// <summary>
    /// bom成本核算service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    public interface IFicoBomCostingService : IBaseService<FicoBomCosting>
    {
        PagedInfo<FicoBomCostingDto> GetList(FicoBomCostingQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddFicoBomCosting(FicoBomCosting parm);

        int UpdateFicoBomCosting(FicoBomCosting parm);
        
        void TruncateFicoBomCosting();
    }
}
