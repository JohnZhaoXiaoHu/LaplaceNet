using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 抽样标准查询对象
    /// </summary>
    public class QmCheckAqlQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 抽样标准输入输出对象
    /// </summary>
    public class QmCheckAqlDto
    {
        [Required(ErrorMessage = "Guid不能为空")]
        [ExcelColumn(Name = "Guid")]
        public string QcaqlGuid { get; set; }

        [Required(ErrorMessage = "查检水平不能为空")]
        [ExcelColumn(Name = "查检水平")]
        public string QcaqlLevel { get; set; }

        [Required(ErrorMessage = "批量范围不能为空")]
        [ExcelColumn(Name = "批量范围")]
        public string QcaqlRange { get; set; }

        [Required(ErrorMessage = "最小值不能为空")]
        [ExcelColumn(Name = "最小值")]
        public int QcaqlRangeMinmum { get; set; }

        [Required(ErrorMessage = "最大值不能为空")]
        [ExcelColumn(Name = "最大值")]
        public int QcaqlRangeMaximum { get; set; }

        [Required(ErrorMessage = "样本码不能为空")]
        [ExcelColumn(Name = "样本码")]
        public string QcaqlSamplesCode { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        [ExcelColumn(Name = "抽样数")]
        public int QcaqlSamplesQty { get; set; }

        [Required(ErrorMessage = "合格项不能为空")]
        [ExcelColumn(Name = "合格项")]
        public int QcaqlAcQty { get; set; }

        [Required(ErrorMessage = "不合格项不能为空")]
        [ExcelColumn(Name = "不合格项")]
        public int QcaqlReQty { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        [ExcelColumn(Name = "ReMark")]
        public string ReMark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}