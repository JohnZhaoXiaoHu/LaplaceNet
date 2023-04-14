using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 主源设变service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    public interface IPpEcMaSourceService : IBaseService<PpEcMaSource>
    {
        PagedInfo<PpEcMaSourceDto> GetList(PpEcMaSourceQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpEcMaSource(PpEcMaSource parm);

        int UpdatePpEcMaSource(PpEcMaSource parm);
        
        void TruncatePpEcMaSource();
    }
}
