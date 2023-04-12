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
    [SugarTable("wf_workflow")]
    public class WfWorkflow
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "workFlow_Id")]
        public string WorkflowId { get; set; }

        /// <summary>
        /// 描述 :流程名称 
        /// 空值 :false 
        /// </summary>
        public string WorkName { get; set; }

        /// <summary>
        /// 描述 :表名 
        /// 空值 :false 
        /// </summary>
        public string WorkTable { get; set; }

        /// <summary>
        /// 描述 :功能菜单 
        /// 空值 :true 
        /// </summary>
        public string WorkTableName { get; set; }

        /// <summary>
        /// 描述 :节点信息 
        /// 空值 :true 
        /// </summary>
        public string NodeConfig { get; set; }

        /// <summary>
        /// 描述 :连接配置 
        /// 空值 :true 
        /// </summary>
        public string LineConfig { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :是否启用 
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