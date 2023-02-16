using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 月度存货明细查询对象
    /// </summary>
    public class FicoMonthInventoryQueryDto : PagerInfo 
    {
        public string MiPlant { get; set; }
        public string MiFy { get; set; }
        public string MiYm { get; set; }
        public string MiItem { get; set; }
        public string MiValType { get; set; }
        public string MiLocalCcy { get; set; }
    }

    /// <summary>
    /// 月度存货明细输入输出对象
    /// </summary>
    public class FicoMonthInventoryDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public string MiId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        public string MiPlant { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        public string MiFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        public string MiYm { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string MiItem { get; set; }

        [Required(ErrorMessage = "评估类不能为空")]
        [ExcelColumn(Name = "评估类")]
        public string MiValType { get; set; }

        [Required(ErrorMessage = "价格控制不能为空")]
        [ExcelColumn(Name = "价格控制")]
        public string MiPriceControl { get; set; }

        [Required(ErrorMessage = "移动平均价不能为空")]
        [ExcelColumn(Name = "移动平均价")]
        public decimal MiMovingAverage { get; set; }

        [Required(ErrorMessage = "Per单位不能为空")]
        [ExcelColumn(Name = "Per单位")]
        public int MiPerUnit { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        public string MiLocalCcy { get; set; }

        [Required(ErrorMessage = "库存不能为空")]
        [ExcelColumn(Name = "库存")]
        public decimal MiInventoryQty { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        [ExcelColumn(Name = "金额")]
        public decimal MiInventoryAmount { get; set; }

        [Required(ErrorMessage = "登录日期不能为空")]
        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MiBalancedate { get; set; }

        [ExcelIgnore]
        public bool IsDelete { get; set; }

        [ExcelIgnore]
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