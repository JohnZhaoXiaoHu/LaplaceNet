using System;
using La.Model;
using La.Model.Dto;
using La.Model.Office;
using System.Collections.Generic;

namespace La.Service.Office.IOfficeService
{
    /// <summary>
    /// 计算公式
    /// service接口
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    public interface IInstFormulaService : IBaseService<InstFormula>
    {
        /// <summary>
        /// 计算公式
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstFormulaDto> GetList(InstFormulaQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>

        public string CheckEntryStringUnique(string entryString);

        /// <summary>
        /// 计算公式
        /// 详情
        /// </summary>
        /// <param name="IfGuid"></param>
        /// <returns></returns>
        InstFormula GetInfo(string IfGuid);

        /// <summary>
        /// 计算公式
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int AddInstFormula(InstFormula parm);
        /// <summary>
        /// 计算公式
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateInstFormula(InstFormula parm);
  
        /// <summary>
        /// 计算公式
        /// 清空
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>      
        bool TruncateInstFormula();
    }
}
