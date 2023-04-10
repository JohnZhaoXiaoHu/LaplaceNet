using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 流程使用记录，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-10
    /// </summary>
    [SugarTable("wf_flow_rece")]
    public class WfFlowRece
    {
        /// <summary>
        /// 描述 :Id主键 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Id { get; set; }

        /// <summary>
        /// 描述 :用户ID 
        /// 空值 :false 
        /// </summary>
        public string Useid { get; set; }

        /// <summary>
        /// 描述 :流程模板ID 
        /// 空值 :false 
        /// </summary>
        public string Floid { get; set; }

        /// <summary>
        /// 描述 :最近使用时间 
        /// 空值 :true 
        /// </summary>
        public DateTime? Uptim { get; set; }




    }
}