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
        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        public string SpPlnt { get; set; }
        /// <summary>
        /// 描述 :年月 
        /// </summary>
        public string SpYm { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string SpItem { get; set; }
        /// <summary>
        /// 描述 :物料文本 
        /// </summary>
        public string SpItemText { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginSpEffDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndSpEffDate { get; set; }
    }

    /// <summary>
    /// 销售价格输入输出对象
    /// </summary>
    public class SdSellingpriceDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public long SpId { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]
        public string SpPlnt { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// </summary>
        [Required(ErrorMessage = "期间不能为空")]

        [ExcelColumn(Name = "期间")]
        public string SpFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// </summary>
        [Required(ErrorMessage = "年月不能为空")]

        [ExcelColumn(Name = "年月")]
        public string SpYm { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string SpItem { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// </summary>
        [Required(ErrorMessage = "物料文本不能为空")]

        [ExcelColumn(Name = "物料文本")]
        public string SpItemText { get; set; }

        /// <summary>
        /// 描述 :原币价格 
        /// </summary>
        [Required(ErrorMessage = "原币价格不能为空")]

        [ExcelColumn(Name = "原币价格")]
        public decimal SpOriginalFob { get; set; }

        /// <summary>
        /// 描述 :原币种 
        /// </summary>
        [Required(ErrorMessage = "原币种不能为空")]

        [ExcelColumn(Name = "原币种")]
        public string SpOriginalCcy { get; set; }

        /// <summary>
        /// 描述 :原币Per单位 
        /// </summary>
        [Required(ErrorMessage = "原币Per单位不能为空")]

        [ExcelColumn(Name = "原币Per单位")]
        public int SpOriginalPerUnit { get; set; }

        /// <summary>
        /// 描述 :原币利润中心 
        /// </summary>
        [Required(ErrorMessage = "原币利润中心不能为空")]

        [ExcelColumn(Name = "原币利润中心")]
        public string SpOriginalPrctr { get; set; }

        /// <summary>
        /// 描述 :本币价格 
        /// </summary>
        [Required(ErrorMessage = "本币价格不能为空")]

        [ExcelColumn(Name = "本币价格")]
        public decimal SpLocalFob { get; set; }

        /// <summary>
        /// 描述 :本币种 
        /// </summary>
        [Required(ErrorMessage = "本币种不能为空")]

        [ExcelColumn(Name = "本币种")]
        public string SpLocalCcy { get; set; }

        /// <summary>
        /// 描述 :本币Per单位 
        /// </summary>
        [Required(ErrorMessage = "本币Per单位不能为空")]

        [ExcelColumn(Name = "本币Per单位")]
        public int SpLocalPerUnit { get; set; }

        /// <summary>
        /// 描述 :本币利润中心 
        /// </summary>
        [Required(ErrorMessage = "本币利润中心不能为空")]

        [ExcelColumn(Name = "本币利润中心")]
        public string SpLocalPrctr { get; set; }

        /// <summary>
        /// 描述 :生效日期 
        /// </summary>
        [Required(ErrorMessage = "生效日期不能为空")]

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpEffDate { get; set; }

        /// <summary>
        /// 描述 :失效日期 
        /// </summary>
        [Required(ErrorMessage = "失效日期不能为空")]

        [ExcelColumn(Name = "失效日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpExpDate { get; set; }

        /// <summary>
        /// 描述 :登录日期 
        /// </summary>
        [Required(ErrorMessage = "登录日期不能为空")]

        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpBalancedate { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        [ExcelIgnore]
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