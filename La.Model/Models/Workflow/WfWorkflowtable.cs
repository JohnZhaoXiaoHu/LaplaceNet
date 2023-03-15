using System;
using SqlSugar;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace La.Model.Models
{
    /// <summary>
    /// 审批流程，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("wf_workflowtable")]
    public class WfWorkflowtable
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "workFlowTable_Id")]
        public string WorkflowtableId { get; set; }

        /// <summary>
        /// 描述 :流程id 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "workFlow_Id")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 描述 :流程名称 
        /// 空值 :true 
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// 描述 :表主键id 
        /// 空值 :true 
        /// </summary>
        public string WorkTableKey { get; set; }

        /// <summary>
        /// 描述 :表名 
        /// 空值 :true 
        /// </summary>
        public string WorkTable { get; set; }

        /// <summary>
        /// 描述 :业务名称 
        /// 空值 :true 
        /// </summary>
        public string WorkTableName { get; set; }

        /// <summary>
        /// 描述 :当前审批节点 
        /// 空值 :true 
        /// </summary>
        public int? CurrentOrderId { get; set; }

        /// <summary>
        /// 描述 :审批状态 
        /// 空值 :true 
        /// </summary>
        public int? AuditStatus { get; set; }

        /// <summary>
        /// 描述 :启用 
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