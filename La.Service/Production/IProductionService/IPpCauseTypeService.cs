using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 原因类别service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    public interface IPpCauseTypeService : IBaseService<PpCauseType>
    {
        PagedInfo<PpCauseTypeDto> GetList(PpCauseTypeQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpCauseType(PpCauseType parm);

        int UpdatePpCauseType(PpCauseType parm);
        
        void TruncatePpCauseType();
    }
}
