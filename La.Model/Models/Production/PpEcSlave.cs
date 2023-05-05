using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 从设变，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-05-02
    /// </summary>
    [SugarTable("pp_ec_slave")]
    public class PpEcSlave
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int EsId { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// 空值 :false 
        /// </summary>
        public DateTime? EsEntryDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// 空值 :false 
        /// </summary>
        public string EsEcNo { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// 空值 :false 
        /// </summary>
        public string EsModel { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string EsItem { get; set; }

        /// <summary>
        /// 描述 :子物料 
        /// 空值 :true 
        /// </summary>
        public string EsSubItem { get; set; }

        /// <summary>
        /// 描述 :旧物料 
        /// 空值 :true 
        /// </summary>
        public string EsOldItem { get; set; }

        /// <summary>
        /// 描述 :旧文本 
        /// 空值 :true 
        /// </summary>
        public string EsOldItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// 空值 :false 
        /// </summary>
        public decimal EsOldUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// 空值 :true 
        /// </summary>
        public string EsOldSetLoc { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// 空值 :true 
        /// </summary>
        public string EsNewItem { get; set; }

        /// <summary>
        /// 描述 :新文本 
        /// 空值 :true 
        /// </summary>
        public string EsNewItemText { get; set; }

        /// <summary>
        /// 描述 :用量 
        /// 空值 :false 
        /// </summary>
        public decimal EsNewUsageQty { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// 空值 :true 
        /// </summary>
        public string EsNewSetLoc { get; set; }

        /// <summary>
        /// 描述 :bom番号 
        /// 空值 :true 
        /// </summary>
        public string EsBomNo { get; set; }

        /// <summary>
        /// 描述 :互换 
        /// 空值 :true 
        /// </summary>
        public string EsChange { get; set; }

        /// <summary>
        /// 描述 :区分 
        /// 空值 :true 
        /// </summary>
        public string Eslocal { get; set; }

        /// <summary>
        /// 描述 :指示 
        /// 空值 :true 
        /// </summary>
        public string Esnote { get; set; }

        /// <summary>
        /// 描述 :旧品处理 
        /// 空值 :true 
        /// </summary>
        public string EsOldProcess { get; set; }

        /// <summary>
        /// 描述 :bom日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? EsBomDate { get; set; }

        /// <summary>
        /// 描述 :实施部门 
        /// 空值 :false 
        /// </summary>
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// 空值 :false 
        /// </summary>
        public string EsPurType { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// 空值 :false 
        /// </summary>
        public string EsSloc { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// 空值 :true 
        /// </summary>
        public string EsInsmk { get; set; }

        /// <summary>
        /// 描述 :工厂状态 
        /// 空值 :true 
        /// </summary>
        public string EsMstae { get; set; }

        /// <summary>
        /// 描述 :SOP 
        /// 空值 :false 
        /// </summary>
        public byte EsSopStae { get; set; }

        /// <summary>
        /// 描述 :旧品库存 
        /// 空值 :false 
        /// </summary>
        public decimal EsOldCurrStock { get; set; }

        /// <summary>
        /// 描述 :新品库存 
        /// 空值 :false 
        /// </summary>
        public decimal EsNewCurrStock { get; set; }

        /// <summary>
        /// 描述 :采购登入日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPurEntryDate { get; set; }

        /// <summary>
        /// 描述 :供应商 
        /// 空值 :true 
        /// </summary>
        public string EsSupplier { get; set; }

        /// <summary>
        /// 描述 :采购PO 
        /// 空值 :true 
        /// </summary>
        public string EsPurOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsPurNote { get; set; }

        /// <summary>
        /// 描述 :EsPurCreator 
        /// 空值 :true 
        /// </summary>
        public string EsPurCreator { get; set; }

        /// <summary>
        /// 描述 :EsPurCreateTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPurCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPurModifier 
        /// 空值 :true 
        /// </summary>
        public string EsPurModifier { get; set; }

        /// <summary>
        /// 描述 :EsPurModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPurModifyTime { get; set; }

        /// <summary>
        /// 描述 :生管登入日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPmcEntryDate { get; set; }

        /// <summary>
        /// 描述 :预投入批次 
        /// 空值 :true 
        /// </summary>
        public string EsPmcLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsPmcMemo { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string EsPmcNote { get; set; }

        /// <summary>
        /// 描述 :EsPmcCreator 
        /// 空值 :true 
        /// </summary>
        public string EsPmcCreator { get; set; }

        /// <summary>
        /// 描述 :EsPmcCreateTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPmcCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPmcModifier 
        /// 空值 :true 
        /// </summary>
        public string EsPmcModifier { get; set; }

        /// <summary>
        /// 描述 :EsPmcModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPmcModifyTime { get; set; }

        /// <summary>
        /// 描述 :IQC登入日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsIqcEntryDate { get; set; }

        /// <summary>
        /// 描述 :检验订单 
        /// 空值 :true 
        /// </summary>
        public string EsIqcOrder { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsIqcNote { get; set; }

        /// <summary>
        /// 描述 :EsIqcCreator 
        /// 空值 :true 
        /// </summary>
        public string EsIqcCreator { get; set; }

        /// <summary>
        /// 描述 :EsIqcCreateTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsIqcCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsIqcModifier 
        /// 空值 :true 
        /// </summary>
        public string EsIqcModifier { get; set; }

        /// <summary>
        /// 描述 :EsIqcModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsIqcModifyTime { get; set; }

        /// <summary>
        /// 描述 :部管登入日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsMmEntryDate { get; set; }

        /// <summary>
        /// 描述 :领用批次 
        /// 空值 :true 
        /// </summary>
        public string EsMmLot { get; set; }

        /// <summary>
        /// 描述 :工单 
        /// 空值 :true 
        /// </summary>
        public string EsMmMocNo { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsMmNote { get; set; }

        /// <summary>
        /// 描述 :EsMmCreator 
        /// 空值 :true 
        /// </summary>
        public string EsMmCreator { get; set; }

        /// <summary>
        /// 描述 :EsMmCreateTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsMmCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsMmModifier 
        /// 空值 :true 
        /// </summary>
        public string EsMmModifier { get; set; }

        /// <summary>
        /// 描述 :EsMmModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsMmModifyTime { get; set; }

        /// <summary>
        /// 描述 :制一登入日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPpEntryDate { get; set; }

        /// <summary>
        /// 描述 :班组 
        /// 空值 :true 
        /// </summary>
        public string EsPpLine { get; set; }

        /// <summary>
        /// 描述 :生产批次 
        /// 空值 :true 
        /// </summary>
        public string EsPpLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsPpNote { get; set; }

        /// <summary>
        /// 描述 :EsPpCreator 
        /// 空值 :true 
        /// </summary>
        public string EsPpCreator { get; set; }

        /// <summary>
        /// 描述 :EsPpCreateTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPpCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPpModifier 
        /// 空值 :true 
        /// </summary>
        public string EsPpModifier { get; set; }

        /// <summary>
        /// 描述 :EsPpModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPpModifyTime { get; set; }

        /// <summary>
        /// 描述 :制二登入日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPcbaEntryDate { get; set; }

        /// <summary>
        /// 描述 :Pcba班组 
        /// 空值 :true 
        /// </summary>
        public string EsPcbaLine { get; set; }

        /// <summary>
        /// 描述 :Pcba批次 
        /// 空值 :true 
        /// </summary>
        public string EsPcbaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsPcbaNote { get; set; }

        /// <summary>
        /// 描述 :EsPcbaCreator 
        /// 空值 :true 
        /// </summary>
        public string EsPcbaCreator { get; set; }

        /// <summary>
        /// 描述 :EsPcbaCreateTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPcbaCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsPcbaModifier 
        /// 空值 :true 
        /// </summary>
        public string EsPcbaModifier { get; set; }

        /// <summary>
        /// 描述 :EsPcbaModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsPcbaModifyTime { get; set; }

        /// <summary>
        /// 描述 :QA确认日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsQaEntryDate { get; set; }

        /// <summary>
        /// 描述 :检验批次 
        /// 空值 :true 
        /// </summary>
        public string EsQaLot { get; set; }

        /// <summary>
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string EsQaNote { get; set; }

        /// <summary>
        /// 描述 :EsQaCreator 
        /// 空值 :true 
        /// </summary>
        public string EsQaCreator { get; set; }

        /// <summary>
        /// 描述 :EsQaCreateTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsQaCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsQaModifier 
        /// 空值 :true 
        /// </summary>
        public string EsQaModifier { get; set; }

        /// <summary>
        /// 描述 :EsQaModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsQaModifyTime { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// 空值 :true 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

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