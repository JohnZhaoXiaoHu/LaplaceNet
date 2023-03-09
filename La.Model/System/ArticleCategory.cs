using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System
{
    /// <summary>
    /// 文章目录
    /// </summary>
    [SugarTable("articleCategory")]
    [Tenant("0")]
    public class ArticleCategory
    {
        /// <summary>
        /// 目录id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnName = "Category_id")]
        public int CategoryId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 主ID
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 新建时间
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 子类
        /// </summary>

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [SugarColumn(IsIgnore = true)]
        public List<ArticleCategory> Children { get; set; }
    }
}
