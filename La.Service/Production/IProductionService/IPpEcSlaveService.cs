using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 从设变信息表service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-04-10
    /// </summary>
    public interface IPpEcSlaveService : IBaseService<PpEcSlave>
    {
        PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpEcSlave(PpEcSlave parm);

        int UpdatePpEcSlave(PpEcSlave parm);
        
        void TruncatePpEcSlave();
    }
}
