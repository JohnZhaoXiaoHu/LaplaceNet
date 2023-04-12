using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Financial.IFinancialService
{
    /// <summary>
    /// 部门消耗service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    public interface IFicoDeptConsumingService : IBaseService<FicoDeptConsuming>
    {
        PagedInfo<FicoDeptConsumingDto> GetList(FicoDeptConsumingQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddFicoDeptConsuming(FicoDeptConsuming parm);

        int UpdateFicoDeptConsuming(FicoDeptConsuming parm);
        
        void TruncateFicoDeptConsuming();
    }
}
