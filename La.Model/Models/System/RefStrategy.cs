using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 单据编码，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    [SugarTable("sys_ref_strategy")]
    public class RefStrategy
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long RefId { get; set; }

        /// <summary>
        /// 描述 :模块 
        /// 空值 :false 
        /// </summary>
        public string RefModule { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// 空值 :false 
        /// </summary>
        public string RefCategory { get; set; }

        /// <summary>
        /// 描述 :编码代号 
        /// 空值 :false 
        /// </summary>
        public string RefCode { get; set; }

        /// <summary>
        /// 描述 :编码名称 
        /// 空值 :false 
        /// </summary>
        public string RefName { get; set; }

        /// <summary>
        /// 描述 :编码模式 
        /// 空值 :false 
        /// </summary>
        public string RefPattern { get; set; }

        /// <summary>
        /// 描述 :前缀 
        /// 空值 :false 
        /// </summary>
        public string RefPrefix { get; set; }

        /// <summary>
        /// 描述 :长度 
        /// 空值 :false 
        /// </summary>
        public int RefLenth { get; set; }

        /// <summary>
        /// 描述 :初始编码 
        /// 空值 :false 
        /// </summary>
        public string InitNumber { get; set; }

        /// <summary>
        /// 描述 :ISO编号 
        /// 空值 :false 
        /// </summary>
        public string IsoNumber { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :false 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// 空值 :false 
        /// </summary>
        public int Sort { get; set; }

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