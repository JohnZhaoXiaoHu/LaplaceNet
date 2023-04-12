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
    /// @author Davis.Cheng
    /// @date 2023-04-11
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
        /// <summary>
        /// 描述 :科目名称_ZH 
        /// </summary>
        public string FtTitleName { get; set; }
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
        [ExcelIgnore]
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
        public string FtTitleName { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// </summary>
        [Required(ErrorMessage = "语言不能为空")]

        [ExcelColumn(Name = "语言")]
        public string FtTitleLang { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
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