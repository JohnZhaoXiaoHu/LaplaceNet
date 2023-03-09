using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 工作流，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [SugarTable("Sys_WorkFlow")]
    public class SysWorkFlow
    {
        /// <summary>
        /// 描述 :GUID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "workFlow_Id")]
        public Guid WorkflowId { get; set; }

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
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public byte Enable { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}