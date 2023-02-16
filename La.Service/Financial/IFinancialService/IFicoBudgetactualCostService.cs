using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Financial.IFinancialService
{
    /// <summary>
    /// 预算实际明细service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    public interface IFicoBudgetactualCostService : IBaseService<FicoBudgetactualCost>
    {
        PagedInfo<FicoBudgetactualCostDto> GetList(FicoBudgetactualCostQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddFicoBudgetactualCost(FicoBudgetactualCost parm);

        int UpdateFicoBudgetactualCost(FicoBudgetactualCost parm);
        
        void TruncateFicoBudgetactualCost();
    }
}
