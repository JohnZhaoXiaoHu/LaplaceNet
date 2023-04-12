using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 会计科目，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    [SugarTable("fico_title")]
    public class FicoTitle
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long FtId { get; set; }

        /// <summary>
        /// 描述 :公司名称 
        /// 空值 :false 
        /// </summary>
        public string FtCorpCode { get; set; }

        /// <summary>
        /// 描述 :科目代码 
        /// 空值 :false 
        /// </summary>
        public string FtTitleCode { get; set; }

        /// <summary>
        /// 描述 :科目名称_ZH 
        /// 空值 :false 
        /// </summary>
        public string FtTitleName { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// 空值 :false 
        /// </summary>
        public string FtTitleLang { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}