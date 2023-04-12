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
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    public class FicoPeriodQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :财年 
        /// </summary>
        public string FpFy { get; set; }
        /// <summary>
        /// 描述 :年月 
        /// </summary>
        public string FpYm { get; set; }
    }

    /// <summary>
    /// 财务期间输入输出对象
    /// </summary>
    public class FicoPeriodDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public int FpId { get; set; }

        /// <summary>
        /// 描述 :财年 
        /// </summary>
        [Required(ErrorMessage = "财年不能为空")]

        [ExcelColumn(Name = "财年")]
        public string FpFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// </summary>
        [Required(ErrorMessage = "年月不能为空")]

        [ExcelColumn(Name = "年月")]
        public string FpYm { get; set; }

        /// <summary>
        /// 描述 :年 
        /// </summary>
        [Required(ErrorMessage = "年不能为空")]

        [ExcelColumn(Name = "年")]
        public string FpYear { get; set; }

        /// <summary>
        /// 描述 :月 
        /// </summary>
        [Required(ErrorMessage = "月不能为空")]

        [ExcelColumn(Name = "月")]
        public string FpMonth { get; set; }

        /// <summary>
        /// 描述 :季度 
        /// </summary>
        [Required(ErrorMessage = "季度不能为空")]

        [ExcelColumn(Name = "季度")]
        public string FpQuarter { get; set; }

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