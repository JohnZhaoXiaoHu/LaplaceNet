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
        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        public string BcPlant { get; set; }
        /// <summary>
        /// 描述 :期间 
        /// </summary>
        public string BcFy { get; set; }
        /// <summary>
        /// 描述 :年月 
        /// </summary>
        public string BcYm { get; set; }
        /// <summary>
        /// 描述 :成品物料 
        /// </summary>
        public string BcBomItem { get; set; }
    }

    /// <summary>
    /// bom成本核算输入输出对象
    /// </summary>
    public class FicoBomCostingDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]

        public long BcId { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]

        public string BcPlant { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// </summary>
        [Required(ErrorMessage = "期间不能为空")]

        [ExcelColumn(Name = "期间")]

        public string BcFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// </summary>
        [Required(ErrorMessage = "年月不能为空")]

        [ExcelColumn(Name = "年月")]

        public string BcYm { get; set; }

        /// <summary>
        /// 描述 :成品物料 
        /// </summary>
        [Required(ErrorMessage = "成品物料不能为空")]

        [ExcelColumn(Name = "成品物料")]

        public string BcBomItem { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// </summary>
        [Required(ErrorMessage = "物料文本不能为空")]

        [ExcelColumn(Name = "物料文本")]

        public string BcItemText { get; set; }

        /// <summary>
        /// 描述 :成本 
        /// </summary>
        [Required(ErrorMessage = "成本不能为空")]

        [ExcelColumn(Name = "成本")]

        public decimal BcBomCost { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// </summary>
        [Required(ErrorMessage = "币种不能为空")]

        [ExcelColumn(Name = "币种")]

        public string BcCurrency { get; set; }

        /// <summary>
        /// 描述 :核算日期 
        /// </summary>
        [Required(ErrorMessage = "核算日期不能为空")]

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss")]

        public DateTime? BcBalancedate { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]

        public bool IsDelete { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注")]

        public string Remark { get; set; }

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