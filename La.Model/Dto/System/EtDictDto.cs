using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{


    /// <summary>
    /// 电子技术辞典输入输出对象
    /// </summary>
    public class EtDictDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        public long Id { get; set; }

        [Required(ErrorMessage = "字母不能为空")]
        public string EtLetter { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        public string EtLangcode { get; set; }

        [Required(ErrorMessage = "短语不能为空")]
        public string EtPhrase { get; set; }

        [Required(ErrorMessage = "解释不能为空")]
        public string EtExplain { get; set; }

        public string Remark { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public List<EtDictDto> EtDictList { get; set; }

    }
    /// <summary>
    /// 电子技术辞典查询对象
    /// </summary>
    public class EtDictQueryDto : PagerInfo
    {
        public string EtLetter { get; set; }
        public string EtLangcode { get; set; }
        public string EtPhrase { get; set; }
        public string EtExplain { get; set; }

        public int ShowMode { get; set; }
    }
}