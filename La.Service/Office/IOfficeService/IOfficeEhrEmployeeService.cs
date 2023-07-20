using System;
using La.Model;
using La.Model.Dto;
using La.Model.Office;
using System.Collections.Generic;

namespace La.Service.Office.IOfficeService
{
    /// <summary>
    /// 人事信息
    /// service接口
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    public interface IOfficeEhrEmployeeService : IBaseService<OfficeEhrEmployee>
    {
        /// <summary>
        /// 人事信息
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<OfficeEhrEmployeeDto> GetList(OfficeEhrEmployeeQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>

        public string CheckEntryStringUnique(string entryString);

        /// <summary>
        /// 人事信息
        /// 详情
        /// </summary>
        /// <param name="IfGuid"></param>
        /// <returns></returns>
        OfficeEhrEmployee GetInfo(string EeId);

        /// <summary>
        /// 人事信息
        /// 新增
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int AddOfficeEhrEmployee(OfficeEhrEmployee parm);
        /// <summary>
        /// 人事信息
        /// 修改编辑
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateOfficeEhrEmployee(OfficeEhrEmployee parm);
  
        /// <summary>
        /// 人事信息
        /// 清空
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>      
        bool TruncateOfficeEhrEmployee();
    }
}
