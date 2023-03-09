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
        /// <summary>
        /// 描述 :公司名称 
        /// </summary>
        public string FtCorpCode { get; set; }
        /// <summary>
        /// 描述 :科目代码 
        /// </summary>
        public string FtTitleCode { get; set; }
    }

    /// <summary>
    /// 会计科目输入输出对象
    /// </summary>
    public class FicoTitleDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]

        public long FtId { get; set; }

        /// <summary>
        /// 描述 :公司名称 
        /// </summary>
        [Required(ErrorMessage = "公司名称不能为空")]

        [ExcelColumn(Name = "公司名称")]

        public string FtCorpCode { get; set; }

        /// <summary>
        /// 描述 :科目代码 
        /// </summary>
        [Required(ErrorMessage = "科目代码不能为空")]

        [ExcelColumn(Name = "科目代码")]

        public string FtTitleCode { get; set; }

        /// <summary>
        /// 描述 :科目名称_ZH 
        /// </summary>
        [Required(ErrorMessage = "科目名称_ZH不能为空")]

        [ExcelColumn(Name = "科目名称_ZH")]

        public string FttitlenameZh { get; set; }

        /// <summary>
        /// 描述 :科目名称_EN 
        /// </summary>
        [Required(ErrorMessage = "科目名称_EN不能为空")]

        [ExcelColumn(Name = "科目名称_EN")]

        public string FttitlenameEn { get; set; }

        /// <summary>
        /// 描述 :科目名称_JA 
        /// </summary>
        [Required(ErrorMessage = "科目名称_JA不能为空")]

        [ExcelColumn(Name = "科目名称_JA")]

        public string FttitlenameJa { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]

        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        [ExcelIgnore]

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