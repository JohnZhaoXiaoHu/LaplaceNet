using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 销售价格查询对象
    /// </summary>
    public class SdSellingpriceQueryDto : PagerInfo 
    {
        public string SpPlnt { get; set; }
        public string SpYm { get; set; }
        public string SpItem { get; set; }
        public string SpItemText { get; set; }
        public DateTime? BeginSpEffDate { get; set; }
        public DateTime? EndSpEffDate { get; set; }
    }

    /// <summary>
    /// 销售价格输入输出对象
    /// </summary>
    public class SdSellingpriceDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long SpId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        public string SpPlnt { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        public string SpFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        public string SpYm { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string SpItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        public string SpItemText { get; set; }

        [Required(ErrorMessage = "原币价格不能为空")]
        [ExcelColumn(Name = "原币价格")]
        public decimal SpOriginalFob { get; set; }

        [Required(ErrorMessage = "原币种不能为空")]
        [ExcelColumn(Name = "原币种")]
        public string SpOriginalCcy { get; set; }

        [Required(ErrorMessage = "原币Per单位不能为空")]
        [ExcelColumn(Name = "原币Per单位")]
        public int SpOriginalPerUnit { get; set; }

        [Required(ErrorMessage = "原币利润中心不能为空")]
        [ExcelColumn(Name = "原币利润中心")]
        public string SpOriginalPrctr { get; set; }

        [Required(ErrorMessage = "本币价格不能为空")]
        [ExcelColumn(Name = "本币价格")]
        public decimal SpLocalFob { get; set; }

        [Required(ErrorMessage = "本币种不能为空")]
        [ExcelColumn(Name = "本币种")]
        public string SpLocalCcy { get; set; }

        [Required(ErrorMessage = "本币Per单位不能为空")]
        [ExcelColumn(Name = "本币Per单位")]
        public int SpLocalPerUnit { get; set; }

        [Required(ErrorMessage = "本币利润中心不能为空")]
        [ExcelColumn(Name = "本币利润中心")]
        public string SpLocalPrctr { get; set; }

        [Required(ErrorMessage = "生效日期不能为空")]
        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpEffDate { get; set; }

        [Required(ErrorMessage = "失效日期不能为空")]
        [ExcelColumn(Name = "失效日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpExpDate { get; set; }

        [Required(ErrorMessage = "登录日期不能为空")]
        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpBalancedate { get; set; }

        [ExcelIgnore]
        public bool IsDeleted { get; set; }

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