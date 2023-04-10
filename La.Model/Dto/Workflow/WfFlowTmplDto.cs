using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// OA流程模板表查询对象
    /// </summary>
    public class WfFlowTmplQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :分类ID 
        /// </summary>
        public string Catid { get; set; }
        /// <summary>
        /// 描述 :全局流程模板ID 
        /// </summary>
        public string Protd { get; set; }
        /// <summary>
        /// 描述 :名称 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginCrtim { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndCrtim { get; set; }
        /// <summary>
        /// 描述 :创建者Id 
        /// </summary>
        public string Crmid { get; set; }
        /// <summary>
        /// 描述 :可用标记：1可用，0禁用 
        /// </summary>
        public bool? Avtag { get; set; }
    }

    /// <summary>
    /// OA流程模板表输入输出对象
    /// </summary>
    public class WfFlowTmplDto
    {
        /// <summary>
        /// 描述 :Id主键 
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]

        [ExcelColumn(Name = "Id主键")]
        public string Id { get; set; }

        /// <summary>
        /// 描述 :分类ID 
        /// </summary>

        [ExcelColumn(Name = "分类ID")]
        public string Catid { get; set; }

        /// <summary>
        /// 描述 :排序号 
        /// </summary>

        [ExcelColumn(Name = "排序号")]
        public int? Ornum { get; set; }

        /// <summary>
        /// 描述 :全局流程模板ID 
        /// </summary>

        [ExcelColumn(Name = "全局流程模板ID")]
        public string Protd { get; set; }

        /// <summary>
        /// 描述 :vform 
        /// </summary>

        [ExcelColumn(Name = "vform")]
        public string Vform { get; set; }

        /// <summary>
        /// 描述 :名称 
        /// </summary>

        [ExcelColumn(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 描述 :创建时间 
        /// </summary>

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? Crtim { get; set; }

        /// <summary>
        /// 描述 :更新时间 
        /// </summary>

        [ExcelColumn(Name = "更新时间", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? Uptim { get; set; }

        /// <summary>
        /// 描述 :创建者Id 
        /// </summary>

        [ExcelColumn(Name = "创建者Id")]
        public string Crmid { get; set; }

        /// <summary>
        /// 描述 :修改者Id 
        /// </summary>

        [ExcelColumn(Name = "修改者Id")]
        public string Upmid { get; set; }

        /// <summary>
        /// 描述 :可用标记：1可用，0禁用 
        /// </summary>

        [ExcelColumn(Name = "可用标记：1可用，0禁用")]
        public bool Avtag { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>

        [ExcelColumn(Name = "备注")]
        public string Notes { get; set; }



    }
}