using System;
using La.Model;
using La.Model.Dto;
using La.Model.Models;
using System.Collections.Generic;

namespace La.Service.Quality.IQualityService
{
    /// <summary>
    /// 抽样标准service接口
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    public interface IQmCheckAqlService : IBaseService<QmCheckAql>
    {
        PagedInfo<QmCheckAqlDto> GetList(QmCheckAqlQueryDto parm);

        /// <summary>
        /// 校验输入项目是否唯一
        /// </summary>
        /// <param name="entryString"></param>
        /// <returns></returns>
        public string CheckEntryStringUnique(string entryString);

        int AddQmCheckAql(QmCheckAql parm);

        int UpdateQmCheckAql(QmCheckAql parm);
        
        void TruncateQmCheckAql();
    }
}
