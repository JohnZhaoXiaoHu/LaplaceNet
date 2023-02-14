using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 电子技术辞典，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-10
    /// </summary>
    [SugarTable("sys_et_dict")]
    public class EtDict
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :字母 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "et_Letter")]
        public string EtLetter { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "et_LangCode")]
        public string EtLangcode { get; set; }

        /// <summary>
        /// 描述 :短语 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "et_Phrase")]
        public string EtPhrase { get; set; }

        /// <summary>
        /// 描述 :解释 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "et_Explain")]
        public string EtExplain { get; set; }

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