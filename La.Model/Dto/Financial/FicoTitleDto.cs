using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 会计科目查询对象
    /// </summary>
    public class FicoTitleQueryDto : PagerInfo 
    {
        public string FtCorpCode { get; set; }
        public string FtTitleCode { get; set; }
    }

    /// <summary>
    /// 会计科目输入输出对象
    /// </summary>
    public class FicoTitleDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long FtId { get; set; }

        [Required(ErrorMessage = "公司名称不能为空")]
        [ExcelColumn(Name = "公司名称")]
        public string FtCorpCode { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        public string FtTitleCode { get; set; }

        [Required(ErrorMessage = "科目名称_ZH不能为空")]
        [ExcelColumn(Name = "科目名称_ZH")]
        public string FttitlenameZh { get; set; }

        [Required(ErrorMessage = "科目名称_EN不能为空")]
        [ExcelColumn(Name = "科目名称_EN")]
        public string FttitlenameEn { get; set; }

        [Required(ErrorMessage = "科目名称_JA不能为空")]
        [ExcelColumn(Name = "科目名称_JA")]
        public string FttitlenameJa { get; set; }

        [ExcelIgnore]
        public bool IsDelete { get; set; }

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