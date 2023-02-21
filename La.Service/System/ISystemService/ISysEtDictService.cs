using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.System.ISystemService
{
    /// <summary>
    /// 电子辞典service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-18
    /// </summary>
    public interface ISysEtDictService : IBaseService<SysEtDict>
    {
        PagedInfo<SysEtDictDto> GetList(SysEtDictQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddSysEtDict(SysEtDict parm);

        int UpdateSysEtDict(SysEtDict parm);
        
        void TruncateSysEtDict();
    }
}
