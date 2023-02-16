using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// bom成本核算查询对象
    /// </summary>
    public class FicoBomCostingQueryDto : PagerInfo 
    {
        public string BcPlant { get; set; }
        public string BcFy { get; set; }
        public string BcYm { get; set; }
        public string BcBomItem { get; set; }
    }

    /// <summary>
    /// bom成本核算输入输出对象
    /// </summary>
    public class FicoBomCostingDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long BcId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        public string BcPlant { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        public string BcFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        public string BcYm { get; set; }

        [Required(ErrorMessage = "成品物料不能为空")]
        [ExcelColumn(Name = "成品物料")]
        public string BcBomItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        public string BcItemText { get; set; }

        [Required(ErrorMessage = "成本不能为空")]
        [ExcelColumn(Name = "成本")]
        public decimal BcBomCost { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        public string BcCurrency { get; set; }

        [Required(ErrorMessage = "核算日期不能为空")]
        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? BcBalancedate { get; set; }

        [ExcelIgnore]
        public bool IsDelete { get; set; }

        [ExcelColumn(Name = "备注")]
        public string Remark { get; set; }

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