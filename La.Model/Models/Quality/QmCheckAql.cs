using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 抽样标准，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-15
    /// </summary>
    [SugarTable("qm_check_aql")]
    public class QmCheckAql
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string QcaqlGuid { get; set; }

        /// <summary>
        /// 描述 :查检水平 
        /// 空值 :false 
        /// </summary>
        public string QcaqlLevel { get; set; }

        /// <summary>
        /// 描述 :批量范围 
        /// 空值 :false 
        /// </summary>
        public string QcaqlRange { get; set; }

        /// <summary>
        /// 描述 :最小值 
        /// 空值 :false 
        /// </summary>
        public int QcaqlRangeMinmum { get; set; }

        /// <summary>
        /// 描述 :最大值 
        /// 空值 :false 
        /// </summary>
        public int QcaqlRangeMaximum { get; set; }

        /// <summary>
        /// 描述 :样本码 
        /// 空值 :false 
        /// </summary>
        public string QcaqlSamplesCode { get; set; }

        /// <summary>
        /// 描述 :抽样数 
        /// 空值 :false 
        /// </summary>
        public int QcaqlSamplesQty { get; set; }

        /// <summary>
        /// 描述 :合格项 
        /// 空值 :false 
        /// </summary>
        public int QcaqlAcQty { get; set; }

        /// <summary>
        /// 描述 :不合格项 
        /// 空值 :false 
        /// </summary>
        public int QcaqlReQty { get; set; }

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
        /// 描述 : 
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