using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 月度存货明细，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [SugarTable("fico_month_inventory")]
    public class FicoMonthInventory
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string MiId { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string MiPlant { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// 空值 :false 
        /// </summary>
        public string MiFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
        public string MiYm { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string MiItem { get; set; }

        /// <summary>
        /// 描述 :评估类 
        /// 空值 :false 
        /// </summary>
        public string MiValType { get; set; }

        /// <summary>
        /// 描述 :价格控制 
        /// 空值 :false 
        /// </summary>
        public string MiPriceControl { get; set; }

        /// <summary>
        /// 描述 :移动平均价 
        /// 空值 :false 
        /// </summary>
        public decimal MiMovingAverage { get; set; }

        /// <summary>
        /// 描述 :Per单位 
        /// 空值 :false 
        /// </summary>
        public int MiPerUnit { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// 空值 :false 
        /// </summary>
        public string MiLocalCcy { get; set; }

        /// <summary>
        /// 描述 :库存 
        /// 空值 :false 
        /// </summary>
        public decimal MiInventoryQty { get; set; }

        /// <summary>
        /// 描述 :金额 
        /// 空值 :false 
        /// </summary>
        public decimal MiInventoryAmount { get; set; }

        /// <summary>
        /// 描述 :登录日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? MiBalancedate { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
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