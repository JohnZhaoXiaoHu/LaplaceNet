using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 从设变查询对象
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    public class PpEcSlaveQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginEsEntryDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndEsEntryDate { get; set; }
        /// <summary>
        /// 描述 :设变No. 
        /// </summary>
        public string EsEcNo { get; set; }
        /// <summary>
        /// 描述 :机种 
        /// </summary>
        public string EsModel { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string EsItem { get; set; }
    }

    /// <summary>
    /// 从设变输入输出对象
    /// </summary>
    public class PpEcSlaveDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public int EsId { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// </summary>
        [Required(ErrorMessage = "输入日不能为空")]

        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsEntryDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// </summary>
        [Required(ErrorMessage = "设变No.不能为空")]

        [ExcelColumn(Name = "设变No.")]
        public string EsEcNo { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// </summary>
        [Required(ErrorMessage = "机种不能为空")]

        [ExcelColumn(Name = "机种")]
        public string EsModel { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string EsItem { get; set; }

        /// <summary>
        /// 描述 :子物料 
        /// </summary>

        [ExcelColumn(Name = "子物料")]
        public string EsSubItem { get; set; }

        /// <summary>
        /// 描述 :旧物料 
        /// </summary>

        [ExcelColumn(Name = "旧物料")]
        public string EsOldItem { get; set; }

        /// <summary>
        /// 描述 :旧文本 
        /// </summary>

        [ExcelColumn(Name = "旧文本")]
        public string EsOldItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// </summary>
        [Required(ErrorMessage = "用量不能为空")]

        [ExcelColumn(Name = "用量")]
        public decimal EsOldUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// </summary>

        [ExcelColumn(Name = "位置")]
        public string EsOldSetLoc { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// </summary>
        [Required(ErrorMessage = "新物料不能为空")]

        [ExcelColumn(Name = "新物料")]
        public string EsNewItem { get; set; }

        /// <summary>
        /// 描述 :新文本 
        /// </summary>

        [ExcelColumn(Name = "新文本")]
        public string EsNewItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// </summary>
        [Required(ErrorMessage = "用量不能为空")]

        [ExcelColumn(Name = "用量")]
        public decimal EsNewUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// </summary>

        [ExcelColumn(Name = "位置")]
        public string EsNewSetLoc { get; set; }

        /// <summary>
        /// 描述 :bom番号 
        /// </summary>

        [ExcelColumn(Name = "bom番号")]
        public string EsBomNo { get; set; }

        /// <summary>
        /// 描述 :互换 
        /// </summary>

        [ExcelColumn(Name = "互换")]
        public string EsChange { get; set; }

        /// <summary>
        /// 描述 :区分 
        /// </summary>

        [ExcelColumn(Name = "区分")]
        public string Eslocal { get; set; }

        /// <summary>
        /// 描述 :指示 
        /// </summary>

        [ExcelColumn(Name = "指示")]
        public string Esnote { get; set; }

        /// <summary>
        /// 描述 :旧品处理 
        /// </summary>

        [ExcelColumn(Name = "旧品处理")]
        public string EsOldProcess { get; set; }

        /// <summary>
        /// 描述 :bom日期 
        /// </summary>
        [Required(ErrorMessage = "bom日期不能为空")]

        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsBomDate { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// </summary>
        [Required(ErrorMessage = "采购类型不能为空")]

        [ExcelColumn(Name = "采购类型")]
        public string EsPurType { get; set; }

        /// <summary>
        /// 描述 :实施部门 
        /// </summary>
        [Required(ErrorMessage = "实施部门不能为空")]

        [ExcelColumn(Name = "实施部门")]
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// </summary>
        [Required(ErrorMessage = "仓库不能为空")]

        [ExcelColumn(Name = "仓库")]
        public string EsSloc { get; set; }

        /// <summary>
        /// 描述 :旧品库存 
        /// </summary>
        [Required(ErrorMessage = "旧品库存不能为空")]

        [ExcelColumn(Name = "旧品库存")]
        public decimal EsOldCurrStock { get; set; }

        /// <summary>
        /// 描述 :新品库存 
        /// </summary>
        [Required(ErrorMessage = "新品库存不能为空")]

        [ExcelColumn(Name = "新品库存")]
        public decimal EsNewCurrStock { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// </summary>
        [Required(ErrorMessage = "检验否不能为空")]

        [ExcelColumn(Name = "检验否")]
        public byte EsInsmk { get; set; }

        /// <summary>
        /// 描述 :工厂状态 
        /// </summary>
        [Required(ErrorMessage = "工厂状态不能为空")]

        [ExcelColumn(Name = "工厂状态")]
        public string EsMstae { get; set; }

        /// <summary>
        /// 描述 :部门录入日 
        /// </summary>

        [ExcelColumn(Name = "部门录入日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsDeptEntryDate { get; set; }

        /// <summary>
        /// 描述 :部门名称 
        /// </summary>

        [ExcelColumn(Name = "部门名称")]
        public string EsDeptName { get; set; }

        /// <summary>
        /// 描述 :供应商 
        /// </summary>

        [ExcelColumn(Name = "供应商")]
        public string EsSupplier { get; set; }

        /// <summary>
        /// 描述 :采购PO 
        /// </summary>

        [ExcelColumn(Name = "采购PO")]
        public string EsPurOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsPurNote { get; set; }

        /// <summary>
        /// 描述 :预投入批次 
        /// </summary>

        [ExcelColumn(Name = "预投入批次")]
        public string EsPmcLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsPmcMemo { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>

        [ExcelColumn(Name = "备注")]
        public string EsPmcNote { get; set; }

        /// <summary>
        /// 描述 :检验订单 
        /// </summary>

        [ExcelColumn(Name = "检验订单")]
        public string EsIqcOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsIqcNote { get; set; }

        /// <summary>
        /// 描述 :领用批次 
        /// </summary>

        [ExcelColumn(Name = "领用批次")]
        public string EsMmLot { get; set; }

        /// <summary>
        /// 描述 :工单 
        /// </summary>

        [ExcelColumn(Name = "工单")]
        public string EsMmMocNo { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsMmNote { get; set; }

        /// <summary>
        /// 描述 :班组 
        /// </summary>

        [ExcelColumn(Name = "班组")]
        public string EsPpLine { get; set; }

        /// <summary>
        /// 描述 :生产批次 
        /// </summary>

        [ExcelColumn(Name = "生产批次")]
        public string EsPpLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsPpNote { get; set; }

        /// <summary>
        /// 描述 :Pcba班组 
        /// </summary>

        [ExcelColumn(Name = "Pcba班组")]
        public string EsPcbaLine { get; set; }

        /// <summary>
        /// 描述 :Pcba批次 
        /// </summary>

        [ExcelColumn(Name = "Pcba批次")]
        public string EsPcbaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsPcbaNote { get; set; }

        /// <summary>
        /// 描述 :检验批次 
        /// </summary>

        [ExcelColumn(Name = "检验批次")]
        public string EsQaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>

        [ExcelColumn(Name = "说明")]
        public string EsQaNote { get; set; }

        /// <summary>
        /// 描述 :EsDeptCreator 
        /// </summary>

        [ExcelColumn(Name = "EsDeptCreator")]
        public string EsDeptCreator { get; set; }

        /// <summary>
        /// 描述 :EsDeptCreateTime 
        /// </summary>

        [ExcelColumn(Name = "EsDeptCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsDeptCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsDeptModifier 
        /// </summary>

        [ExcelColumn(Name = "EsDeptModifier")]
        public string EsDeptModifier { get; set; }

        /// <summary>
        /// 描述 :EsDeptModifyTime 
        /// </summary>

        [ExcelColumn(Name = "EsDeptModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsDeptModifyTime { get; set; }

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