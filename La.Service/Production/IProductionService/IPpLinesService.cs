using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 生产班组service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    public interface IPpLinesService : IBaseService<PpLines>
    {
        PagedInfo<PpLinesDto> GetList(PpLinesQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpLines(PpLines parm);

        int UpdatePpLines(PpLines parm);
        
        void TruncatePpLines();
    }
}
