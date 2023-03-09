using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace La.Model.Dto
{
    /// <summary>
    /// 多语言配置输入对象
    /// </summary>
    public class CommonLangDto
    {
        /// <summary>
        /// ID
        /// </summary>
        //[Required(ErrorMessage = "id不能为空")]
        public long Id { get; set; }
        //[Required(ErrorMessage = "语言code不能为空")]
        /// <summary>
        /// 语言code
        /// </summary>
        public string LangCode { get; set; }
        /// <summary>
        /// 语言Key
        /// </summary>
        public string LangKey { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        //[Required(ErrorMessage = "名称不能为空")]
        public string LangName { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        public List<CommonLangDto> LangList { get; set; }
    }

    /// <summary>
    /// 多语言配置查询对象
    /// </summary>
    public class CommonLangQueryDto : PagerInfo 
    {
        /// <summary>
        /// 语言代码
        /// </summary>
        public string LangCode { get; set; }
        /// <summary>
        /// 语言Key
        /// </summary>
        public string LangKey { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginAddtime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndAddtime { get; set; }
        /// <summary>
        /// 显示
        /// </summary>
        public int ShowMode { get; set; }
    }
}
