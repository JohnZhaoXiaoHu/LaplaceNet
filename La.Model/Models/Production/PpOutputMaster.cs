using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// oph主表，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-03-09
    /// </summary>
    [SugarTable("pp_output_master")]
    public class PpOutputMaster
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int? PomId { get; set; }

        /// <summary>
        /// 描述 :GUID 
        /// 空值 :false 
        /// </summary>
        public string PomGuid { get; set; }

        /// <summary>
        /// 描述 :生产工单 
        /// 空值 :false 
        /// </summary>
        public string PomOrder { get; set; }

        /// <summary>
        /// 描述 :工单数量 
        /// 空值 :false 
        /// </summary>
        public decimal PomOrderQty { get; set; }

        /// <summary>
        /// 描述 :管理序列号 
        /// 空值 :false 
        /// </summary>
        public string PomOrderSerial { get; set; }

        /// <summary>
        /// 描述 :生产批次 
        /// 空值 :false 
        /// </summary>
        public string PomMflot { get; set; }

        /// <summary>
        /// 描述 :机种名 
        /// 空值 :false 
        /// </summary>
        public string PomModelName { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string PomMfItem { get; set; }

        /// <summary>
        /// 描述 :生产日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? PomMfDate { get; set; }

        /// <summary>
        /// 描述 :生产班组 
        /// 空值 :false 
        /// </summary>
        public string PomLineName { get; set; }

        /// <summary>
        /// 描述 :直接人数 
        /// 空值 :false 
        /// </summary>
        public int PomDirect { get; set; }

        /// <summary>
        /// 描述 :间接人数 
        /// 空值 :false 
        /// </summary>
        public int PomIndirect { get; set; }

        /// <summary>
        /// 描述 :标准工时 
        /// 空值 :false 
        /// </summary>
        public decimal PomStdTime { get; set; }

        /// <summary>
        /// 描述 :标准产能 
        /// 空值 :false 
        /// </summary>
        public decimal PomStdOutput { get; set; }

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
        /// 空值 :false 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :false 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :false 
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