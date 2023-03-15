using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Material.IMaterialService
{
    /// <summary>
    /// 常规物料数据service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    public interface IMmMaraService : IBaseService<MmMara>
    {
        PagedInfo<MmMaraDto> GetList(MmMaraQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddMmMara(MmMara parm);

        int UpdateMmMara(MmMara parm);
        
        void TruncateMmMara();
    }
}
