using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 从设变信息表，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-04-10
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
        /// 空值 :true 
        /// </summary>
        public string EsBomDate { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// 空值 :false 
        /// </summary>
        public string EsPurType { get; set; }

        /// <summary>
        /// 描述 :实施部门 
        /// 空值 :false 
        /// </summary>
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// 空值 :false 
        /// </summary>
        public string EsSloc { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// 空值 :false 
        /// </summary>
        public bool IsCheck { get; set; }

        /// <summary>
        /// 描述 :停产否 
        /// 空值 :false 
        /// </summary>
        public string IsEol { get; set; }

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
        /// 描述 :部门录入日 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsDeptEntryDate { get; set; }

        /// <summary>
        /// 描述 :部门名称 
        /// 空值 :true 
        /// </summary>
        public string EsDeptName { get; set; }

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
        /// 描述 :EsDeptCreator 
        /// 空值 :true 
        /// </summary>
        public string EsDeptCreator { get; set; }

        /// <summary>
        /// 描述 :EsDeptCreateTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsDeptCreateTime { get; set; }

        /// <summary>
        /// 描述 :EsDeptModifier 
        /// 空值 :true 
        /// </summary>
        public string EsDeptModifier { get; set; }

        /// <summary>
        /// 描述 :EsDeptModifyTime 
        /// 空值 :true 
        /// </summary>
        public DateTime? EsDeptModifyTime { get; set; }

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