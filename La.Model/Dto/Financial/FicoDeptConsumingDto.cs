using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 部门消耗查询对象
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    public class FicoDeptConsumingQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :年月 
        /// </summary>
        public string DcYm { get; set; }
        /// <summary>
        /// 描述 :公司代码 
        /// </summary>
        public string DcCorpCode { get; set; }
        /// <summary>
        /// 描述 :统计类别 
        /// </summary>
        public string DcExpCategory { get; set; }
    }

    /// <summary>
    /// 部门消耗输入输出对象
    /// </summary>
    public class FicoDeptConsumingDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public long DcId { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// </summary>
        [Required(ErrorMessage = "期间不能为空")]

        [ExcelColumn(Name = "期间")]
        public string DcFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// </summary>
        [Required(ErrorMessage = "年月不能为空")]

        [ExcelColumn(Name = "年月")]
        public string DcYm { get; set; }

        /// <summary>
        /// 描述 :公司代码 
        /// </summary>
        [Required(ErrorMessage = "公司代码不能为空")]

        [ExcelColumn(Name = "公司代码")]
        public string DcCorpCode { get; set; }

        /// <summary>
        /// 描述 :公司名称 
        /// </summary>
        [Required(ErrorMessage = "公司名称不能为空")]

        [ExcelColumn(Name = "公司名称")]
        public string DcCorpName { get; set; }

        /// <summary>
        /// 描述 :统计类别 
        /// </summary>
        [Required(ErrorMessage = "统计类别不能为空")]

        [ExcelColumn(Name = "统计类别")]
        public string DcExpCategory { get; set; }

        /// <summary>
        /// 描述 :成本代码 
        /// </summary>
        [Required(ErrorMessage = "成本代码不能为空")]

        [ExcelColumn(Name = "成本代码")]
        public string DcCostCode { get; set; }

        /// <summary>
        /// 描述 :成本名称 
        /// </summary>
        [Required(ErrorMessage = "成本名称不能为空")]

        [ExcelColumn(Name = "成本名称")]
        public string DcCostName { get; set; }

        /// <summary>
        /// 描述 :科目代码 
        /// </summary>
        [Required(ErrorMessage = "科目代码不能为空")]

        [ExcelColumn(Name = "科目代码")]
        public string DcTitleCode { get; set; }

        /// <summary>
        /// 描述 :科目名称 
        /// </summary>
        [Required(ErrorMessage = "科目名称不能为空")]

        [ExcelColumn(Name = "科目名称")]
        public string DcTitleName { get; set; }

        /// <summary>
        /// 描述 :科目分类 
        /// </summary>
        [Required(ErrorMessage = "科目分类不能为空")]

        [ExcelColumn(Name = "科目分类")]
        public string DcTitleNote { get; set; }

        /// <summary>
        /// 描述 :预算 
        /// </summary>
        [Required(ErrorMessage = "预算不能为空")]

        [ExcelColumn(Name = "预算")]
        public decimal DcBudgetAmt { get; set; }

        /// <summary>
        /// 描述 :实际 
        /// </summary>
        [Required(ErrorMessage = "实际不能为空")]

        [ExcelColumn(Name = "实际")]
        public decimal DcActualAmt { get; set; }

        /// <summary>
        /// 描述 :差异 
        /// </summary>
        [Required(ErrorMessage = "差异不能为空")]

        [ExcelColumn(Name = "差异")]
        public decimal DcDiffAmt { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]
        public string DcPlant { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string DcMateriel { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// </summary>
        [Required(ErrorMessage = "仓库不能为空")]

        [ExcelColumn(Name = "仓库")]
        public string DcStorageLocation { get; set; }

        /// <summary>
        /// 描述 :移动类型 
        /// </summary>
        [Required(ErrorMessage = "移动类型不能为空")]

        [ExcelColumn(Name = "移动类型")]
        public string DcMoveType { get; set; }

        /// <summary>
        /// 描述 :物料凭证 
        /// </summary>
        [Required(ErrorMessage = "物料凭证不能为空")]

        [ExcelColumn(Name = "物料凭证")]
        public string DcMaterielDoc { get; set; }

        /// <summary>
        /// 描述 :凭证明细 
        /// </summary>
        [Required(ErrorMessage = "凭证明细不能为空")]

        [ExcelColumn(Name = "凭证明细")]
        public string DcMaterielDocDetails { get; set; }

        /// <summary>
        /// 描述 :数量 
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]

        [ExcelColumn(Name = "数量")]
        public decimal DcUseQty { get; set; }

        /// <summary>
        /// 描述 :金额 
        /// </summary>
        [Required(ErrorMessage = "金额不能为空")]

        [ExcelColumn(Name = "金额")]
        public decimal DcUseAmt { get; set; }

        /// <summary>
        /// 描述 :预留单 
        /// </summary>
        [Required(ErrorMessage = "预留单不能为空")]

        [ExcelColumn(Name = "预留单")]
        public string DcReserveDoc { get; set; }

        /// <summary>
        /// 描述 :预留明细 
        /// </summary>
        [Required(ErrorMessage = "预留明细不能为空")]

        [ExcelColumn(Name = "预留明细")]
        public string DcAccountant { get; set; }

        /// <summary>
        /// 描述 :登录日期 
        /// </summary>
        [Required(ErrorMessage = "登录日期不能为空")]

        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? DcBalanceDate { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
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