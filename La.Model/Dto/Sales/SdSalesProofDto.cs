using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 销售凭证查询对象
    /// </summary>
    public class SdSalesProofQueryDto : PagerInfo 
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
        /// 描述 :客户 
        /// </summary>
        public string SpCustomerCode { get; set; }
        /// <summary>
        /// 描述 :利润中心 
        /// </summary>
        public string SpPrctr { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string SpSalesItem { get; set; }
    }

    /// <summary>
    /// 销售凭证输入输出对象
    /// </summary>
    public class SdSalesProofDto
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
        /// 描述 :销售凭证 
        /// </summary>
        [Required(ErrorMessage = "销售凭证不能为空")]

        [ExcelColumn(Name = "销售凭证")]
        public string SpProofNo { get; set; }

        /// <summary>
        /// 描述 :凭证明细 
        /// </summary>
        [Required(ErrorMessage = "凭证明细不能为空")]

        [ExcelColumn(Name = "凭证明细")]
        public string SpProofDetails { get; set; }

        /// <summary>
        /// 描述 :客户 
        /// </summary>
        [Required(ErrorMessage = "客户不能为空")]

        [ExcelColumn(Name = "客户")]
        public string SpCustomerCode { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// </summary>
        [Required(ErrorMessage = "利润中心不能为空")]

        [ExcelColumn(Name = "利润中心")]
        public string SpPrctr { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string SpSalesItem { get; set; }

        /// <summary>
        /// 描述 :科目 
        /// </summary>
        [Required(ErrorMessage = "科目不能为空")]

        [ExcelColumn(Name = "科目")]
        public string SpTitleCode { get; set; }

        /// <summary>
        /// 描述 :销售数量 
        /// </summary>
        [Required(ErrorMessage = "销售数量不能为空")]

        [ExcelColumn(Name = "销售数量")]
        public decimal SpSalesQty { get; set; }

        /// <summary>
        /// 描述 :销售单位 
        /// </summary>
        [Required(ErrorMessage = "销售单位不能为空")]

        [ExcelColumn(Name = "销售单位")]
        public string SpSalesUnit { get; set; }

        /// <summary>
        /// 描述 :原币销售额 
        /// </summary>
        [Required(ErrorMessage = "原币销售额不能为空")]

        [ExcelColumn(Name = "原币销售额")]
        public decimal SpOriginalAmount { get; set; }

        /// <summary>
        /// 描述 :原币币种 
        /// </summary>
        [Required(ErrorMessage = "原币币种不能为空")]

        [ExcelColumn(Name = "原币币种")]
        public string SpOriginalCcy { get; set; }

        /// <summary>
        /// 描述 :本币销售额 
        /// </summary>
        [Required(ErrorMessage = "本币销售额不能为空")]

        [ExcelColumn(Name = "本币销售额")]
        public decimal SpLocalAmount { get; set; }

        /// <summary>
        /// 描述 :本币币种 
        /// </summary>
        [Required(ErrorMessage = "本币币种不能为空")]

        [ExcelColumn(Name = "本币币种")]
        public string SpLocalCcy { get; set; }

        /// <summary>
        /// 描述 :参考凭证 
        /// </summary>
        [Required(ErrorMessage = "参考凭证不能为空")]

        [ExcelColumn(Name = "参考凭证")]
        public string SpReferenceNo { get; set; }

        /// <summary>
        /// 描述 :参考明细 
        /// </summary>
        [Required(ErrorMessage = "参考明细不能为空")]

        [ExcelColumn(Name = "参考明细")]
        public string SpReferenceDetails { get; set; }

        /// <summary>
        /// 描述 :过账日期 
        /// </summary>
        [Required(ErrorMessage = "过账日期不能为空")]

        [ExcelColumn(Name = "过账日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpPostingDate { get; set; }

        /// <summary>
        /// 描述 :用户 
        /// </summary>
        [Required(ErrorMessage = "用户不能为空")]

        [ExcelColumn(Name = "用户")]
        public string SpPostingUser { get; set; }

        /// <summary>
        /// 描述 :输入日期 
        /// </summary>
        [Required(ErrorMessage = "输入日期不能为空")]

        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpEntryDate { get; set; }

        /// <summary>
        /// 描述 :输入时间 
        /// </summary>
        [Required(ErrorMessage = "输入时间不能为空")]

        [ExcelColumn(Name = "输入时间")]
        public string SpEntryTime { get; set; }

        /// <summary>
        /// 描述 :来源 
        /// </summary>
        [Required(ErrorMessage = "来源不能为空")]

        [ExcelColumn(Name = "来源")]
        public string SpOrigin { get; set; }

        /// <summary>
        /// 描述 :产品组 
        /// </summary>
        [Required(ErrorMessage = "产品组不能为空")]

        [ExcelColumn(Name = "产品组")]
        public string SpPgroup { get; set; }

        /// <summary>
        /// 描述 :凭证类型 
        /// </summary>
        [Required(ErrorMessage = "凭证类型不能为空")]

        [ExcelColumn(Name = "凭证类型")]
        public string SpInvoiceType { get; set; }

        /// <summary>
        /// 描述 :凭证名称 
        /// </summary>
        [Required(ErrorMessage = "凭证名称不能为空")]

        [ExcelColumn(Name = "凭证名称")]
        public string SpInvoiceText { get; set; }

        /// <summary>
        /// 描述 :登入日期 
        /// </summary>
        [Required(ErrorMessage = "登入日期不能为空")]

        [ExcelColumn(Name = "登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpBalancedate { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelIgnore]
        public bool IsDelete { get; set; }

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