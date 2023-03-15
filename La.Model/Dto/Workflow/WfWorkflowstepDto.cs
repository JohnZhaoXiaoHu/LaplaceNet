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
    /// 审批节点配置查询对象
    /// </summary>
    public class WfWorkflowstepQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 审批节点配置输入输出对象
    /// </summary>
    public class WfWorkflowstepDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public string WorkstepflowId { get; set; }

        /// <summary>
        /// 描述 :流程主表id 
        /// </summary>

        [ExcelColumn(Name = "流程主表id")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 描述 :流程节点Id 
        /// </summary>

        [ExcelColumn(Name = "流程节点Id")]
        public string StepId { get; set; }

        /// <summary>
        /// 描述 :节点名称 
        /// </summary>

        [ExcelColumn(Name = "节点名称")]
        public string StepName { get; set; }

        /// <summary>
        /// 描述 :节点类型 
        /// </summary>

        [ExcelColumn(Name = "节点类型")]
        public int? StepType { get; set; }

        /// <summary>
        /// 描述 :审批用户id或角色id 
        /// </summary>

        [ExcelColumn(Name = "审批用户id或角色id")]
        public int? StepValue { get; set; }

        /// <summary>
        /// 描述 :审批顺序 
        /// </summary>

        [ExcelColumn(Name = "审批顺序")]
        public int? OrderId { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>

        [ExcelColumn(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :Enable 
        /// </summary>

        [ExcelColumn(Name = "Enable")]
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