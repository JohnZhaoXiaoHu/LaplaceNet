using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// oph主表service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-12
    /// </summary>
    public interface IPpOutputMasterService : IBaseService<PpOutputMaster>
    {
        PagedInfo<PpOutputMasterDto> GetList(PpOutputMasterQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpOutputMaster(PpOutputMaster parm);

        int UpdatePpOutputMaster(PpOutputMaster parm);
        
        void TruncatePpOutputMaster();
    }
}
