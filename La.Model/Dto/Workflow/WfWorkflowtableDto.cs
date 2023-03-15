using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 审批流程查询对象
    /// </summary>
    public class WfWorkflowtableQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 审批流程输入输出对象
    /// </summary>
    public class WfWorkflowtableDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public string WorkflowtableId { get; set; }

        /// <summary>
        /// 描述 :流程id 
        /// </summary>

        [ExcelColumn(Name = "流程id")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 描述 :流程名称 
        /// </summary>

        [ExcelColumn(Name = "流程名称")]
        public string WorkName { get; set; }

        /// <summary>
        /// 描述 :表主键id 
        /// </summary>

        [ExcelColumn(Name = "表主键id")]
        public string WorkTableKey { get; set; }

        /// <summary>
        /// 描述 :表名 
        /// </summary>

        [ExcelColumn(Name = "表名")]
        public string WorkTable { get; set; }

        /// <summary>
        /// 描述 :业务名称 
        /// </summary>

        [ExcelColumn(Name = "业务名称")]
        public string WorkTableName { get; set; }

        /// <summary>
        /// 描述 :当前审批节点 
        /// </summary>

        [ExcelColumn(Name = "当前审批节点")]
        public int? CurrentOrderId { get; set; }

        /// <summary>
        /// 描述 :审批状态 
        /// </summary>

        [ExcelColumn(Name = "审批状态")]
        public int? AuditStatus { get; set; }

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

        /// <summary>
        /// 审批节点
        /// </summary>

        [Display(Name = "审批节点")]
        [ForeignKey("WorkFlowTable_Id")]
        public List<WfWorkflowtablestep> WfWorkflowtablestep { get; set; }

    }
}