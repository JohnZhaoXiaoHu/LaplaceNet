using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 自定义表单查询对象
    /// </summary>
    public class WfCustomformQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 自定义表单输入输出对象
    /// </summary>
    public class WfCustomformDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :名称 
        /// </summary>

        [ExcelColumn(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]

        [ExcelColumn(Name = "排序")]
        public long Sort { get; set; }

        /// <summary>
        /// 描述 :流程实例模板Id 
        /// </summary>
        [Required(ErrorMessage = "流程实例模板Id不能为空")]

        [ExcelColumn(Name = "流程实例模板Id")]
        public long FlowInstanceId { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>

        [ExcelColumn(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>

        [ExcelColumn(Name = "CreateBy")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>

        [ExcelColumn(Name = "CreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>

        [ExcelColumn(Name = "UpdateBy")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>

        [ExcelColumn(Name = "UpdateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? UpdateTime { get; set; }



    }
}