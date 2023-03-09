using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 原因类别，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [SugarTable("pp_cause_type")]
    public class PpCauseType
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long CtId { get; set; }

        /// <summary>
        /// 描述 :原因类别 
        /// 空值 :false 
        /// </summary>
        public string CtCauseType { get; set; }

        /// <summary>
        /// 描述 :原因名称ZH 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "ctCauseText_Zh")]
        public string CtcausetextZh { get; set; }

        /// <summary>
        /// 描述 :原因名称EN 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "ctCauseText_En")]
        public string CtcausetextEn { get; set; }

        /// <summary>
        /// 描述 :原因名称JA 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "ctCauseText_Ja")]
        public string CtcausetextJa { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDelete { get; set; }

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