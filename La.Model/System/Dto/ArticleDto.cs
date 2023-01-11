using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System.Dto
{
    public class ArticleQueryDto: PagerInfo
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
