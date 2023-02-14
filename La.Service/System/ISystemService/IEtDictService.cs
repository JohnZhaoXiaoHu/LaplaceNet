using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.System.ISystemService
{
    /// <summary>
    /// 电子技术辞典service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-10
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

        List<EtDict> GetSysEtDictList(EtDictQueryDto parm);
        dynamic GetListToPivot(EtDictQueryDto parm);
        void StorageSysEtDict(EtDictDto parm);
        Dictionary<string, object> SetSysEtDict(List<EtDict> msgList);


        int AddSysEtDict(EtDict parm);

        int UpdateSysEtDict(EtDict parm);
        
        void TruncateSysEtDict();
    }
}
