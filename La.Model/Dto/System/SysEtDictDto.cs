using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 电子辞典查询对象
    /// </summary>
    public class SysEtDictQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 电子辞典输入输出对象
    /// </summary>
    public class SysEtDictDto
    {
        [Required(ErrorMessage = "Guid不能为空")]
        public long EtGuid { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        public string EtType { get; set; }

        [Required(ErrorMessage = "字母不能为空")]
        public string EtLetter { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        public string EtLangKey { get; set; }

        [Required(ErrorMessage = "短语不能为空")]
        public string EtPhrase { get; set; }

        [Required(ErrorMessage = "解释不能为空")]
        public string EtExplain { get; set; }

        public string EtArea { get; set; }

        public string Remark { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }



    }
}