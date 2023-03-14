using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 工作流实例流转历史记录，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("wf_flowinstancehis")]
    public class WfFlowinstancehis
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :实例Id 
        /// 空值 :false 
        /// </summary>
        public long InstanceId { get; set; }

        /// <summary>
        /// 描述 :开始节点Id 
        /// 空值 :true 
        /// </summary>
        public string FromNodeId { get; set; }

        /// <summary>
        /// 描述 :开始节点类型 
        /// 空值 :true 
        /// </summary>
        public long? FromNodeType { get; set; }

        /// <summary>
        /// 描述 :开始节点名称 
        /// 空值 :true 
        /// </summary>
        public string FromNodeName { get; set; }

        /// <summary>
        /// 描述 :结束节点Id 
        /// 空值 :true 
        /// </summary>
        public string ToNodeId { get; set; }

        /// <summary>
        /// 描述 :结束节点类型 
        /// 空值 :true 
        /// </summary>
        public long? ToNodeType { get; set; }

        /// <summary>
        /// 描述 :结束节点名称 
        /// 空值 :true 
        /// </summary>
        public string ToNodeName { get; set; }

        /// <summary>
        /// 描述 :转化状态 
        /// 空值 :false 
        /// </summary>
        public long TransitionSate { get; set; }

        /// <summary>
        /// 描述 :是否结束 
        /// 空值 :false 
        /// </summary>
        public long IsFinish { get; set; }

        /// <summary>
        /// 描述 :Remark 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :创建用户 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :转化时间 
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