using System;
using La.Model;
using La.Model.Dto;
using La.Model.Production;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// oph从表
    /// service接口
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    public interface IPpOutputSlaveService : IBaseService<PpOutputSlave>
    {
        /// <summary>
        /// oph从表
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputSlaveDto> GetList(PpOutputSlaveQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>

        public string CheckEntryStringUnique(string entryString);

        /// <summary>
        /// oph从表
        /// 详情
        /// </summary>
        /// <param name="IfGuid"></param>
        /// <returns></returns>
        PpOutputSlave GetInfo(int PosId);

        /// <summary>
        /// oph从表
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int AddPpOutputSlave(PpOutputSlave parm);
        /// <summary>
        /// oph从表
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputSlave(PpOutputSlave parm);
  
        /// <summary>
        /// oph从表
        /// 清空
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>      
        bool TruncatePpOutputSlave();
    }
}
