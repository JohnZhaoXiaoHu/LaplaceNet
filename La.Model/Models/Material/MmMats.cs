using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 物料信息，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-25
    /// </summary>
    [SugarTable("mm_mats")]
    public class MmMats
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int MmId { get; set; }

        /// <summary>
        /// 描述 :更新日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? MmLastDate { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// 空值 :false 
        /// </summary>
        public string MmPlnt { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string MmMatItem { get; set; }

        /// <summary>
        /// 描述 :行业类别 
        /// 空值 :false 
        /// </summary>
        public string MmIndustry { get; set; }

        /// <summary>
        /// 描述 :物料类型 
        /// 空值 :false 
        /// </summary>
        public string MmMatType { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// 空值 :false 
        /// </summary>
        public string MmMatDes { get; set; }

        /// <summary>
        /// 描述 :标准单位 
        /// 空值 :false 
        /// </summary>
        public string MmBaseUnit { get; set; }

        /// <summary>
        /// 描述 :层次 
        /// 空值 :true 
        /// </summary>
        public string MmProLevel { get; set; }

        /// <summary>
        /// 描述 :物料组 
        /// 空值 :false 
        /// </summary>
        public string MmMatGroup { get; set; }

        /// <summary>
        /// 描述 :采购组 
        /// 空值 :true 
        /// </summary>
        public string MmPurGroup { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// 空值 :false 
        /// </summary>
        public string MmPurType { get; set; }

        /// <summary>
        /// 描述 :特殊采购类 
        /// 空值 :true 
        /// </summary>
        public string MmSpecType { get; set; }

        /// <summary>
        /// 描述 :散装物料 
        /// 空值 :true 
        /// </summary>
        public string MmBulkMat { get; set; }

        /// <summary>
        /// 描述 :最小批量 
        /// 空值 :false 
        /// </summary>
        public int MmMoq { get; set; }

        /// <summary>
        /// 描述 :舍入值 
        /// 空值 :false 
        /// </summary>
        public int MmRoundingVal { get; set; }

        /// <summary>
        /// 描述 :交货时间 
        /// 空值 :false 
        /// </summary>
        public int MmLeadTime { get; set; }

        /// <summary>
        /// 描述 :生产天数 
        /// 空值 :false 
        /// </summary>
        public decimal MmProDays { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// 空值 :true 
        /// </summary>
        public string MmisChecked { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// 空值 :false 
        /// </summary>
        public string MmProfitCenter { get; set; }

        /// <summary>
        /// 描述 :差异码 
        /// 空值 :true 
        /// </summary>
        public string MmDiffCode { get; set; }

        /// <summary>
        /// 描述 :批次管理 
        /// 空值 :true 
        /// </summary>
        public string MmisLot { get; set; }

        /// <summary>
        /// 描述 :制造商物料 
        /// 空值 :true 
        /// </summary>
        public string MmMpn { get; set; }

        /// <summary>
        /// 描述 :制造商 
        /// 空值 :true 
        /// </summary>
        public string MmMfrs { get; set; }

        /// <summary>
        /// 描述 :评估类 
        /// 空值 :false 
        /// </summary>
        public string MmValType { get; set; }

        /// <summary>
        /// 描述 :移动平均价 
        /// 空值 :false 
        /// </summary>
        public decimal MmMovingAvg { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// 空值 :false 
        /// </summary>
        public string MmCcy { get; set; }

        /// <summary>
        /// 描述 :价格控制 
        /// 空值 :false 
        /// </summary>
        public string MmPriceControl { get; set; }

        /// <summary>
        /// 描述 :价格单位 
        /// 空值 :false 
        /// </summary>
        public int MmPriceUnit { get; set; }

        /// <summary>
        /// 描述 :采购仓库 
        /// 空值 :true 
        /// </summary>
        public string MmSLoc { get; set; }

        /// <summary>
        /// 描述 :生产仓库 
        /// 空值 :true 
        /// </summary>
        public string MmESLoc { get; set; }

        /// <summary>
        /// 描述 :仓位 
        /// 空值 :true 
        /// </summary>
        public string MmLocPosn { get; set; }

        /// <summary>
        /// 描述 :库存 
        /// 空值 :false 
        /// </summary>
        public decimal MmInventory { get; set; }

        /// <summary>
        /// 描述 :EOL 
        /// 空值 :true 
        /// </summary>
        public string MmLocEol { get; set; }

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