using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 新旧物料查询对象
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    public class PpEcDigestQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginEdIssueDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndEdIssueDate { get; set; }
        /// <summary>
        /// 描述 :机种 
        /// </summary>
        public string EdModel { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string Editem { get; set; }
        /// <summary>
        /// 描述 :设变号 
        /// </summary>
        public string EdEcNo { get; set; }
        /// <summary>
        /// 描述 :旧物料 
        /// </summary>
        public string EdOldItem { get; set; }
        /// <summary>
        /// 描述 :新物料 
        /// </summary>
        public string EdNewItem { get; set; }
    }

    /// <summary>
    /// 新旧物料输入输出对象
    /// </summary>
    public class PpEcDigestDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public int EdId { get; set; }

        /// <summary>
        /// 描述 :输入日期 
        /// </summary>

        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EdBalanceDate { get; set; }

        /// <summary>
        /// 描述 :设变发行日 
        /// </summary>

        [ExcelColumn(Name = "设变发行日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EdIssueDate { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// </summary>

        [ExcelColumn(Name = "机种")]
        public string EdModel { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>

        [ExcelColumn(Name = "物料")]
        public string Editem { get; set; }

        /// <summary>
        /// 描述 :设变号 
        /// </summary>

        [ExcelColumn(Name = "设变号")]
        public string EdEcNo { get; set; }

        /// <summary>
        /// 描述 :旧物料 
        /// </summary>

        [ExcelColumn(Name = "旧物料")]
        public string EdOldItem { get; set; }

        /// <summary>
        /// 描述 :旧库存 
        /// </summary>
        [Required(ErrorMessage = "旧库存不能为空")]

        [ExcelColumn(Name = "旧库存")]
        public decimal EdOldQty { get; set; }

        /// <summary>
        /// 描述 :PO数量 
        /// </summary>
        [Required(ErrorMessage = "PO数量不能为空")]

        [ExcelColumn(Name = "PO数量")]
        public decimal EdPoQty { get; set; }

        /// <summary>
        /// 描述 :结算数量 
        /// </summary>
        [Required(ErrorMessage = "结算数量不能为空")]

        [ExcelColumn(Name = "结算数量")]
        public decimal EdBalanceQty { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// </summary>

        [ExcelColumn(Name = "新物料")]
        public string EdNewItem { get; set; }

        /// <summary>
        /// 描述 :新库存 
        /// </summary>
        [Required(ErrorMessage = "新库存不能为空")]

        [ExcelColumn(Name = "新库存")]
        public decimal EdNewQty { get; set; }

        /// <summary>
        /// 描述 :处理方法 
        /// </summary>

        [ExcelColumn(Name = "处理方法")]
        public string EdDisposal { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EdNote { get; set; }

        /// <summary>
        /// 描述 :设变状态 
        /// </summary>

        [ExcelColumn(Name = "设变状态")]
        public string EdStatus { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// </summary>
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// </summary>
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// </summary>
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// </summary>
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// </summary>
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// </summary>
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>
        [ExcelIgnore]
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>
        [ExcelIgnore]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}