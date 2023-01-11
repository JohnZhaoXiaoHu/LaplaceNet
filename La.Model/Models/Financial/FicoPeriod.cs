using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 财务期间，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-01-11
    /// </summary>
    [SugarTable("fico_period")]
    public class FicoPeriod
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int FpId { get; set; }

        /// <summary>
        /// 描述 :财年 
        /// 空值 :false 
        /// </summary>
        public string FpFy { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// 空值 :false 
        /// </summary>
        public string FpYm { get; set; }

        /// <summary>
        /// 描述 :年 
        /// 空值 :false 
        /// </summary>
        public string FpYear { get; set; }

        /// <summary>
        /// 描述 :月 
        /// 空值 :false 
        /// </summary>
        public string FpMonth { get; set; }

        /// <summary>
        /// 描述 :季度 
        /// 空值 :false 
        /// </summary>
        public string FpQuarter { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :false 
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