using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 审批节点配置，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("wf_workflowstep")]
    public class WfWorkflowstep
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "workStepFlow_Id")]
        public string WorkstepflowId { get; set; }

        /// <summary>
        /// 描述 :流程主表id 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "workFlow_Id")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 描述 :流程节点Id 
        /// 空值 :true 
        /// </summary>
        public string StepId { get; set; }

        /// <summary>
        /// 描述 :节点名称 
        /// 空值 :true 
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// 描述 :节点类型 
        /// 空值 :true 
        /// </summary>
        public int? StepType { get; set; }

        /// <summary>
        /// 描述 :审批用户id或角色id 
        /// 空值 :true 
        /// </summary>
        public int? StepValue { get; set; }

        /// <summary>
        /// 描述 :审批顺序 
        /// 空值 :true 
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :Enable 
        /// 空值 :true 
        /// </summary>
        public byte Enable { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}