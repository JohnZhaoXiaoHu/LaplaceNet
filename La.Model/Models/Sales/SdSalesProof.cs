using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 销售凭证，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-03
    /// </summary>
    [SugarTable("sd_sales_proof")]
    public class SdSalesProof
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long SpId { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string SpPlnt { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// 空值 :false 
        /// </summary>
        public string SpFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
        public string SpYm { get; set; }

        /// <summary>
        /// 描述 :销售凭证 
        /// 空值 :false 
        /// </summary>
        public string SpProofNo { get; set; }

        /// <summary>
        /// 描述 :凭证明细 
        /// 空值 :false 
        /// </summary>
        public string SpProofDetails { get; set; }

        /// <summary>
        /// 描述 :客户 
        /// 空值 :false 
        /// </summary>
        public string SpCustomerCode { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
        public string SpPrctr { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string SpSalesItem { get; set; }

        /// <summary>
        /// 描述 :科目 
        /// 空值 :false 
        /// </summary>
        public string SpTitleCode { get; set; }

        /// <summary>
        /// 描述 :销售数量 
        /// 空值 :false 
        /// </summary>
        public decimal SpSalesQty { get; set; }

        /// <summary>
        /// 描述 :销售单位 
        /// 空值 :false 
        /// </summary>
        public string SpSalesUnit { get; set; }

        /// <summary>
        /// 描述 :原币销售额 
        /// 空值 :false 
        /// </summary>
        public decimal SpOriginalAmount { get; set; }

        /// <summary>
        /// 描述 :原币币种 
        /// 空值 :false 
        /// </summary>
        public string SpOriginalCcy { get; set; }

        /// <summary>
        /// 描述 :本币销售额 
        /// 空值 :false 
        /// </summary>
        public decimal SpLocalAmount { get; set; }

        /// <summary>
        /// 描述 :本币币种 
        /// 空值 :false 
        /// </summary>
        public string SpLocalCcy { get; set; }

        /// <summary>
        /// 描述 :参考凭证 
        /// 空值 :false 
        /// </summary>
        public string SpReferenceNo { get; set; }

        /// <summary>
        /// 描述 :参考明细 
        /// 空值 :false 
        /// </summary>
        public string SpReferenceDetails { get; set; }

        /// <summary>
        /// 描述 :过账日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? SpPostingDate { get; set; }

        /// <summary>
        /// 描述 :用户 
        /// 空值 :false 
        /// </summary>
        public string SpPostingUser { get; set; }

        /// <summary>
        /// 描述 :输入日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? SpEntryDate { get; set; }

        /// <summary>
        /// 描述 :输入时间 
        /// 空值 :false 
        /// </summary>
        public string SpEntryTime { get; set; }

        /// <summary>
        /// 描述 :来源 
        /// 空值 :false 
        /// </summary>
        public string SpOrigin { get; set; }

        /// <summary>
        /// 描述 :产品组 
        /// 空值 :false 
        /// </summary>
        public string SpPgroup { get; set; }

        /// <summary>
        /// 描述 :凭证类型 
        /// 空值 :false 
        /// </summary>
        public string SpInvoiceType { get; set; }

        /// <summary>
        /// 描述 :凭证名称 
        /// 空值 :false 
        /// </summary>
        public string SpInvoiceText { get; set; }

        /// <summary>
        /// 描述 :登入日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? SpBalancedate { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :false 
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}