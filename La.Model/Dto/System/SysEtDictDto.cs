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
        /// <summary>
        /// 描述 :Guid 
        /// </summary>
        [Required(ErrorMessage = "Guid不能为空")]
        public long EtGuid { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// </summary>
        [Required(ErrorMessage = "类别不能为空")]
        public string EtType { get; set; }

        /// <summary>
        /// 描述 :字母 
        /// </summary>
        [Required(ErrorMessage = "字母不能为空")]
        public string EtLetter { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// </summary>
        [Required(ErrorMessage = "语言不能为空")]
        public string EtLangKey { get; set; }

        /// <summary>
        /// 描述 :短语 
        /// </summary>
        [Required(ErrorMessage = "短语不能为空")]
        public string EtPhrase { get; set; }

        /// <summary>
        /// 描述 :解释 
        /// </summary>
        [Required(ErrorMessage = "解释不能为空")]
        public string EtExplain { get; set; }
        /// <summary>
        /// 范围
        /// </summary>
        public string EtArea { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 新建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 编辑人员
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }



    }
}