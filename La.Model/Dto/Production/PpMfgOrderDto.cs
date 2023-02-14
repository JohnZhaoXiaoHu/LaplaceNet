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
        public string MoPlant { get; set; }
        public string MoOrderType { get; set; }
        public string MoOrderNo { get; set; }
        public string MoOrderItem { get; set; }
        public string MoOrderlot { get; set; }
    }

    /// <summary>
    /// 生产工单输入输出对象
    /// </summary>
    public class PpMfgOrderDto
    {
        [ExcelColumn(Name = "ID")]
        public long? MoId { get; set; }

        [Required(ErrorMessage = "生产工厂不能为空")]
        [ExcelColumn(Name = "生产工厂")]
        public string MoPlant { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        [ExcelColumn(Name = "订单类型")]
        public string MoOrderType { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        [ExcelColumn(Name = "生产订单")]
        public string MoOrderNo { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string MoOrderItem { get; set; }

        [Required(ErrorMessage = "批次不能为空")]
        [ExcelColumn(Name = "批次")]
        public string MoOrderlot { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        public decimal MoOrderQty { get; set; }

        [Required(ErrorMessage = "生产数量不能为空")]
        [ExcelColumn(Name = "生产数量")]
        public decimal MoOrderProQty { get; set; }

        [Required(ErrorMessage = "订单日期不能为空")]
        [ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MoOrderDate { get; set; }

        [Required(ErrorMessage = "工艺路线不能为空")]
        [ExcelColumn(Name = "工艺路线")]
        public string MoOrderRoute { get; set; }

        [Required(ErrorMessage = "序列号不能为空")]
        [ExcelColumn(Name = "序列号")]
        public string MoOrderSerial { get; set; }

        [ExcelIgnore]
        public bool IsDelete { get; set; }

        [ExcelColumn(Name = "Remark")]
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