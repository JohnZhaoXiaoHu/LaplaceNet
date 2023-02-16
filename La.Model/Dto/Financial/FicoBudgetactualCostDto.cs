using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 预算实际明细查询对象
    /// </summary>
    public class FicoBudgetactualCostQueryDto : PagerInfo 
    {
        public string FbFy { get; set; }
        public string FbYm { get; set; }
        public string FbCorpCode { get; set; }
        public string FbExpCategory { get; set; }
        public string FbCostCode { get; set; }
        public string FbTitleCode { get; set; }
        public string FbTitleNote { get; set; }
    }

    /// <summary>
    /// 预算实际明细输入输出对象
    /// </summary>
    public class FicoBudgetactualCostDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long FbId { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        public string FbFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        public string FbYm { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        public string FbCorpCode { get; set; }

        [Required(ErrorMessage = "公司名称不能为空")]
        [ExcelColumn(Name = "公司名称")]
        public string FbCorpName { get; set; }

        [Required(ErrorMessage = "统计类别不能为空")]
        [ExcelColumn(Name = "统计类别")]
        public string FbExpCategory { get; set; }

        [Required(ErrorMessage = "成本代码不能为空")]
        [ExcelColumn(Name = "成本代码")]
        public string FbCostCode { get; set; }

        [Required(ErrorMessage = "成本名称不能为空")]
        [ExcelColumn(Name = "成本名称")]
        public string FbCostName { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        public string FbTitleCode { get; set; }

        [Required(ErrorMessage = "科目名称不能为空")]
        [ExcelColumn(Name = "科目名称")]
        public string FbTitleName { get; set; }

        [Required(ErrorMessage = "科目分类不能为空")]
        [ExcelColumn(Name = "科目分类")]
        public string FbTitleNote { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        public decimal FbBudgetAmt { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        [ExcelColumn(Name = "实际")]
        public decimal FbActualAmt { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        [ExcelColumn(Name = "差异")]
        public decimal FbDiffAmt { get; set; }

        [Required(ErrorMessage = "会计人员不能为空")]
        [ExcelColumn(Name = "会计人员")]
        public string FbAccountant { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? FbBalanceDate { get; set; }

        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        [ExcelIgnore]
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