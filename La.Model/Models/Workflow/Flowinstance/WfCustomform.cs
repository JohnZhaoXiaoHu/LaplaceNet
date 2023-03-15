using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models.Workflow.Flowinstance
{
    /// <summary>
    /// 自定义表单，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("wf_customform")]
    public class WfCustomform
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :名称 
        /// 空值 :true 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// 空值 :false 
        /// </summary>
        public long Sort { get; set; }

        /// <summary>
        /// 描述 :流程实例模板Id 
        /// 空值 :false 
        /// </summary>
        public long FlowInstanceId { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

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