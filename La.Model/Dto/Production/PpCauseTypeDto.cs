using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 原因类别查询对象
    /// </summary>
    public class PpCauseTypeQueryDto : PagerInfo 
    {
        public string CtCauseType { get; set; }
    }

    /// <summary>
    /// 原因类别输入输出对象
    /// </summary>
    public class PpCauseTypeDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long CtId { get; set; }

        [Required(ErrorMessage = "原因类别不能为空")]
        [ExcelColumn(Name = "原因类别")]
        public string CtCauseType { get; set; }

        [Required(ErrorMessage = "原因名称ZH不能为空")]
        [ExcelColumn(Name = "原因名称ZH")]
        public string CtcausetextZh { get; set; }

        [Required(ErrorMessage = "原因名称EN不能为空")]
        [ExcelColumn(Name = "原因名称EN")]
        public string CtcausetextEn { get; set; }

        [Required(ErrorMessage = "原因名称JA不能为空")]
        [ExcelColumn(Name = "原因名称JA")]
        public string CtcausetextJa { get; set; }

        [ExcelIgnore]
        public bool IsDelete { get; set; }

        [ExcelColumn(Name = "备注")]
        public string Remark { get; set; }

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