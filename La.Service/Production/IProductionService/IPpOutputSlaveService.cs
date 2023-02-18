using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// oph从表service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-18
    /// </summary>
    public interface IPpOutputSlaveService : IBaseService<PpOutputSlave>
    {
        PagedInfo<PpOutputSlaveDto> GetList(PpOutputSlaveQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpOutputSlave(PpOutputSlave parm);

        int UpdatePpOutputSlave(PpOutputSlave parm);
        
        void TruncatePpOutputSlave();
    }
}
