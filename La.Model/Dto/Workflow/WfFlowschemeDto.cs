using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 流程查询对象
    /// </summary>
    public class WfFlowschemeQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 流程输入输出对象
    /// </summary>
    public class WfFlowschemeDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :流程编号 
        /// </summary>
        public string SchemeCode { get; set; }

        /// <summary>
        /// 描述 :流程名称 
        /// </summary>
        public string SchemeName { get; set; }

        /// <summary>
        /// 描述 :流程类型 
        /// </summary>
        public string SchemeType { get; set; }

        /// <summary>
        /// 描述 :流程版本 
        /// </summary>
        public string SchemeVersion { get; set; }

        /// <summary>
        /// 描述 :流程使用人 
        /// </summary>
        public string SchemeCanUser { get; set; }

        /// <summary>
        /// 描述 :流程内容 
        /// </summary>
        public string SchemeContent { get; set; }

        /// <summary>
        /// 描述 :表单Id 
        /// </summary>
        public long? FrmId { get; set; }

        /// <summary>
        /// 描述 :表单类型 
        /// </summary>
        [Required(ErrorMessage = "表单类型不能为空")]
        public int FrmType { get; set; }

        /// <summary>
        /// 描述 :权限类型 
        /// </summary>
        public int? AuthorizeType { get; set; }

        /// <summary>
        /// 描述 :组织Id 
        /// </summary>
        public long? OrgId { get; set; }

        /// <summary>
        /// 描述 :执行 
        /// </summary>
        public string Active { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]
        public int Sort { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 描述 :Remark 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        public DateTime? UpdateTime { get; set; }



    }
}