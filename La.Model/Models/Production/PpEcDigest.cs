using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 新旧物料，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    [SugarTable("pp_ec_digest")]
    public class PpEcDigest
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int EdId { get; set; }

        /// <summary>
        /// 描述 :输入日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EdBalanceDate { get; set; }

        /// <summary>
        /// 描述 :设变发行日 
        /// 空值 :true 
        /// </summary>
        public DateTime? EdIssueDate { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// 空值 :true 
        /// </summary>
        public string EdModel { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :true 
        /// </summary>
        public string Editem { get; set; }

        /// <summary>
        /// 描述 :设变号 
        /// 空值 :true 
        /// </summary>
        public string EdEcNo { get; set; }

        /// <summary>
        /// 描述 :旧物料 
        /// 空值 :true 
        /// </summary>
        public string EdOldItem { get; set; }

        /// <summary>
        /// 描述 :旧库存 
        /// 空值 :false 
        /// </summary>
        public decimal EdOldQty { get; set; }

        /// <summary>
        /// 描述 :PO数量 
        /// 空值 :false 
        /// </summary>
        public decimal EdPoQty { get; set; }

        /// <summary>
        /// 描述 :结算数量 
        /// 空值 :false 
        /// </summary>
        public decimal EdBalanceQty { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// 空值 :true 
        /// </summary>
        public string EdNewItem { get; set; }

        /// <summary>
        /// 描述 :新库存 
        /// 空值 :false 
        /// </summary>
        public decimal EdNewQty { get; set; }

        /// <summary>
        /// 描述 :处理方法 
        /// 空值 :true 
        /// </summary>
        public string EdDisposal { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EdNote { get; set; }

        /// <summary>
        /// 描述 :设变状态 
        /// 空值 :true 
        /// </summary>
        public string EdStatus { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// 空值 :true 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}