using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 文章目录输入对象
    /// </summary>
    public class ArticleCategoryDto
    {
        /// <summary>
        /// 目录id
        /// </summary>
        [Required(ErrorMessage = "目录id不能为空")]
        public int CategoryId { get; set; }
        /// <summary>
        /// 目录名
        /// </summary>
        [Required(ErrorMessage = "目录名不能为空")]        
        public string Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int? ParentId { get; set; }
    }

    /// <summary>
    /// 文章目录查询对象
    /// </summary>
    public class ArticleCategoryQueryDto : PagerInfo 
    {
    }
}
