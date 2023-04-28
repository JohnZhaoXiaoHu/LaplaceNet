using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Production.IProductionService
{
    /// <summary>
    /// 新旧物料service接口
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    public interface IPpEcDigestService : IBaseService<PpEcDigest>
    {
        PagedInfo<PpEcDigestDto> GetList(PpEcDigestQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddPpEcDigest(PpEcDigest parm);

        int UpdatePpEcDigest(PpEcDigest parm);
        
        void TruncatePpEcDigest();
    }
}
