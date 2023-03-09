using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 文章输入对象
    /// </summary>
    public class ArticleQueryDto: PagerInfo
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

    }
}
