using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// SOP确认，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-12
    /// </summary>
    [SugarTable("pp_ec_sop")]
    public class PpEcSop
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int EsId { get; set; }

        /// <summary>
        /// 描述 :发行日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsIssueDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// 空值 :true 
        /// </summary>
        public string EsEcNo { get; set; }

        /// <summary>
        /// 描述 :输入日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? EsEntryDate { get; set; }

        /// <summary>
        /// 描述 :担当者 
        /// 空值 :true 
        /// </summary>
        public string EsAssigned { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// 空值 :true 
        /// </summary>
        public string EsModel { get; set; }

        /// <summary>
        /// 描述 :生技担当 
        /// 空值 :true 
        /// </summary>
        public string EsPeaAssigned { get; set; }

        /// <summary>
        /// 描述 :组立变更否 
        /// 空值 :false 
        /// </summary>
        public string IsPeaModifysop { get; set; }

        /// <summary>
        /// 描述 :日期 
        /// 空值 :true 
        /// </summary>
        public string EsPeaDate { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsPeaNote { get; set; }

        /// <summary>
        /// 描述 :EsPeaModifier 
        /// 空值 :true 
        /// </summary>
        public string EsPeaModifier { get; set; }

        /// <summary>
        /// 描述 :EsPeaModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPeaModifyTime { get; set; }

        /// <summary>
        /// 描述 :生技担当 
        /// 空值 :true 
        /// </summary>
        public string EsPepAssigned { get; set; }

        /// <summary>
        /// 描述 :PCBA变更否 
        /// 空值 :false 
        /// </summary>
        public string IsPepModifysop { get; set; }

        /// <summary>
        /// 描述 :日期 
        /// 空值 :true 
        /// </summary>
        public string EsPepDate { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsPepNote { get; set; }

        /// <summary>
        /// 描述 :EsPepModifier 
        /// 空值 :true 
        /// </summary>
        public string EsPepModifier { get; set; }

        /// <summary>
        /// 描述 :EsPepModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPepModifyTime { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// 空值 :true 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
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