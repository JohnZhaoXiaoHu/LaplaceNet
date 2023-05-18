using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Office.IOfficeService
{
    /// <summary>
    /// 单据编码service接口
    ///
    /// @author Davis.Ching
    /// @date 2023-05-16
    /// </summary>
    public interface IOfficeNumberingRulesService : IBaseService<OfficeNumberingRules>
    {
        PagedInfo<OfficeNumberingRulesDto> GetList(OfficeNumberingRulesQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddOfficeNumberingRules(OfficeNumberingRules parm);

        int UpdateOfficeNumberingRules(OfficeNumberingRules parm);
        
        void TruncateOfficeNumberingRules();
    }
}
