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
        /// <summary>
        /// 描述 :期间 
        /// </summary>
        public string FbFy { get; set; }
        /// <summary>
        /// 描述 :年月 
        /// </summary>
        public string FbYm { get; set; }
        /// <summary>
        /// 描述 :公司代码 
        /// </summary>
        public string FbCorpCode { get; set; }
        /// <summary>
        /// 描述 :统计类别 
        /// </summary>
        public string FbExpCategory { get; set; }
        /// <summary>
        /// 描述 :成本代码 
        /// </summary>
        public string FbCostCode { get; set; }
        /// <summary>
        /// 描述 :科目代码 
        /// </summary>
        public string FbTitleCode { get; set; }
        /// <summary>
        /// 描述 :科目分类 
        /// </summary>
        public string FbTitleNote { get; set; }
    }

    /// <summary>
    /// 预算实际明细输入输出对象
    /// </summary>
    public class FicoBudgetactualCostDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]

        public long FbId { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// </summary>
        [Required(ErrorMessage = "期间不能为空")]

        [ExcelColumn(Name = "期间")]

        public string FbFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// </summary>
        [Required(ErrorMessage = "年月不能为空")]

        [ExcelColumn(Name = "年月")]

        public string FbYm { get; set; }

        /// <summary>
        /// 描述 :公司代码 
        /// </summary>
        [Required(ErrorMessage = "公司代码不能为空")]

        [ExcelColumn(Name = "公司代码")]

        public string FbCorpCode { get; set; }

        /// <summary>
        /// 描述 :公司名称 
        /// </summary>
        [Required(ErrorMessage = "公司名称不能为空")]

        [ExcelColumn(Name = "公司名称")]

        public string FbCorpName { get; set; }

        /// <summary>
        /// 描述 :统计类别 
        /// </summary>
        [Required(ErrorMessage = "统计类别不能为空")]

        [ExcelColumn(Name = "统计类别")]

        public string FbExpCategory { get; set; }

        /// <summary>
        /// 描述 :成本代码 
        /// </summary>
        [Required(ErrorMessage = "成本代码不能为空")]

        [ExcelColumn(Name = "成本代码")]

        public string FbCostCode { get; set; }

        /// <summary>
        /// 描述 :成本名称 
        /// </summary>
        [Required(ErrorMessage = "成本名称不能为空")]

        [ExcelColumn(Name = "成本名称")]

        public string FbCostName { get; set; }

        /// <summary>
        /// 描述 :科目代码 
        /// </summary>
        [Required(ErrorMessage = "科目代码不能为空")]

        [ExcelColumn(Name = "科目代码")]

        public string FbTitleCode { get; set; }

        /// <summary>
        /// 描述 :科目名称 
        /// </summary>
        [Required(ErrorMessage = "科目名称不能为空")]

        [ExcelColumn(Name = "科目名称")]

        public string FbTitleName { get; set; }

        /// <summary>
        /// 描述 :科目分类 
        /// </summary>
        [Required(ErrorMessage = "科目分类不能为空")]

        [ExcelColumn(Name = "科目分类")]

        public string FbTitleNote { get; set; }

        /// <summary>
        /// 描述 :预算 
        /// </summary>
        [Required(ErrorMessage = "预算不能为空")]

        [ExcelColumn(Name = "预算")]

        public decimal FbBudgetAmt { get; set; }

        /// <summary>
        /// 描述 :实际 
        /// </summary>
        [Required(ErrorMessage = "实际不能为空")]

        [ExcelColumn(Name = "实际")]

        public decimal FbActualAmt { get; set; }

        /// <summary>
        /// 描述 :差异 
        /// </summary>
        [Required(ErrorMessage = "差异不能为空")]

        [ExcelColumn(Name = "差异")]

        public decimal FbDiffAmt { get; set; }

        /// <summary>
        /// 描述 :会计人员 
        /// </summary>
        [Required(ErrorMessage = "会计人员不能为空")]

        [ExcelColumn(Name = "会计人员")]

        public string FbAccountant { get; set; }

        /// <summary>
        /// 描述 :日期 
        /// </summary>
        [Required(ErrorMessage = "日期不能为空")]

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? FbBalanceDate { get; set; }

        /// <summary>
        /// 描述 :删除 
        /// </summary>
        [ExcelIgnore]

        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        [ExcelIgnore]

        public string ReMark { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



    }
}