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
        [Required(ErrorMessage = "目录id不能为空")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "目录名不能为空")]
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ParentId { get; set; }
    }

    /// <summary>
    /// 文章目录查询对象
    /// </summary>
    public class ArticleCategoryQueryDto : PagerInfo 
    {
    }
}
