using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Material.IMaterialService
{
    /// <summary>
    /// 物料评估service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    public interface IMmMbewService : IBaseService<MmMbew>
    {
        PagedInfo<MmMbewDto> GetList(MmMbewQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddMmMbew(MmMbew parm);

        int UpdateMmMbew(MmMbew parm);
        
        void TruncateMmMbew();
    }
}
