using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 汇率表，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    [SugarTable("fico_exchange_rate")]
    public class FicoExchangeRate
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long ErId { get; set; }

        /// <summary>
        /// 描述 :生效日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? ErEffDate { get; set; }

        /// <summary>
        /// 描述 :基数 
        /// 空值 :false 
        /// </summary>
        public int ErStd { get; set; }

        /// <summary>
        /// 描述 :Fm币别 
        /// 空值 :false 
        /// </summary>
        public string ErfmCcy { get; set; }

        /// <summary>
        /// 描述 :汇率 
        /// 空值 :false 
        /// </summary>
        public decimal ErRate { get; set; }

        /// <summary>
        /// 描述 :To币别 
        /// 空值 :false 
        /// </summary>
        public string ErtoCcy { get; set; }

        /// <summary>
        /// 描述 :软删除 
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