﻿using SqlSugar;
using System;

namespace La.Model.System
{
    /// <summary>
    /// 文章表
    /// </summary>
    [SugarTable("article")]
    [Tenant("0")]
    public class Article
    {
        /// <summary>
        /// 文章id
        /// </summary>
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Cid { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 作者名
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// 发布者用户id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 文章状态 1、发布 2、草稿
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 编辑器类型 markdown,html
        /// </summary>
        [SugarColumn(ColumnName = "fmt_type")]
        public string FmtType { get; set; }
        /// <summary>
        /// 文章标签eg：Net5,java
        /// </summary>
        public string Tags { get; set; }
        public int Hits { get; set; }
        [SugarColumn(ColumnName = "category_Id")]
        public int CategoryId { get; set; }
        /// <summary>
        /// 封面地址
        /// </summary>
        public string CoverUrl { get; set; }

        [Navigate(NavigateType.OneToOne, nameof(CategoryId), nameof(ArticleCategory.CategoryId))] //自定义关系映射
        public ArticleCategory ArticleCategoryNav { get; set; }
    }
}
