using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 流程使用记录查询对象
    /// </summary>
    public class WfFlowReceQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :用户ID 
        /// </summary>
        public string Useid { get; set; }
        /// <summary>
        /// 描述 :流程模板ID 
        /// </summary>
        public string Floid { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginUptim { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndUptim { get; set; }
    }

    /// <summary>
    /// 流程使用记录输入输出对象
    /// </summary>
    public class WfFlowReceDto
    {
        /// <summary>
        /// 描述 :Id主键 
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]

        [ExcelColumn(Name = "Id主键")]
        public string Id { get; set; }

        /// <summary>
        /// 描述 :用户ID 
        /// </summary>
        [Required(ErrorMessage = "用户ID不能为空")]

        [ExcelColumn(Name = "用户ID")]
        public string Useid { get; set; }

        /// <summary>
        /// 描述 :流程模板ID 
        /// </summary>
        [Required(ErrorMessage = "流程模板ID不能为空")]

        [ExcelColumn(Name = "流程模板ID")]
        public string Floid { get; set; }

        /// <summary>
        /// 描述 :最近使用时间 
        /// </summary>

        [ExcelColumn(Name = "最近使用时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? Uptim { get; set; }



    }
}