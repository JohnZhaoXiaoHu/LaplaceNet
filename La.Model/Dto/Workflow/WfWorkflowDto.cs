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
    public class WfWorkflowQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 审批流程输入输出对象
    /// </summary>
    public class WfWorkflowDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 描述 :流程名称 
        /// </summary>
        [Required(ErrorMessage = "流程名称不能为空")]

        [ExcelColumn(Name = "流程名称")]
        public string WorkName { get; set; }

        /// <summary>
        /// 描述 :表名 
        /// </summary>
        [Required(ErrorMessage = "表名不能为空")]

        [ExcelColumn(Name = "表名")]
        public string WorkTable { get; set; }

        /// <summary>
        /// 描述 :功能菜单 
        /// </summary>

        [ExcelColumn(Name = "功能菜单")]
        public string WorkTableName { get; set; }

        /// <summary>
        /// 描述 :节点信息 
        /// </summary>

        [ExcelColumn(Name = "节点信息")]
        public string NodeConfig { get; set; }

        /// <summary>
        /// 描述 :连接配置 
        /// </summary>

        [ExcelColumn(Name = "连接配置")]
        public string LineConfig { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>

        [ExcelColumn(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :是否启用 
        /// </summary>

        [ExcelColumn(Name = "是否启用")]
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
        public List<WfWorkflowstep> WfWorkflowstep { get; set; }

    }
}