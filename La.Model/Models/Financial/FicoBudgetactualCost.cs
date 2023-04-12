using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 预算实际，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    [SugarTable("fico_budgetactual_cost")]
    public class FicoBudgetactualCost
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long FbId { get; set; }

        /// <summary>
        /// 描述 :期间 
        /// 空值 :false 
        /// </summary>
        public string FbFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
        public string FbYm { get; set; }

        /// <summary>
        /// 描述 :公司代码 
        /// 空值 :false 
        /// </summary>
        public string FbCorpCode { get; set; }

        /// <summary>
        /// 描述 :公司名称 
        /// 空值 :false 
        /// </summary>
        public string FbCorpName { get; set; }

        /// <summary>
        /// 描述 :统计类别 
        /// 空值 :false 
        /// </summary>
        public string FbExpCategory { get; set; }

        /// <summary>
        /// 描述 :成本代码 
        /// 空值 :false 
        /// </summary>
        public string FbCostCode { get; set; }

        /// <summary>
        /// 描述 :成本名称 
        /// 空值 :false 
        /// </summary>
        public string FbCostName { get; set; }

        /// <summary>
        /// 描述 :科目代码 
        /// 空值 :false 
        /// </summary>
        public string FbTitleCode { get; set; }

        /// <summary>
        /// 描述 :科目名称 
        /// 空值 :false 
        /// </summary>
        public string FbTitleName { get; set; }

        /// <summary>
        /// 描述 :科目分类 
        /// 空值 :false 
        /// </summary>
        public string FbTitleNote { get; set; }

        /// <summary>
        /// 描述 :预算 
        /// 空值 :false 
        /// </summary>
        public decimal FbBudgetAmt { get; set; }

        /// <summary>
        /// 描述 :实际 
        /// 空值 :false 
        /// </summary>
        public decimal FbActualAmt { get; set; }

        /// <summary>
        /// 描述 :差异 
        /// 空值 :false 
        /// </summary>
        public decimal FbDiffAmt { get; set; }

        /// <summary>
        /// 描述 :会计人员 
        /// 空值 :false 
        /// </summary>
        public string FbAccountant { get; set; }

        /// <summary>
        /// 描述 :日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? FbBalanceDate { get; set; }

        /// <summary>
        /// 描述 :删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :说明 
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