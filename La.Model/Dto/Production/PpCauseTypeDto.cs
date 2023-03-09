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
        /// <summary>
        /// 描述 :原因类别 
        /// </summary>
        public string CtCauseType { get; set; }
    }

    /// <summary>
    /// 原因类别输入输出对象
    /// </summary>
    public class PpCauseTypeDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public long CtId { get; set; }

        /// <summary>
        /// 描述 :原因类别 
        /// </summary>
        [Required(ErrorMessage = "原因类别不能为空")]

        [ExcelColumn(Name = "原因类别")]
        public string CtCauseType { get; set; }

        /// <summary>
        /// 描述 :原因名称ZH 
        /// </summary>
        [Required(ErrorMessage = "原因名称ZH不能为空")]

        [ExcelColumn(Name = "原因名称ZH")]
        public string CtcausetextZh { get; set; }

        /// <summary>
        /// 描述 :原因名称EN 
        /// </summary>
        [Required(ErrorMessage = "原因名称EN不能为空")]

        [ExcelColumn(Name = "原因名称EN")]
        public string CtcausetextEn { get; set; }

        /// <summary>
        /// 描述 :原因名称JA 
        /// </summary>
        [Required(ErrorMessage = "原因名称JA不能为空")]

        [ExcelColumn(Name = "原因名称JA")]
        public string CtcausetextJa { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>

        [ExcelColumn(Name = "备注")]
        public string Remark { get; set; }

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