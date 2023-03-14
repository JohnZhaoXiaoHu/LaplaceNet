using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 流程实例模板查询对象
    /// </summary>
    public class WfFlowinstanceQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 流程实例模板输入输出对象
    /// </summary>
    public class WfFlowinstanceDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :流程实例模板Id 
        /// </summary>

        [ExcelColumn(Name = "流程实例模板Id")]
        public long? InstanceSchemeId { get; set; }

        /// <summary>
        /// 描述 :实例编号 
        /// </summary>

        [ExcelColumn(Name = "实例编号")]
        public string Code { get; set; }

        /// <summary>
        /// 描述 :自定义名称 
        /// </summary>

        [ExcelColumn(Name = "自定义名称")]
        public string CustomName { get; set; }

        /// <summary>
        /// 描述 :当前节点ID 
        /// </summary>

        [ExcelColumn(Name = "当前节点ID")]
        public string ActivityId { get; set; }

        /// <summary>
        /// 描述 :当前节点类型（0会签节点） 
        /// </summary>

        [ExcelColumn(Name = "当前节点类型（0会签节点）")]
        public long? ActivityType { get; set; }

        /// <summary>
        /// 描述 :当前节点名称 
        /// </summary>

        [ExcelColumn(Name = "当前节点名称")]
        public string ActivityName { get; set; }

        /// <summary>
        /// 描述 :前一个ID 
        /// </summary>

        [ExcelColumn(Name = "前一个ID")]
        public string PreviousId { get; set; }

        /// <summary>
        /// 描述 :流程模板内容 
        /// </summary>

        [ExcelColumn(Name = "流程模板内容")]
        public string SchemeContent { get; set; }

        /// <summary>
        /// 描述 :流程模板ID 
        /// </summary>

        [ExcelColumn(Name = "流程模板ID")]
        public long? SchemeId { get; set; }

        /// <summary>
        /// 描述 :数据库名称 
        /// </summary>

        [ExcelColumn(Name = "数据库名称")]
        public string DbName { get; set; }

        /// <summary>
        /// 描述 :表单数据 
        /// </summary>

        [ExcelColumn(Name = "表单数据")]
        public string FrmData { get; set; }

        /// <summary>
        /// 描述 :表单类型 
        /// </summary>
        [Required(ErrorMessage = "表单类型不能为空")]

        [ExcelColumn(Name = "表单类型")]
        public long FrmType { get; set; }

        /// <summary>
        /// 描述 :表单中的字段 
        /// </summary>

        [ExcelColumn(Name = "表单中的字段")]
        public string FrmContentData { get; set; }

        /// <summary>
        /// 描述 :表单字段（冗余) 
        /// </summary>

        [ExcelColumn(Name = "表单字段（冗余)")]
        public string FrmContentParse { get; set; }

        /// <summary>
        /// 描述 :表单ID 
        /// </summary>

        [ExcelColumn(Name = "表单ID")]
        public long? FrmId { get; set; }

        /// <summary>
        /// 描述 :流程类型 
        /// </summary>

        [ExcelColumn(Name = "流程类型")]
        public string SchemeType { get; set; }

        /// <summary>
        /// 描述 :等级 
        /// </summary>
        [Required(ErrorMessage = "等级不能为空")]

        [ExcelColumn(Name = "等级")]
        public long FlowLevel { get; set; }

        /// <summary>
        /// 描述 :是否完成 
        /// </summary>
        [Required(ErrorMessage = "是否完成不能为空")]

        [ExcelColumn(Name = "是否完成")]
        public long IsFinish { get; set; }

        /// <summary>
        /// 描述 :表单参数 
        /// </summary>

        [ExcelColumn(Name = "表单参数")]
        public string FrmContent { get; set; }

        /// <summary>
        /// 描述 :执行人 
        /// </summary>

        [ExcelColumn(Name = "执行人")]
        public string MakerList { get; set; }

        /// <summary>
        /// 描述 :所属部门 
        /// </summary>

        [ExcelColumn(Name = "所属部门")]
        public long? OrgId { get; set; }

        /// <summary>
        /// 描述 :Active 
        /// </summary>

        [ExcelColumn(Name = "Active")]
        public string Active { get; set; }

        /// <summary>
        /// 描述 :状态标识 
        /// </summary>
        [Required(ErrorMessage = "状态标识不能为空")]

        [ExcelColumn(Name = "状态标识")]
        public long Status { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// </summary>
        [Required(ErrorMessage = "IsDeleted不能为空")]

        [ExcelColumn(Name = "IsDeleted")]
        public long IsDeleted { get; set; }

        /// <summary>
        /// 描述 :TenantId 
        /// </summary>
        [Required(ErrorMessage = "TenantId不能为空")]

        [ExcelColumn(Name = "TenantId")]
        public long TenantId { get; set; }

        /// <summary>
        /// 描述 :Remark 
        /// </summary>

        [ExcelColumn(Name = "Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>

        [ExcelColumn(Name = "CreateBy")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>

        [ExcelColumn(Name = "CreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>

        [ExcelColumn(Name = "UpdateBy")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>

        [ExcelColumn(Name = "UpdateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? UpdateTime { get; set; }



    }
}