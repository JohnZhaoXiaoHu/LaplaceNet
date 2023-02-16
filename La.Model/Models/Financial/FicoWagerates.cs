using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 工厂工资率，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-16
    /// </summary>
    [SugarTable("fico_wagerates")]
    public class FicoWagerates
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int FwId { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
        public string FwYm { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string FwPlant { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// 空值 :false 
        /// </summary>
        public string FwCcy { get; set; }

        /// <summary>
        /// 描述 :销售额 
        /// 空值 :false 
        /// </summary>
        public decimal FwSalesVolume { get; set; }

        /// <summary>
        /// 描述 :工作天数 
        /// 空值 :false 
        /// </summary>
        public decimal FwWorkingDays { get; set; }

        /// <summary>
        /// 描述 :直接工资率 
        /// 空值 :false 
        /// </summary>
        public decimal FwDirectWageRate { get; set; }

        /// <summary>
        /// 描述 :直接人数 
        /// 空值 :false 
        /// </summary>
        public decimal FwDirect { get; set; }

        /// <summary>
        /// 描述 :直接加班费 
        /// 空值 :false 
        /// </summary>
        public decimal FwDirectOverTime { get; set; }

        /// <summary>
        /// 描述 :直接工欠账 
        /// 空值 :false 
        /// </summary>
        public decimal FwDirectWages { get; set; }

        /// <summary>
        /// 描述 :间接工资率 
        /// 空值 :false 
        /// </summary>
        public decimal FwInDirectWageRate { get; set; }

        /// <summary>
        /// 描述 :间接人数 
        /// 空值 :false 
        /// </summary>
        public decimal FwInDirect { get; set; }

        /// <summary>
        /// 描述 :间接加班费 
        /// 空值 :false 
        /// </summary>
        public decimal FwInDirectOverTime { get; set; }

        /// <summary>
        /// 描述 :间接工资 
        /// 空值 :false 
        /// </summary>
        public decimal FwInDirectWages { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

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