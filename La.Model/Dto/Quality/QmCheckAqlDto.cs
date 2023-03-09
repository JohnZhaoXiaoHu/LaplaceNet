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
        /// <summary>
        /// 描述 :Guid 
        /// </summary>
        [Required(ErrorMessage = "Guid不能为空")]

        [ExcelColumn(Name = "Guid")]

        public string QcaqlGuid { get; set; }

        /// <summary>
        /// 描述 :查检水平 
        /// </summary>
        [Required(ErrorMessage = "查检水平不能为空")]

        [ExcelColumn(Name = "查检水平")]

        public string QcaqlLevel { get; set; }

        /// <summary>
        /// 描述 :批量范围 
        /// </summary>
        [Required(ErrorMessage = "批量范围不能为空")]

        [ExcelColumn(Name = "批量范围")]

        public string QcaqlRange { get; set; }

        /// <summary>
        /// 描述 :最小值 
        /// </summary>
        [Required(ErrorMessage = "最小值不能为空")]

        [ExcelColumn(Name = "最小值")]

        public int QcaqlRangeMinmum { get; set; }

        /// <summary>
        /// 描述 :最大值 
        /// </summary>
        [Required(ErrorMessage = "最大值不能为空")]

        [ExcelColumn(Name = "最大值")]

        public int QcaqlRangeMaximum { get; set; }

        /// <summary>
        /// 描述 :样本码 
        /// </summary>
        [Required(ErrorMessage = "样本码不能为空")]

        [ExcelColumn(Name = "样本码")]

        public string QcaqlSamplesCode { get; set; }

        /// <summary>
        /// 描述 :抽样数 
        /// </summary>
        [Required(ErrorMessage = "抽样数不能为空")]

        [ExcelColumn(Name = "抽样数")]

        public int QcaqlSamplesQty { get; set; }

        /// <summary>
        /// 描述 :合格项 
        /// </summary>
        [Required(ErrorMessage = "合格项不能为空")]

        [ExcelColumn(Name = "合格项")]

        public int QcaqlAcQty { get; set; }

        /// <summary>
        /// 描述 :不合格项 
        /// </summary>
        [Required(ErrorMessage = "不合格项不能为空")]

        [ExcelColumn(Name = "不合格项")]

        public int QcaqlReQty { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public bool IsDeleted { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "ReMark")]

        public string ReMark { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



    }
}