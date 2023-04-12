using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 月度存货查询对象
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    public class FicoMonthInventoryQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        public string MiPlant { get; set; }
        /// <summary>
        /// 描述 :年月 
        /// </summary>
        public string MiYm { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string MiItem { get; set; }
    }

    /// <summary>
    /// 月度存货输入输出对象
    /// </summary>
    public class FicoMonthInventoryDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public string MiId { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]
        public string MiPlant { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// </summary>
        [Required(ErrorMessage = "期间不能为空")]

        [ExcelColumn(Name = "期间")]
        public string MiFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// </summary>
        [Required(ErrorMessage = "年月不能为空")]

        [ExcelColumn(Name = "年月")]
        public string MiYm { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string MiItem { get; set; }

        /// <summary>
        /// 描述 :评估类 
        /// </summary>
        [Required(ErrorMessage = "评估类不能为空")]

        [ExcelColumn(Name = "评估类")]
        public string MiValType { get; set; }

        /// <summary>
        /// 描述 :价格控制 
        /// </summary>
        [Required(ErrorMessage = "价格控制不能为空")]

        [ExcelColumn(Name = "价格控制")]
        public string MiPriceControl { get; set; }

        /// <summary>
        /// 描述 :移动平均价 
        /// </summary>
        [Required(ErrorMessage = "移动平均价不能为空")]

        [ExcelColumn(Name = "移动平均价")]
        public decimal MiMovingAverage { get; set; }

        /// <summary>
        /// 描述 :Per单位 
        /// </summary>
        [Required(ErrorMessage = "Per单位不能为空")]

        [ExcelColumn(Name = "Per单位")]
        public int MiPerUnit { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// </summary>
        [Required(ErrorMessage = "币种不能为空")]

        [ExcelColumn(Name = "币种")]
        public string MiLocalCcy { get; set; }

        /// <summary>
        /// 描述 :库存 
        /// </summary>
        [Required(ErrorMessage = "库存不能为空")]

        [ExcelColumn(Name = "库存")]
        public decimal MiInventoryQty { get; set; }

        /// <summary>
        /// 描述 :金额 
        /// </summary>
        [Required(ErrorMessage = "金额不能为空")]

        [ExcelColumn(Name = "金额")]
        public decimal MiInventoryAmount { get; set; }

        /// <summary>
        /// 描述 :登录日期 
        /// </summary>
        [Required(ErrorMessage = "登录日期不能为空")]

        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MiBalancedate { get; set; }

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