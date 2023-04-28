using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.System.ISystemService
{
    /// <summary>
    /// 单据编码service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    public interface IRefStrategyService : IBaseService<RefStrategy>
    {
        PagedInfo<RefStrategyDto> GetList(RefStrategyQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddRefStrategy(RefStrategy parm);

        int UpdateRefStrategy(RefStrategy parm);
        
        void TruncateRefStrategy();
    }
}
