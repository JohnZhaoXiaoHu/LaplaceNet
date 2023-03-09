using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 电子辞典，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [SugarTable("sys_et_dict")]
    public class SysEtDict
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long EtGuid { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// 空值 :false 
        /// </summary>
        public string EtType { get; set; }

        /// <summary>
        /// 描述 :字母 
        /// 空值 :false 
        /// </summary>
        public string EtLetter { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// 空值 :false 
        /// </summary>
        public string EtLangKey { get; set; }

        /// <summary>
        /// 描述 :短语 
        /// 空值 :false 
        /// </summary>
        public string EtPhrase { get; set; }

        /// <summary>
        /// 描述 :解释 
        /// 空值 :false 
        /// </summary>
        public string EtExplain { get; set; }

        /// <summary>
        /// 描述 :隶属范围 
        /// 空值 :true 
        /// </summary>
        public string EtArea { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}