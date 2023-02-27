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
    /// </summary>
    public class SysRefStrategyQueryDto : PagerInfo 
    {
        public string RefModule { get; set; }
        public string RefCategory { get; set; }
        public string RefPattern { get; set; }
    }

    /// <summary>
    /// 单据编码输入输出对象
    /// </summary>
    public class SysRefStrategyDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long RefId { get; set; }

        [Required(ErrorMessage = "模块不能为空")]
        [ExcelColumn(Name = "模块")]
        public string RefModule { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        public string RefCategory { get; set; }

        [Required(ErrorMessage = "编码代号不能为空")]
        [ExcelColumn(Name = "编码代号")]
        public string RefCode { get; set; }

        [Required(ErrorMessage = "编码名称不能为空")]
        [ExcelColumn(Name = "编码名称")]
        public string RefName { get; set; }

        [Required(ErrorMessage = "编码模式不能为空")]
        [ExcelColumn(Name = "编码模式")]
        public string RefPattern { get; set; }

        [Required(ErrorMessage = "前缀不能为空")]
        [ExcelColumn(Name = "前缀")]
        public string RefPrefix { get; set; }

        [Required(ErrorMessage = "长度不能为空")]
        [ExcelColumn(Name = "长度")]
        public int RefLenth { get; set; }

        [Required(ErrorMessage = "初始编码不能为空")]
        [ExcelColumn(Name = "初始编码")]
        public string InitNumber { get; set; }

        [Required(ErrorMessage = "ISO编号不能为空")]
        [ExcelColumn(Name = "ISO编号")]
        public string IsoNumber { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        public string Status { get; set; }

        [Required(ErrorMessage = "排序不能为空")]
        [ExcelColumn(Name = "排序")]
        public int Sort { get; set; }

        [ExcelColumn(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }

        [ExcelIgnore]
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