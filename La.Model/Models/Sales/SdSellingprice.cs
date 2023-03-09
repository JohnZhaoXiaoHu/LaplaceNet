using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 销售价格，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [SugarTable("sd_sellingprice")]
    public class SdSellingprice
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
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string SpItem { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// 空值 :false 
        /// </summary>
        public string SpItemText { get; set; }

        /// <summary>
        /// 描述 :原币价格 
        /// 空值 :false 
        /// </summary>
        public decimal SpOriginalFob { get; set; }

        /// <summary>
        /// 描述 :原币种 
        /// 空值 :false 
        /// </summary>
        public string SpOriginalCcy { get; set; }

        /// <summary>
        /// 描述 :原币Per单位 
        /// 空值 :false 
        /// </summary>
        public int SpOriginalPerUnit { get; set; }

        /// <summary>
        /// 描述 :原币利润中心 
        /// 空值 :false 
        /// </summary>
        public string SpOriginalPrctr { get; set; }

        /// <summary>
        /// 描述 :本币价格 
        /// 空值 :false 
        /// </summary>
        public decimal SpLocalFob { get; set; }

        /// <summary>
        /// 描述 :本币种 
        /// 空值 :false 
        /// </summary>
        public string SpLocalCcy { get; set; }

        /// <summary>
        /// 描述 :本币Per单位 
        /// 空值 :false 
        /// </summary>
        public int SpLocalPerUnit { get; set; }

        /// <summary>
        /// 描述 :本币利润中心 
        /// 空值 :false 
        /// </summary>
        public string SpLocalPrctr { get; set; }

        /// <summary>
        /// 描述 :生效日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? SpEffDate { get; set; }

        /// <summary>
        /// 描述 :失效日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? SpExpDate { get; set; }

        /// <summary>
        /// 描述 :登录日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? SpBalancedate { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

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