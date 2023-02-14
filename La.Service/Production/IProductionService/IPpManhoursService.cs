using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 标准工时service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-09
    /// </summary>
    public interface IPpManhoursService : IBaseService<PpManhours>
    {
        PagedInfo<PpManhoursDto> GetList(PpManhoursQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpManhours(PpManhours parm);

        int UpdatePpManhours(PpManhours parm);
        
        void TruncatePpManhours();
    }
}
