using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 生产班组，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-09
    /// </summary>
    [SugarTable("pp_lines")]
    public class PpLines
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long PlId { get; set; }

        /// <summary>
        /// 描述 :班组类别 
        /// 空值 :false 
        /// </summary>
        public string PlLineType { get; set; }

        /// <summary>
        /// 描述 :班组代码 
        /// 空值 :false 
        /// </summary>
        public string PlLineCode { get; set; }

        /// <summary>
        /// 描述 :班组名称_ZH 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "plLineName_Zh")]
        public string PllinenameZh { get; set; }

        /// <summary>
        /// 描述 :班组名称_EN 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "plLineName_En")]
        public string PllinenameEn { get; set; }

        /// <summary>
        /// 描述 :班组名称_JA 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "plLineName_Ja")]
        public string PllinenameJa { get; set; }

        /// <summary>
        /// 描述 :软件删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 : 
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