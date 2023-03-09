using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// bom成本核算，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [SugarTable("fico_bom_costing")]
    public class FicoBomCosting
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long BcId { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string BcPlant { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// 空值 :false 
        /// </summary>
        public string BcFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
        public string BcYm { get; set; }

        /// <summary>
        /// 描述 :成品物料 
        /// 空值 :false 
        /// </summary>
        public string BcBomItem { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// 空值 :false 
        /// </summary>
        public string BcItemText { get; set; }

        /// <summary>
        /// 描述 :成本 
        /// 空值 :false 
        /// </summary>
        public decimal BcBomCost { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// 空值 :false 
        /// </summary>
        public string BcCurrency { get; set; }

        /// <summary>
        /// 描述 :核算日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? BcBalancedate { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 :备注 
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