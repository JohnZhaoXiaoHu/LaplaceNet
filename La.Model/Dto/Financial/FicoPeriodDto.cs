using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 财务期间查询对象
    /// </summary>
    public class FicoPeriodQueryDto : PagerInfo 
    {
        public string FpYm { get; set; }
    }

    /// <summary>
    /// 财务期间输入输出对象
    /// </summary>
    public class FicoPeriodDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public int FpId { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        public string FpFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        public string FpYm { get; set; }

        [Required(ErrorMessage = "年不能为空")]
        [ExcelColumn(Name = "年")]
        public string FpYear { get; set; }

        [Required(ErrorMessage = "月不能为空")]
        [ExcelColumn(Name = "月")]
        public string FpMonth { get; set; }

        [Required(ErrorMessage = "季度不能为空")]
        [ExcelColumn(Name = "季度")]
        public string FpQuarter { get; set; }

        [Required(ErrorMessage = "不能为空")]
        [ExcelColumn(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }

        [ExcelIgnore]
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