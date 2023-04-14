using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// SOP确认service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-12
    /// </summary>
    public interface IPpEcSopService : IBaseService<PpEcSop>
    {
        PagedInfo<PpEcSopDto> GetList(PpEcSopQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpEcSop(PpEcSop parm);

        int UpdatePpEcSop(PpEcSop parm);
        
        void TruncatePpEcSop();
    }
}
