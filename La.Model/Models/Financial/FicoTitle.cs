using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 会计科目，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
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
        [SugarColumn(ColumnName = "ftTitleName_Zh")]
        public string FttitlenameZh { get; set; }

        /// <summary>
        /// 描述 :科目名称_EN 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "ftTitleName_En")]
        public string FttitlenameEn { get; set; }

        /// <summary>
        /// 描述 :科目名称_JA 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "ftTitleName_Ja")]
        public string FttitlenameJa { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 :说明 
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