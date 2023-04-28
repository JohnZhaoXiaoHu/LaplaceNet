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
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    public interface IEtDictService : IBaseService<EtDict>
    {
        PagedInfo<EtDictDto> GetList(EtDictQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddEtDict(EtDict parm);

        int UpdateEtDict(EtDict parm);
        
        void TruncateEtDict();
    }
}
