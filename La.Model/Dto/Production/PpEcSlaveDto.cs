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
    /// @date 2023-05-02
    /// </summary>
    public class PpEcSlaveQueryDto : PagerInfo 
    {
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
        /// <summary>
        /// 描述 :子物料 
        /// </summary>
        public string EsSubItem { get; set; }
        /// <summary>
        /// 描述 :旧物料 
        /// </summary>
        public string EsOldItem { get; set; }
        /// <summary>
        /// 描述 :新物料 
        /// </summary>
        public string EsNewItem { get; set; }
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
        /// 描述 :实施部门 
        /// </summary>
        [Required(ErrorMessage = "实施部门不能为空")]

        [ExcelColumn(Name = "实施部门")]
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// </summary>
        [Required(ErrorMessage = "采购类型不能为空")]

        [ExcelColumn(Name = "采购类型")]
        public string EsPurType { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// </summary>
        [Required(ErrorMessage = "仓库不能为空")]

        [ExcelColumn(Name = "仓库")]
        public string EsSloc { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// </summary>

        [ExcelColumn(Name = "检验否")]
        public string EsInsmk { get; set; }

        /// <summary>
        /// 描述 :工厂状态 
        /// </summary>

        [ExcelColumn(Name = "工厂状态")]
        public string EsMstae { get; set; }

        /// <summary>
        /// 描述 :SOP 
        /// </summary>
        [Required(ErrorMessage = "SOP不能为空")]

        [ExcelColumn(Name = "SOP")]
        public byte EsSopStae { get; set; }

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
        /// 描述 :采购登入日期 
        /// </summary>

        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurEntryDate { get; set; }

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
        /// 描述 :EsPurCreator 
        /// </summary>

        [ExcelColumn(Name = "EsPurCreator")]
        public string EsPurCreator { get; set; }

        /// <summary>
        /// 描述 :EsPurCreateTime 
        /// </summary>

        [ExcelColumn(Name = "EsPurCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPurModifier 
        /// </summary>

        [ExcelColumn(Name = "EsPurModifier")]
        public string EsPurModifier { get; set; }

        /// <summary>
        /// 描述 :EsPurModifyTime 
        /// </summary>

        [ExcelColumn(Name = "EsPurModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPurModifyTime { get; set; }

        /// <summary>
        /// 描述 :生管登入日期 
        /// </summary>

        [ExcelColumn(Name = "生管登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcEntryDate { get; set; }

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
        /// 描述 :EsPmcCreator 
        /// </summary>

        [ExcelColumn(Name = "EsPmcCreator")]
        public string EsPmcCreator { get; set; }

        /// <summary>
        /// 描述 :EsPmcCreateTime 
        /// </summary>

        [ExcelColumn(Name = "EsPmcCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPmcModifier 
        /// </summary>

        [ExcelColumn(Name = "EsPmcModifier")]
        public string EsPmcModifier { get; set; }

        /// <summary>
        /// 描述 :EsPmcModifyTime 
        /// </summary>

        [ExcelColumn(Name = "EsPmcModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPmcModifyTime { get; set; }

        /// <summary>
        /// 描述 :IQC登入日期 
        /// </summary>

        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcEntryDate { get; set; }

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
        /// 描述 :EsIqcCreator 
        /// </summary>

        [ExcelColumn(Name = "EsIqcCreator")]
        public string EsIqcCreator { get; set; }

        /// <summary>
        /// 描述 :EsIqcCreateTime 
        /// </summary>

        [ExcelColumn(Name = "EsIqcCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsIqcModifier 
        /// </summary>

        [ExcelColumn(Name = "EsIqcModifier")]
        public string EsIqcModifier { get; set; }

        /// <summary>
        /// 描述 :EsIqcModifyTime 
        /// </summary>

        [ExcelColumn(Name = "EsIqcModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsIqcModifyTime { get; set; }

        /// <summary>
        /// 描述 :部管登入日期 
        /// </summary>

        [ExcelColumn(Name = "部管登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmEntryDate { get; set; }

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
        /// 描述 :EsMmCreator 
        /// </summary>

        [ExcelColumn(Name = "EsMmCreator")]
        public string EsMmCreator { get; set; }

        /// <summary>
        /// 描述 :EsMmCreateTime 
        /// </summary>

        [ExcelColumn(Name = "EsMmCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsMmModifier 
        /// </summary>

        [ExcelColumn(Name = "EsMmModifier")]
        public string EsMmModifier { get; set; }

        /// <summary>
        /// 描述 :EsMmModifyTime 
        /// </summary>

        [ExcelColumn(Name = "EsMmModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsMmModifyTime { get; set; }

        /// <summary>
        /// 描述 :制一登入日期 
        /// </summary>

        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpEntryDate { get; set; }

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
        /// 描述 :EsPpCreator 
        /// </summary>

        [ExcelColumn(Name = "EsPpCreator")]
        public string EsPpCreator { get; set; }

        /// <summary>
        /// 描述 :EsPpCreateTime 
        /// </summary>

        [ExcelColumn(Name = "EsPpCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPpModifier 
        /// </summary>

        [ExcelColumn(Name = "EsPpModifier")]
        public string EsPpModifier { get; set; }

        /// <summary>
        /// 描述 :EsPpModifyTime 
        /// </summary>

        [ExcelColumn(Name = "EsPpModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPpModifyTime { get; set; }

        /// <summary>
        /// 描述 :制二登入日期 
        /// </summary>

        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaEntryDate { get; set; }

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
        /// 描述 :EsPcbaCreator 
        /// </summary>

        [ExcelColumn(Name = "EsPcbaCreator")]
        public string EsPcbaCreator { get; set; }

        /// <summary>
        /// 描述 :EsPcbaCreateTime 
        /// </summary>

        [ExcelColumn(Name = "EsPcbaCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPcbaModifier 
        /// </summary>

        [ExcelColumn(Name = "EsPcbaModifier")]
        public string EsPcbaModifier { get; set; }

        /// <summary>
        /// 描述 :EsPcbaModifyTime 
        /// </summary>

        [ExcelColumn(Name = "EsPcbaModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsPcbaModifyTime { get; set; }

        /// <summary>
        /// 描述 :QA确认日期 
        /// </summary>

        [ExcelColumn(Name = "QA确认日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaEntryDate { get; set; }

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
        /// 描述 :EsQaCreator 
        /// </summary>

        [ExcelColumn(Name = "EsQaCreator")]
        public string EsQaCreator { get; set; }

        /// <summary>
        /// 描述 :EsQaCreateTime 
        /// </summary>

        [ExcelColumn(Name = "EsQaCreateTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsQaModifier 
        /// </summary>

        [ExcelColumn(Name = "EsQaModifier")]
        public string EsQaModifier { get; set; }

        /// <summary>
        /// 描述 :EsQaModifyTime 
        /// </summary>

        [ExcelColumn(Name = "EsQaModifyTime", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? EsQaModifyTime { get; set; }

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