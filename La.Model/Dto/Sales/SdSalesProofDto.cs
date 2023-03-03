﻿using System;
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
        public string SpPlnt { get; set; }
        public string SpYm { get; set; }
        public string SpCustomerCode { get; set; }
        public string SpPrctr { get; set; }
        public string SpSalesItem { get; set; }
    }

    /// <summary>
    /// 销售凭证输入输出对象
    /// </summary>
    public class SdSalesProofDto
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

        [Required(ErrorMessage = "销售凭证不能为空")]
        [ExcelColumn(Name = "销售凭证")]
        public string SpProofNo { get; set; }

        [Required(ErrorMessage = "凭证明细不能为空")]
        [ExcelColumn(Name = "凭证明细")]
        public string SpProofDetails { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        [ExcelColumn(Name = "客户")]
        public string SpCustomerCode { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        public string SpPrctr { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string SpSalesItem { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        public string SpTitleCode { get; set; }

        [Required(ErrorMessage = "销售数量不能为空")]
        [ExcelColumn(Name = "销售数量")]
        public decimal SpSalesQty { get; set; }

        [Required(ErrorMessage = "销售单位不能为空")]
        [ExcelColumn(Name = "销售单位")]
        public string SpSalesUnit { get; set; }

        [Required(ErrorMessage = "原币销售额不能为空")]
        [ExcelColumn(Name = "原币销售额")]
        public decimal SpOriginalAmount { get; set; }

        [Required(ErrorMessage = "原币币种不能为空")]
        [ExcelColumn(Name = "原币币种")]
        public string SpOriginalCcy { get; set; }

        [Required(ErrorMessage = "本币销售额不能为空")]
        [ExcelColumn(Name = "本币销售额")]
        public decimal SpLocalAmount { get; set; }

        [Required(ErrorMessage = "本币币种不能为空")]
        [ExcelColumn(Name = "本币币种")]
        public string SpLocalCcy { get; set; }

        [Required(ErrorMessage = "参考凭证不能为空")]
        [ExcelColumn(Name = "参考凭证")]
        public string SpReferenceNo { get; set; }

        [Required(ErrorMessage = "参考明细不能为空")]
        [ExcelColumn(Name = "参考明细")]
        public string SpReferenceDetails { get; set; }

        [Required(ErrorMessage = "过账日期不能为空")]
        [ExcelColumn(Name = "过账日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpPostingDate { get; set; }

        [Required(ErrorMessage = "用户不能为空")]
        [ExcelColumn(Name = "用户")]
        public string SpPostingUser { get; set; }

        [Required(ErrorMessage = "输入日期不能为空")]
        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpEntryDate { get; set; }

        [Required(ErrorMessage = "输入时间不能为空")]
        [ExcelColumn(Name = "输入时间")]
        public string SpEntryTime { get; set; }

        [Required(ErrorMessage = "来源不能为空")]
        [ExcelColumn(Name = "来源")]
        public string SpOrigin { get; set; }

        [Required(ErrorMessage = "产品组不能为空")]
        [ExcelColumn(Name = "产品组")]
        public string SpPgroup { get; set; }

        [Required(ErrorMessage = "凭证类型不能为空")]
        [ExcelColumn(Name = "凭证类型")]
        public string SpInvoiceType { get; set; }

        [Required(ErrorMessage = "凭证名称不能为空")]
        [ExcelColumn(Name = "凭证名称")]
        public string SpInvoiceText { get; set; }

        [Required(ErrorMessage = "登入日期不能为空")]
        [ExcelColumn(Name = "登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? SpBalancedate { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
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