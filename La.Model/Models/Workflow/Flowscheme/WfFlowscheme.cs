using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models.Workflow.Flowscheme
{
    /// <summary>
    /// 流程，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("wf_flowscheme")]
    public class WfFlowscheme
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :流程编号 
        /// 空值 :true 
        /// </summary>
        public string SchemeCode { get; set; }

        /// <summary>
        /// 描述 :流程名称 
        /// 空值 :true 
        /// </summary>
        public string SchemeName { get; set; }

        /// <summary>
        /// 描述 :流程类型 
        /// 空值 :true 
        /// </summary>
        public string SchemeType { get; set; }

        /// <summary>
        /// 描述 :流程版本 
        /// 空值 :true 
        /// </summary>
        public string SchemeVersion { get; set; }

        /// <summary>
        /// 描述 :流程使用人 
        /// 空值 :true 
        /// </summary>
        public string SchemeCanUser { get; set; }

        /// <summary>
        /// 描述 :流程内容 
        /// 空值 :true 
        /// </summary>
        public string SchemeContent { get; set; }

        /// <summary>
        /// 描述 :表单Id 
        /// 空值 :true 
        /// </summary>
        public long? FrmId { get; set; }

        /// <summary>
        /// 描述 :表单类型 
        /// 空值 :false 
        /// </summary>
        public int FrmType { get; set; }

        /// <summary>
        /// 描述 :权限类型 
        /// 空值 :true 
        /// </summary>
        public int? AuthorizeType { get; set; }

        /// <summary>
        /// 描述 :组织Id 
        /// 空值 :true 
        /// </summary>
        public long? OrgId { get; set; }

        /// <summary>
        /// 描述 :执行 
        /// 空值 :true 
        /// </summary>
        public string Active { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :false 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// 空值 :false 
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// 空值 :true 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 描述 :Remark 
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