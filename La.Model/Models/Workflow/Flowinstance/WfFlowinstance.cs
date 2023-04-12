using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models.Workflow.Flowinstance
{
    /// <summary>
    /// 流程实例模板，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("wf_flowinstance")]
    public class WfFlowinstance
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :流程实例模板Id 
        /// 空值 :true 
        /// </summary>
        public long? InstanceSchemeId { get; set; }

        /// <summary>
        /// 描述 :实例编号 
        /// 空值 :true 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 描述 :自定义名称 
        /// 空值 :true 
        /// </summary>
        public string CustomName { get; set; }

        /// <summary>
        /// 描述 :当前节点ID 
        /// 空值 :true 
        /// </summary>
        public string ActivityId { get; set; }

        /// <summary>
        /// 描述 :当前节点类型（0会签节点） 
        /// 空值 :true 
        /// </summary>
        public long? ActivityType { get; set; }

        /// <summary>
        /// 描述 :当前节点名称 
        /// 空值 :true 
        /// </summary>
        public string ActivityName { get; set; }

        /// <summary>
        /// 描述 :前一个ID 
        /// 空值 :true 
        /// </summary>
        public string PreviousId { get; set; }

        /// <summary>
        /// 描述 :流程模板内容 
        /// 空值 :true 
        /// </summary>
        public string SchemeContent { get; set; }

        /// <summary>
        /// 描述 :流程模板ID 
        /// 空值 :true 
        /// </summary>
        public long? SchemeId { get; set; }

        /// <summary>
        /// 描述 :数据库名称 
        /// 空值 :true 
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// 描述 :表单数据 
        /// 空值 :true 
        /// </summary>
        public string FrmData { get; set; }

        /// <summary>
        /// 描述 :表单类型 
        /// 空值 :false 
        /// </summary>
        public long FrmType { get; set; }

        /// <summary>
        /// 描述 :表单中的字段 
        /// 空值 :true 
        /// </summary>
        public string FrmContentData { get; set; }

        /// <summary>
        /// 描述 :表单字段（冗余) 
        /// 空值 :true 
        /// </summary>
        public string FrmContentParse { get; set; }

        /// <summary>
        /// 描述 :表单ID 
        /// 空值 :true 
        /// </summary>
        public long? FrmId { get; set; }

        /// <summary>
        /// 描述 :流程类型 
        /// 空值 :true 
        /// </summary>
        public string SchemeType { get; set; }

        /// <summary>
        /// 描述 :等级 
        /// 空值 :false 
        /// </summary>
        public long FlowLevel { get; set; }

        /// <summary>
        /// 描述 :是否完成 
        /// 空值 :false 
        /// </summary>
        public long IsFinish { get; set; }

        /// <summary>
        /// 描述 :表单参数 
        /// 空值 :true 
        /// </summary>
        public string FrmContent { get; set; }

        /// <summary>
        /// 描述 :执行人 
        /// 空值 :true 
        /// </summary>
        public string MakerList { get; set; }

        /// <summary>
        /// 描述 :所属部门 
        /// 空值 :true 
        /// </summary>
        public long? OrgId { get; set; }

        /// <summary>
        /// 描述 :Active 
        /// 空值 :true 
        /// </summary>
        public string Active { get; set; }

        /// <summary>
        /// 描述 :状态标识 
        /// 空值 :false 
        /// </summary>
        public long Status { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// 空值 :false 
        /// </summary>
        public long IsDeleted { get; set; }

        /// <summary>
        /// 描述 :TenantId 
        /// 空值 :false 
        /// </summary>
        public long TenantId { get; set; }

        /// <summary>
        /// 描述 :ReMark 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

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