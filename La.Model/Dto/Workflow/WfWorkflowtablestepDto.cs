using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 审批节点查询对象
    /// </summary>
    public class WfWorkflowtablestepQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 审批节点输入输出对象
    /// </summary>
    public class WfWorkflowtablestepDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public string SysWorkflowtablestepId { get; set; }

        /// <summary>
        /// 描述 :主表id 
        /// </summary>
        [Required(ErrorMessage = "主表id不能为空")]

        [ExcelColumn(Name = "主表id")]
        public string WorkflowtableId { get; set; }

        /// <summary>
        /// 描述 :流程id 
        /// </summary>

        [ExcelColumn(Name = "流程id")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 描述 :节点id 
        /// </summary>

        [ExcelColumn(Name = "节点id")]
        public string StepId { get; set; }

        /// <summary>
        /// 描述 :节名称 
        /// </summary>

        [ExcelColumn(Name = "节名称")]
        public string StepName { get; set; }

        /// <summary>
        /// 描述 :审批类型 
        /// </summary>

        [ExcelColumn(Name = "审批类型")]
        public int? StepType { get; set; }

        /// <summary>
        /// 描述 :节点类型 
        /// </summary>

        [ExcelColumn(Name = "节点类型")]
        public int? StepValue { get; set; }

        /// <summary>
        /// 描述 :审批顺序 
        /// </summary>

        [ExcelColumn(Name = "审批顺序")]
        public int? OrderId { get; set; }

        /// <summary>
        /// 描述 :审核人id 
        /// </summary>

        [ExcelColumn(Name = "审核人id")]
        public int? AuditId { get; set; }

        /// <summary>
        /// 描述 :审核人 
        /// </summary>

        [ExcelColumn(Name = "审核人")]
        public string Auditor { get; set; }

        /// <summary>
        /// 描述 :审核状态 
        /// </summary>

        [ExcelColumn(Name = "审核状态")]
        public int? AuditStatus { get; set; }

        /// <summary>
        /// 描述 :审核时间 
        /// </summary>

        [ExcelColumn(Name = "审核时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? AuditDate { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>

        [ExcelColumn(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :启用 
        /// </summary>

        [ExcelColumn(Name = "启用")]
        public byte Enable { get; set; }

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