﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 主设变信息表查询对象
    /// </summary>
    public class PpEcMasterQueryDto : PagerInfo 
    {
        public string EmEcNo { get; set; }
        public string EmEcStatus { get; set; }
        public string EmEcTitle { get; set; }
        public string EmEcContent { get; set; }
        public string EmEcAssigned { get; set; }
        public int? EmEcManageCategory { get; set; }
        public string EmEcImpDept { get; set; }
    }

    /// <summary>
    /// 主设变信息表输入输出对象
    /// </summary>
    public class PpEcMasterDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public int EmId { get; set; }

        [Required(ErrorMessage = "发行日不能为空")]
        [ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EmEcIssueDate { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        [ExcelColumn(Name = "设变No.")]
        public string EmEcNo { get; set; }

        [ExcelColumn(Name = "关联文件")]
        public string EmEcDoc { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        public string EmEcStatus { get; set; }

        [Required(ErrorMessage = "标题不能为空")]
        [ExcelColumn(Name = "标题")]
        public string EmEcTitle { get; set; }

        [Required(ErrorMessage = "内容不能为空")]
        [ExcelColumn(Name = "内容")]
        public string EmEcContent { get; set; }

        [Required(ErrorMessage = "担当不能为空")]
        [ExcelColumn(Name = "担当")]
        public string EmEcAssigned { get; set; }

        [Required(ErrorMessage = "损失金额不能为空")]
        [ExcelColumn(Name = "损失金额")]
        public decimal EmEcLossAmount { get; set; }

        [Required(ErrorMessage = "管理区分不能为空")]
        [ExcelColumn(Name = "管理区分")]
        public int EmEcManageCategory { get; set; }

        [ExcelColumn(Name = "联络No.")]
        public string EmEcLiaisonNo { get; set; }

        [ExcelColumn(Name = "联络文件")]
        public string EmEcLiaisonDoc { get; set; }

        [ExcelColumn(Name = "EppNo.")]
        public string EmEcEppLiaisonNo { get; set; }

        [ExcelColumn(Name = "Epp文件")]
        public string EmEcEppLiaisonDoc { get; set; }

        [ExcelColumn(Name = "FppNo.")]
        public string EmEcFppLiaisonNo { get; set; }

        [ExcelColumn(Name = "Fpp文件")]
        public string EmEcFppLiaisonDoc { get; set; }

        [ExcelColumn(Name = "外部No.")]
        public string EmEcExternalNo { get; set; }

        [ExcelColumn(Name = "外部文件")]
        public string EmEcExternalDoc { get; set; }

        [Required(ErrorMessage = "实施部门不能为空")]
        [ExcelColumn(Name = "实施部门")]
        public string EmEcImpDept { get; set; }

        [Required(ErrorMessage = "输入日不能为空")]
        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EmEcEntryDate { get; set; }

        [Required(ErrorMessage = "SOP变更否不能为空")]
        [ExcelColumn(Name = "SOP变更否")]
        public bool IsModifySop { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        public string ReMark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}