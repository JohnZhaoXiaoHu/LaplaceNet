using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 生产工单，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-09
    /// </summary>
    [SugarTable("pp_mfg_order")]
    public class PpMfgOrder
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long? MoId { get; set; }

        /// <summary>
        /// 描述 :生产工厂 
        /// 空值 :false 
        /// </summary>
        public string MoPlant { get; set; }

        /// <summary>
        /// 描述 :订单类型 
        /// 空值 :false 
        /// </summary>
        public string MoOrderType { get; set; }

        /// <summary>
        /// 描述 :生产订单 
        /// 空值 :false 
        /// </summary>
        public string MoOrderNo { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string MoOrderItem { get; set; }

        /// <summary>
        /// 描述 :批次 
        /// 空值 :false 
        /// </summary>
        public string MoOrderlot { get; set; }

        /// <summary>
        /// 描述 :工单数量 
        /// 空值 :false 
        /// </summary>
        public decimal MoOrderQty { get; set; }

        /// <summary>
        /// 描述 :生产数量 
        /// 空值 :false 
        /// </summary>
        public decimal MoOrderProQty { get; set; }

        /// <summary>
        /// 描述 :订单日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? MoOrderDate { get; set; }

        /// <summary>
        /// 描述 :工艺路线 
        /// 空值 :false 
        /// </summary>
        public string MoOrderRoute { get; set; }

        /// <summary>
        /// 描述 :序列号 
        /// 空值 :false 
        /// </summary>
        public string MoOrderSerial { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 : 
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