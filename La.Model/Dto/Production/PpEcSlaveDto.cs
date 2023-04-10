using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 从设变信息表查询对象
    /// </summary>
    public class PpEcSlaveQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 从设变信息表输入输出对象
    /// </summary>
    public class PpEcSlaveDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        public int EsId { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// </summary>
        [Required(ErrorMessage = "输入日不能为空")]
        public DateTime? EsEntryDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// </summary>
        [Required(ErrorMessage = "设变No.不能为空")]
        public string EsEcNo { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// </summary>
        [Required(ErrorMessage = "机种不能为空")]
        public string EsModel { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]
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
        /// 描述 :旧文本 
        /// </summary>
        public string EsOldItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// </summary>
        [Required(ErrorMessage = "用量不能为空")]
        public decimal EsOldUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// </summary>
        public string EsOldSetLoc { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// </summary>
        public string EsNewItem { get; set; }

        /// <summary>
        /// 描述 :新文本 
        /// </summary>
        public string EsNewItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// </summary>
        [Required(ErrorMessage = "用量不能为空")]
        public decimal EsNewUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// </summary>
        public string EsNewSetLoc { get; set; }

        /// <summary>
        /// 描述 :bom番号 
        /// </summary>
        public string EsBomNo { get; set; }

        /// <summary>
        /// 描述 :互换 
        /// </summary>
        public string EsChange { get; set; }

        /// <summary>
        /// 描述 :区分 
        /// </summary>
        public string Eslocal { get; set; }

        /// <summary>
        /// 描述 :指示 
        /// </summary>
        public string Esnote { get; set; }

        /// <summary>
        /// 描述 :旧品处理 
        /// </summary>
        public string EsOldProcess { get; set; }

        /// <summary>
        /// 描述 :bom日期 
        /// </summary>
        public string EsBomDate { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// </summary>
        [Required(ErrorMessage = "采购类型不能为空")]
        public string EsPurType { get; set; }

        /// <summary>
        /// 描述 :实施部门 
        /// </summary>
        [Required(ErrorMessage = "实施部门不能为空")]
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// </summary>
        [Required(ErrorMessage = "仓库不能为空")]
        public string EsSloc { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// </summary>
        [Required(ErrorMessage = "检验否不能为空")]
        public bool IsCheck { get; set; }

        /// <summary>
        /// 描述 :停产否 
        /// </summary>
        [Required(ErrorMessage = "停产否不能为空")]
        public string IsEol { get; set; }

        /// <summary>
        /// 描述 :旧品库存 
        /// </summary>
        [Required(ErrorMessage = "旧品库存不能为空")]
        public decimal EsOldCurrStock { get; set; }

        /// <summary>
        /// 描述 :新品库存 
        /// </summary>
        [Required(ErrorMessage = "新品库存不能为空")]
        public decimal EsNewCurrStock { get; set; }

        /// <summary>
        /// 描述 :部门录入日 
        /// </summary>
        public DateTime? EsDeptEntryDate { get; set; }

        /// <summary>
        /// 描述 :部门名称 
        /// </summary>
        public string EsDeptName { get; set; }

        /// <summary>
        /// 描述 :供应商 
        /// </summary>
        public string EsSupplier { get; set; }

        /// <summary>
        /// 描述 :采购PO 
        /// </summary>
        public string EsPurOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        public string EsPurNote { get; set; }

        /// <summary>
        /// 描述 :预投入批次 
        /// </summary>
        public string EsPmcLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        public string EsPmcMemo { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>
        public string EsPmcNote { get; set; }

        /// <summary>
        /// 描述 :检验订单 
        /// </summary>
        public string EsIqcOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        public string EsIqcNote { get; set; }

        /// <summary>
        /// 描述 :领用批次 
        /// </summary>
        public string EsMmLot { get; set; }

        /// <summary>
        /// 描述 :工单 
        /// </summary>
        public string EsMmMocNo { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        public string EsMmNote { get; set; }

        /// <summary>
        /// 描述 :班组 
        /// </summary>
        public string EsPpLine { get; set; }

        /// <summary>
        /// 描述 :生产批次 
        /// </summary>
        public string EsPpLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        public string EsPpNote { get; set; }

        /// <summary>
        /// 描述 :Pcba班组 
        /// </summary>
        public string EsPcbaLine { get; set; }

        /// <summary>
        /// 描述 :Pcba批次 
        /// </summary>
        public string EsPcbaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        public string EsPcbaNote { get; set; }

        /// <summary>
        /// 描述 :检验批次 
        /// </summary>
        public string EsQaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// </summary>
        public string EsQaNote { get; set; }

        /// <summary>
        /// 描述 :EsDeptCreator 
        /// </summary>
        public string EsDeptCreator { get; set; }

        /// <summary>
        /// 描述 :EsDeptCreateTime 
        /// </summary>
        public DateTime? EsDeptCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsDeptModifier 
        /// </summary>
        public string EsDeptModifier { get; set; }

        /// <summary>
        /// 描述 :EsDeptModifyTime 
        /// </summary>
        public DateTime? EsDeptModifyTime { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// </summary>
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        public DateTime? UpdateTime { get; set; }



    }
}