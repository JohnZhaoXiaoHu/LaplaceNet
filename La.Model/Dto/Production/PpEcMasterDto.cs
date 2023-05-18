using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 主设变查询对象
    /// @author Davis.Cheng
    /// @date 2023-05-18
    /// </summary>
    public class PpEcMasterQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginEmEcIssueDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndEmEcIssueDate { get; set; }
        /// <summary>
        /// 描述 :设变No. 
        /// </summary>
        public string EmEcNo { get; set; }
        /// <summary>
        /// 描述 :标题 
        /// </summary>
        public string EmEcTitle { get; set; }
        /// <summary>
        /// 描述 :担当 
        /// </summary>
        public string EmEcAssigned { get; set; }
        /// <summary>
        /// 描述 :管理区分 
        /// </summary>
        public int? EmEcManageCategory { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginEmEcEntryDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndEmEcEntryDate { get; set; }
    }

    /// <summary>
    /// 主设变输入输出对象
    /// </summary>
    public class PpEcMasterDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public int EmId { get; set; }

        /// <summary>
        /// 描述 :发行日 
        /// </summary>
        [Required(ErrorMessage = "发行日不能为空")]

        [ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EmEcIssueDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// </summary>
        [Required(ErrorMessage = "设变No.不能为空")]

        [ExcelColumn(Name = "设变No.")]
        public string EmEcNo { get; set; }

        /// <summary>
        /// 描述 :关联文件 
        /// </summary>

        [ExcelColumn(Name = "关联文件")]
        public string EmEcDoc { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// </summary>
        [Required(ErrorMessage = "状态不能为空")]

        [ExcelColumn(Name = "状态")]
        public string EmEcStatus { get; set; }

        /// <summary>
        /// 描述 :标题 
        /// </summary>
        [Required(ErrorMessage = "标题不能为空")]

        [ExcelColumn(Name = "标题")]
        public string EmEcTitle { get; set; }

        /// <summary>
        /// 描述 :内容 
        /// </summary>
        [Required(ErrorMessage = "内容不能为空")]

        [ExcelColumn(Name = "内容")]
        public string EmEcContent { get; set; }

        /// <summary>
        /// 描述 :担当 
        /// </summary>
        [Required(ErrorMessage = "担当不能为空")]

        [ExcelColumn(Name = "担当")]
        public string EmEcAssigned { get; set; }

        /// <summary>
        /// 描述 :损失金额 
        /// </summary>
        [Required(ErrorMessage = "损失金额不能为空")]

        [ExcelColumn(Name = "损失金额")]
        public decimal EmEcLossAmount { get; set; }

        /// <summary>
        /// 描述 :管理区分 
        /// </summary>
        [Required(ErrorMessage = "管理区分不能为空")]

        [ExcelColumn(Name = "管理区分")]
        public int EmEcManageCategory { get; set; }

        /// <summary>
        /// 描述 :联络No. 
        /// </summary>

        [ExcelColumn(Name = "联络No.")]
        public string EmEcLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :联络文件 
        /// </summary>

        [ExcelColumn(Name = "联络文件")]
        public string EmEcLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :EppNo. 
        /// </summary>

        [ExcelColumn(Name = "EppNo.")]
        public string EmEcEppLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :Epp文件 
        /// </summary>

        [ExcelColumn(Name = "Epp文件")]
        public string EmEcEppLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :FppNo. 
        /// </summary>

        [ExcelColumn(Name = "FppNo.")]
        public string EmEcFppLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :Fpp文件 
        /// </summary>

        [ExcelColumn(Name = "Fpp文件")]
        public string EmEcFppLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :外部No. 
        /// </summary>

        [ExcelColumn(Name = "外部No.")]
        public string EmEcExternalNo { get; set; }

        /// <summary>
        /// 描述 :外部文件 
        /// </summary>

        [ExcelColumn(Name = "外部文件")]
        public string EmEcExternalDoc { get; set; }

        /// <summary>
        /// 描述 :输入部门 
        /// </summary>
        [Required(ErrorMessage = "输入部门不能为空")]

        [ExcelColumn(Name = "输入部门")]
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// </summary>
        [Required(ErrorMessage = "输入日不能为空")]

        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EmEcEntryDate { get; set; }

        /// <summary>
        /// 描述 :SOP 
        /// </summary>
        [Required(ErrorMessage = "SOP不能为空")]

        [ExcelColumn(Name = "SOP")]
        public byte EsSopStae { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// </summary>
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// </summary>
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// </summary>
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// </summary>
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// </summary>
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// </summary>
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>
        [ExcelIgnore]
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>
        [ExcelIgnore]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}