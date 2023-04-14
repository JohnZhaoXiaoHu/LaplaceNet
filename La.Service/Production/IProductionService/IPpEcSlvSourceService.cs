using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 从源设变service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    public interface IPpEcSlvSourceService : IBaseService<PpEcSlvSource>
    {
        PagedInfo<PpEcSlvSourceDto> GetList(PpEcSlvSourceQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpEcSlvSource(PpEcSlvSource parm);

        int UpdatePpEcSlvSource(PpEcSlvSource parm);
        
        void TruncatePpEcSlvSource();
    }
}
