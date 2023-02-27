using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 生产工单service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-25
    /// </summary>
    public interface IPpMfgOrderService : IBaseService<PpMfgOrder>
    {
        PagedInfo<PpMfgOrderDto> GetList(PpMfgOrderQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpMfgOrder(PpMfgOrder parm);

        int UpdatePpMfgOrder(PpMfgOrder parm);
        
        void TruncatePpMfgOrder();
    }
}
