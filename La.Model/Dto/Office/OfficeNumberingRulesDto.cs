using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 单据编码查询对象
    /// @author Davis.Ching
    /// @date 2023-05-16
    /// </summary>
    public class OfficeNumberingRulesQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :模块 
        /// </summary>
        public string RefModule { get; set; }
        /// <summary>
        /// 描述 :类别 
        /// </summary>
        public string RefCategory { get; set; }
        /// <summary>
        /// 描述 :编码名称 
        /// </summary>
        public string RefName { get; set; }
    }

    /// <summary>
    /// 单据编码输入输出对象
    /// </summary>
    public class OfficeNumberingRulesDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public long RefId { get; set; }

        /// <summary>
        /// 描述 :模块 
        /// </summary>
        [Required(ErrorMessage = "模块不能为空")]

        [ExcelColumn(Name = "模块")]
        public string RefModule { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// </summary>
        [Required(ErrorMessage = "类别不能为空")]

        [ExcelColumn(Name = "类别")]
        public string RefCategory { get; set; }

        /// <summary>
        /// 描述 :编码代号 
        /// </summary>
        [Required(ErrorMessage = "编码代号不能为空")]

        [ExcelColumn(Name = "编码代号")]
        public string RefCode { get; set; }

        /// <summary>
        /// 描述 :编码名称 
        /// </summary>
        [Required(ErrorMessage = "编码名称不能为空")]

        [ExcelColumn(Name = "编码名称")]
        public string RefName { get; set; }

        /// <summary>
        /// 描述 :编码模式 
        /// </summary>
        [Required(ErrorMessage = "编码模式不能为空")]

        [ExcelColumn(Name = "编码模式")]
        public string RefPattern { get; set; }

        /// <summary>
        /// 描述 :前缀 
        /// </summary>
        [Required(ErrorMessage = "前缀不能为空")]

        [ExcelColumn(Name = "前缀")]
        public string RefPrefix { get; set; }

        /// <summary>
        /// 描述 :长度 
        /// </summary>
        [Required(ErrorMessage = "长度不能为空")]

        [ExcelColumn(Name = "长度")]
        public int RefLenth { get; set; }

        /// <summary>
        /// 描述 :初始编码 
        /// </summary>
        [Required(ErrorMessage = "初始编码不能为空")]

        [ExcelColumn(Name = "初始编码")]
        public string InitNumber { get; set; }

        /// <summary>
        /// 描述 :ISO编号 
        /// </summary>
        [Required(ErrorMessage = "ISO编号不能为空")]

        [ExcelColumn(Name = "ISO编号")]
        public string IsoNumber { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]

        [ExcelColumn(Name = "状态")]
        public string Status { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]

        [ExcelColumn(Name = "排序")]
        public int Sort { get; set; }

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