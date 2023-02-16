using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 部门消耗，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [SugarTable("fico_dept_consuming")]
    public class FicoDeptConsuming
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long DcId { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// 空值 :false 
        /// </summary>
        public string DcFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
        public string DcYm { get; set; }

        /// <summary>
        /// 描述 :公司代码 
        /// 空值 :false 
        /// </summary>
        public string DcCorpCode { get; set; }

        /// <summary>
        /// 描述 :公司名称 
        /// 空值 :false 
        /// </summary>
        public string DcCorpName { get; set; }

        /// <summary>
        /// 描述 :统计类别 
        /// 空值 :false 
        /// </summary>
        public string DcExpCategory { get; set; }

        /// <summary>
        /// 描述 :成本代码 
        /// 空值 :false 
        /// </summary>
        public string DcCostCode { get; set; }

        /// <summary>
        /// 描述 :成本名称 
        /// 空值 :false 
        /// </summary>
        public string DcCostName { get; set; }

        /// <summary>
        /// 描述 :科目代码 
        /// 空值 :false 
        /// </summary>
        public string DcTitleCode { get; set; }

        /// <summary>
        /// 描述 :科目名称 
        /// 空值 :false 
        /// </summary>
        public string DcTitleName { get; set; }

        /// <summary>
        /// 描述 :科目分类 
        /// 空值 :false 
        /// </summary>
        public string DcTitleNote { get; set; }

        /// <summary>
        /// 描述 :预算 
        /// 空值 :false 
        /// </summary>
        public decimal DcBudgetAmt { get; set; }

        /// <summary>
        /// 描述 :实际 
        /// 空值 :false 
        /// </summary>
        public decimal DcActualAmt { get; set; }

        /// <summary>
        /// 描述 :差异 
        /// 空值 :false 
        /// </summary>
        public decimal DcDiffAmt { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string DcPlant { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string DcMateriel { get; set; }

        /// <summary>
        /// 描述 :仓库 
        /// 空值 :false 
        /// </summary>
        public string DcStorageLocation { get; set; }

        /// <summary>
        /// 描述 :移动类型 
        /// 空值 :false 
        /// </summary>
        public string DcMoveType { get; set; }

        /// <summary>
        /// 描述 :物料凭证 
        /// 空值 :false 
        /// </summary>
        public string DcMaterielDoc { get; set; }

        /// <summary>
        /// 描述 :凭证明细 
        /// 空值 :false 
        /// </summary>
        public string DcMaterielDocDetails { get; set; }

        /// <summary>
        /// 描述 :数量 
        /// 空值 :false 
        /// </summary>
        public decimal DcUseQty { get; set; }

        /// <summary>
        /// 描述 :金额 
        /// 空值 :false 
        /// </summary>
        public decimal DcUseAmt { get; set; }

        /// <summary>
        /// 描述 :预留单 
        /// 空值 :false 
        /// </summary>
        public string DcReserveDoc { get; set; }

        /// <summary>
        /// 描述 :预留明细 
        /// 空值 :false 
        /// </summary>
        public string DcAccountant { get; set; }

        /// <summary>
        /// 描述 :登录日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? DcBalanceDate { get; set; }

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