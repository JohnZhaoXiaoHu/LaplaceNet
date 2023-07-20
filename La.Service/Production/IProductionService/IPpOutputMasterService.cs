using System;
using La.Model;
using La.Model.Dto;
using La.Model.Production;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// oph主表
    /// service接口
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    public interface IPpOutputMasterService : IBaseService<PpOutputMaster>
    {
        /// <summary>
        /// oph主表
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputMasterDto> GetList(PpOutputMasterQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>

        public string CheckEntryStringUnique(string entryString);

        /// <summary>
        /// oph主表
        /// 详情
        /// </summary>
        /// <param name="IfGuid"></param>
        /// <returns></returns>
        PpOutputMaster GetInfo(int PomId);

        /// <summary>
        /// oph主表
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int AddPpOutputMaster(PpOutputMaster parm);
        /// <summary>
        /// oph主表
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputMaster(PpOutputMaster parm);
  
        /// <summary>
        /// oph主表
        /// 清空
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>      
        bool TruncatePpOutputMaster();
    }
}
