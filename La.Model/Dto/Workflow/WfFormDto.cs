using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 表单查询对象
    /// </summary>
    public class WfFormQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 表单输入输出对象
    /// </summary>
    public class WfFormDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :表单名称 
        /// </summary>

        [ExcelColumn(Name = "表单名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述 :表单类型 
        /// </summary>

        [ExcelColumn(Name = "表单类型")]
        public int? FrmType { get; set; }

        /// <summary>
        /// 描述 :自定义表单 
        /// </summary>

        [ExcelColumn(Name = "自定义表单")]
        public string WebId { get; set; }

        /// <summary>
        /// 描述 :字段数 
        /// </summary>

        [ExcelColumn(Name = "字段数")]
        public int? Fields { get; set; }

        /// <summary>
        /// 描述 :字段 
        /// </summary>

        [ExcelColumn(Name = "字段")]
        public string ContentData { get; set; }

        /// <summary>
        /// 描述 :字段格式化 
        /// </summary>

        [ExcelColumn(Name = "字段格式化")]
        public string ContentParse { get; set; }

        /// <summary>
        /// 描述 :表单内容 
        /// </summary>

        [ExcelColumn(Name = "表单内容")]
        public string Content { get; set; }

        /// <summary>
        /// 描述 :数据库备用 
        /// </summary>

        [ExcelColumn(Name = "数据库备用")]
        public string DbName { get; set; }

        /// <summary>
        /// 描述 :组织id 
        /// </summary>

        [ExcelColumn(Name = "组织id")]
        public long? OrgId { get; set; }

        /// <summary>
        /// 描述 :执行 
        /// </summary>

        [ExcelColumn(Name = "执行")]
        public string Active { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]

        [ExcelColumn(Name = "状态")]
        public int Status { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]

        [ExcelColumn(Name = "排序")]
        public int Sort { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// </summary>
        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 描述 :Remark 
        /// </summary>

        [ExcelColumn(Name = "Remark")]
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