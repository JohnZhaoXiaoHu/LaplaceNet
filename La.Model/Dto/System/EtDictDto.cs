using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 电子辞典查询对象
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    public class EtDictQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :类别 
        /// </summary>
        public string EtType { get; set; }
        /// <summary>
        /// 描述 :字母 
        /// </summary>
        public string EtLetter { get; set; }
        /// <summary>
        /// 描述 :隶属范围 
        /// </summary>
        public string EtArea { get; set; }
    }

    /// <summary>
    /// 电子辞典输入输出对象
    /// </summary>
    public class EtDictDto
    {
        /// <summary>
        /// 描述 :Guid 
        /// </summary>
        [Required(ErrorMessage = "Guid不能为空")]
        [ExcelIgnore]
        public long EtGuid { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// </summary>
        [Required(ErrorMessage = "类别不能为空")]

        [ExcelColumn(Name = "类别")]
        public string EtType { get; set; }

        /// <summary>
        /// 描述 :字母 
        /// </summary>
        [Required(ErrorMessage = "字母不能为空")]

        [ExcelColumn(Name = "字母")]
        public string EtLetter { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// </summary>
        [Required(ErrorMessage = "语言不能为空")]

        [ExcelColumn(Name = "语言")]
        public string EtLangKey { get; set; }

        /// <summary>
        /// 描述 :短语 
        /// </summary>
        [Required(ErrorMessage = "短语不能为空")]

        [ExcelColumn(Name = "短语")]
        public string EtPhrase { get; set; }

        /// <summary>
        /// 描述 :解释 
        /// </summary>
        [Required(ErrorMessage = "解释不能为空")]

        [ExcelColumn(Name = "解释")]
        public string EtExplain { get; set; }

        /// <summary>
        /// 描述 :隶属范围 
        /// </summary>

        [ExcelColumn(Name = "隶属范围")]
        public string EtArea { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>
        [ExcelIgnore]
        public string Remark { get; set; }

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