using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using La.Model.Models;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 通知公告表输入对象
    /// </summary>
    public class SysNoticeDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int NoticeId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string NoticeTitle { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string NoticeType { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string NoticeContent { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark { get; set; }
    }

    /// <summary>
    /// 通知公告表查询对象
    /// </summary>
    public class SysNoticeQueryDto : PagerInfo
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string NoticeTitle { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string NoticeType { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
    }
}
