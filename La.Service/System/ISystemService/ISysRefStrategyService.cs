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
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-24
    /// </summary>
    public interface ISysRefStrategyService : IBaseService<SysRefStrategy>
    {
        PagedInfo<SysRefStrategyDto> GetList(SysRefStrategyQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddSysRefStrategy(SysRefStrategy parm);

        int UpdateSysRefStrategy(SysRefStrategy parm);
        
        void TruncateSysRefStrategy();
    }
}
