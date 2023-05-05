using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Office.IOfficeService
{
    /// <summary>
    /// 人事信息service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-05-04
    /// </summary>
    public interface IEhrEmployeeService : IBaseService<EhrEmployee>
    {
        PagedInfo<EhrEmployeeDto> GetList(EhrEmployeeQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddEhrEmployee(EhrEmployee parm);

        int UpdateEhrEmployee(EhrEmployee parm);
        
        void TruncateEhrEmployee();
    }
}
