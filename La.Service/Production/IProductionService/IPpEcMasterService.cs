using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 主设变service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-28
    /// </summary>
    public interface IPpEcMasterService : IBaseService<PpEcMaster>
    {
        PagedInfo<PpEcMasterDto> GetList(PpEcMasterQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpEcMaster(PpEcMaster parm);

        int UpdatePpEcMaster(PpEcMaster parm);
        
        void TruncatePpEcMaster();
    }
}
