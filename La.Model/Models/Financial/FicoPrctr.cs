using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 利润中心，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    [SugarTable("fico_prctr")]
    public class FicoPrctr
    {
        /// <summary>
        /// 描述 :Id主键 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long FpId { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string FpPlnt { get; set; }

        /// <summary>
        /// 描述 :代码 
        /// 空值 :false 
        /// </summary>
        public string FpCode { get; set; }

        /// <summary>
        /// 描述 :名称 
        /// 空值 :false 
        /// </summary>
        public string FpName { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// 空值 :false 
        /// </summary>
        public string FpType { get; set; }

        /// <summary>
        /// 描述 :有效从 
        /// 空值 :false 
        /// </summary>
        public DateTime? FpActDate { get; set; }

        /// <summary>
        /// 描述 :有效到 
        /// 空值 :false 
        /// </summary>
        public DateTime? FpExpDate { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
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