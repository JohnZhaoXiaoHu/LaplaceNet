using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// OA流程分类表，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-17
    /// </summary>
    [SugarTable("wf_flow_cate")]
    public class WfFlowCate
    {
        /// <summary>
        /// 描述 :Id主键 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Id { get; set; }

        /// <summary>
        /// 描述 :排序号 
        /// 空值 :true 
        /// </summary>
        public int? Ornum { get; set; }

        /// <summary>
        /// 描述 :父ID 
        /// 空值 :true 
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 描述 :名称 
        /// 空值 :true 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述 :创建时间 
        /// 空值 :true 
        /// </summary>
        public DateTime? Crtim { get; set; }

        /// <summary>
        /// 描述 :更新时间 
        /// 空值 :true 
        /// </summary>
        public DateTime? Uptim { get; set; }

        /// <summary>
        /// 描述 :创建者Id 
        /// 空值 :true 
        /// </summary>
        public string Crmid { get; set; }

        /// <summary>
        /// 描述 :修改者Id 
        /// 空值 :true 
        /// </summary>
        public string Upmid { get; set; }

        /// <summary>
        /// 描述 :可用标记：1可用，0禁用 
        /// 空值 :true 
        /// </summary>
        public bool Avtag { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string Notes { get; set; }




    }
}