using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 工厂工资率查询对象
    /// </summary>
    public class FicoWageratesQueryDto : PagerInfo 
    {
        public string FwYm { get; set; }
        public string FwPlant { get; set; }
    }

    /// <summary>
    /// 工厂工资率输入输出对象
    /// </summary>
    public class FicoWageratesDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public int FwId { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        public string FwYm { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        public string FwPlant { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        public string FwCcy { get; set; }

        [Required(ErrorMessage = "销售额不能为空")]
        [ExcelColumn(Name = "销售额")]
        public decimal FwSalesVolume { get; set; }

        [Required(ErrorMessage = "工作天数不能为空")]
        [ExcelColumn(Name = "工作天数")]
        public decimal FwWorkingDays { get; set; }

        [Required(ErrorMessage = "直接工资率不能为空")]
        [ExcelColumn(Name = "直接工资率")]
        public decimal FwDirectWageRate { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        [ExcelColumn(Name = "直接人数")]
        public decimal FwDirect { get; set; }

        [Required(ErrorMessage = "直接加班费不能为空")]
        [ExcelColumn(Name = "直接加班费")]
        public decimal FwDirectOverTime { get; set; }

        [Required(ErrorMessage = "直接工资不能为空")]
        [ExcelColumn(Name = "直接工资")]
        public decimal FwDirectWages { get; set; }

        [Required(ErrorMessage = "间接工资率不能为空")]
        [ExcelColumn(Name = "间接工资率")]
        public decimal FwInDirectWageRate { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        public decimal FwInDirect { get; set; }

        [Required(ErrorMessage = "间接加班费不能为空")]
        [ExcelColumn(Name = "间接加班费")]
        public decimal FwInDirectOverTime { get; set; }

        [Required(ErrorMessage = "间接工资不能为空")]
        [ExcelColumn(Name = "间接工资")]
        public decimal FwInDirectWages { get; set; }

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