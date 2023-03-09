using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 生产工单查询对象
    /// </summary>
    public class PpMfgOrderQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :生产工厂 
        /// </summary>
        public string MoPlant { get; set; }
        /// <summary>
        /// 描述 :订单类型 
        /// </summary>
        public string MoOrderType { get; set; }
        /// <summary>
        /// 描述 :生产订单 
        /// </summary>
        public string MoOrderNo { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string MoOrderItem { get; set; }
        /// <summary>
        /// 描述 :批次 
        /// </summary>
        public string MoOrderlot { get; set; }
    }

    /// <summary>
    /// 生产工单输入输出对象
    /// </summary>
    public class PpMfgOrderDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>

        [ExcelColumn(Name = "ID")]
        public long? MoId { get; set; }

        /// <summary>
        /// 描述 :生产工厂 
        /// </summary>
        [Required(ErrorMessage = "生产工厂不能为空")]

        [ExcelColumn(Name = "生产工厂")]
        public string MoPlant { get; set; }

        /// <summary>
        /// 描述 :订单类型 
        /// </summary>
        [Required(ErrorMessage = "订单类型不能为空")]

        [ExcelColumn(Name = "订单类型")]
        public string MoOrderType { get; set; }

        /// <summary>
        /// 描述 :生产订单 
        /// </summary>
        [Required(ErrorMessage = "生产订单不能为空")]

        [ExcelColumn(Name = "生产订单")]
        public string MoOrderNo { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string MoOrderItem { get; set; }

        /// <summary>
        /// 描述 :批次 
        /// </summary>
        [Required(ErrorMessage = "批次不能为空")]

        [ExcelColumn(Name = "批次")]
        public string MoOrderlot { get; set; }

        /// <summary>
        /// 描述 :工单数量 
        /// </summary>
        [Required(ErrorMessage = "工单数量不能为空")]

        [ExcelColumn(Name = "工单数量")]
        public decimal MoOrderQty { get; set; }

        /// <summary>
        /// 描述 :生产数量 
        /// </summary>
        [Required(ErrorMessage = "生产数量不能为空")]

        [ExcelColumn(Name = "生产数量")]
        public decimal MoOrderProQty { get; set; }

        /// <summary>
        /// 描述 :订单日期 
        /// </summary>
        [Required(ErrorMessage = "订单日期不能为空")]

        [ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MoOrderDate { get; set; }

        /// <summary>
        /// 描述 :工艺路线 
        /// </summary>
        [Required(ErrorMessage = "工艺路线不能为空")]

        [ExcelColumn(Name = "工艺路线")]
        public string MoOrderRoute { get; set; }

        /// <summary>
        /// 描述 :序列号 
        /// </summary>
        [Required(ErrorMessage = "序列号不能为空")]

        [ExcelColumn(Name = "序列号")]
        public string MoOrderSerial { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "Remark")]
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