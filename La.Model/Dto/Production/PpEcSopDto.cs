using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// SOP查询对象
    /// @author Davis.Cheng
    /// @date 2023-05-03
    /// </summary>
    public class PpEcSopQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginEsIssueDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndEsIssueDate { get; set; }
        /// <summary>
        /// 描述 :设变No. 
        /// </summary>
        public string EsEcNo { get; set; }
        /// <summary>
        /// 描述 :机种 
        /// </summary>
        public string EsModel { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string EsItem { get; set; }
    }

    /// <summary>
    /// SOP输入输出对象
    /// </summary>
    public class PpEcSopDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public int EsId { get; set; }

        /// <summary>
        /// 描述 :发行日期 
        /// </summary>

        [ExcelColumn(Name = "发行日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIssueDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// </summary>

        [ExcelColumn(Name = "设变No.")]
        public string EsEcNo { get; set; }

        /// <summary>
        /// 描述 :输入日期 
        /// </summary>
        [Required(ErrorMessage = "输入日期不能为空")]

        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsEntryDate { get; set; }

        /// <summary>
        /// 描述 :担当者 
        /// </summary>

        [ExcelColumn(Name = "担当者")]
        public string EsAssigned { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// </summary>

        [ExcelColumn(Name = "机种")]
        public string EsModel { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>

        [ExcelColumn(Name = "物料")]
        public string EsItem { get; set; }

        /// <summary>
        /// 描述 :生技担当 
        /// </summary>

        [ExcelColumn(Name = "生技担当")]
        public string EsPeaAssigned { get; set; }

        /// <summary>
        /// 描述 :组立变更否 
        /// </summary>
        [Required(ErrorMessage = "组立变更否不能为空")]

        [ExcelColumn(Name = "组立变更否")]
        public string IsPeaModifysop { get; set; }

        /// <summary>
        /// 描述 :日期 
        /// </summary>

        [ExcelColumn(Name = "日期")]
        public string EsPeaDate { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsPeaNote { get; set; }

        /// <summary>
        /// 描述 :版本 
        /// </summary>

        [ExcelColumn(Name = "版本")]
        public string EmPeaDocNo { get; set; }

        /// <summary>
        /// 描述 :组立文件 
        /// </summary>

        [ExcelColumn(Name = "组立文件")]
        public string EmPeaDoc { get; set; }

        /// <summary>
        /// 描述 :组立确认 
        /// </summary>

        [ExcelColumn(Name = "组立确认")]
        public string EsPeaModifier { get; set; }

        /// <summary>
        /// 描述 :组立确认日期 
        /// </summary>

        [ExcelColumn(Name = "组立确认日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPeaModifyTime { get; set; }

        /// <summary>
        /// 描述 :生技担当 
        /// </summary>

        [ExcelColumn(Name = "生技担当")]
        public string EsPepAssigned { get; set; }

        /// <summary>
        /// 描述 :PCBA变更否 
        /// </summary>
        [Required(ErrorMessage = "PCBA变更否不能为空")]

        [ExcelColumn(Name = "PCBA变更否")]
        public string IsPepModifysop { get; set; }

        /// <summary>
        /// 描述 :日期 
        /// </summary>

        [ExcelColumn(Name = "日期")]
        public string EsPepDate { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsPepNote { get; set; }

        /// <summary>
        /// 描述 :版本 
        /// </summary>

        [ExcelColumn(Name = "版本")]
        public string EmPepDocNo { get; set; }

        /// <summary>
        /// 描述 :PCBA文件 
        /// </summary>

        [ExcelColumn(Name = "PCBA文件")]
        public string EmPepDoc { get; set; }

        /// <summary>
        /// 描述 :PCBA确认 
        /// </summary>

        [ExcelColumn(Name = "PCBA确认")]
        public string EsPepModifier { get; set; }

        /// <summary>
        /// 描述 :PCBA确认日期 
        /// </summary>

        [ExcelColumn(Name = "PCBA确认日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPepModifyTime { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// </summary>
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// </summary>
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// </summary>
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// </summary>
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// </summary>
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// </summary>
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
        /// </summary>
        [ExcelIgnore]
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>
        [ExcelIgnore]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}