using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 标准工时，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-09
    /// </summary>
    [SugarTable("pp_manhours")]
    public class PpManhours
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long MhId { get; set; }

        /// <summary>
        /// 描述 :生效日期 
        /// 空值 :true 
        /// </summary>
        public DateTime? MhEffDate { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string MhPlant { get; set; }

        /// <summary>
        /// 描述 :机种名 
        /// 空值 :false 
        /// </summary>
        public string MhModelType { get; set; }

        /// <summary>
        /// 描述 :仕向别 
        /// 空值 :true 
        /// </summary>
        public string MhRegionType { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :true 
        /// </summary>
        public string MhItem { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// 空值 :true 
        /// </summary>
        public string MhItemText { get; set; }

        /// <summary>
        /// 描述 :工作中心 
        /// 空值 :false 
        /// </summary>
        public string MhWcName { get; set; }

        /// <summary>
        /// 描述 :工作中心文本 
        /// 空值 :true 
        /// </summary>
        public string MhWcText { get; set; }

        /// <summary>
        /// 描述 :标准点数 
        /// 空值 :false 
        /// </summary>
        public decimal MhStdShort { get; set; }

        /// <summary>
        /// 描述 :Short单位 
        /// 空值 :true 
        /// </summary>
        public string MhShortUnit { get; set; }

        /// <summary>
        /// 描述 :点数换算汇率 
        /// 空值 :false 
        /// </summary>
        public decimal MhToMinRate { get; set; }

        /// <summary>
        /// 描述 :标准工时 
        /// 空值 :false 
        /// </summary>
        public decimal MhStdTime { get; set; }

        /// <summary>
        /// 描述 :工时单位 
        /// 空值 :true 
        /// </summary>
        public string MhTimeUnit { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 : 
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