using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 物料信息查询对象
    /// </summary>
    public class MmMatsQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        public string MmPlnt { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string MmMatItem { get; set; }
        /// <summary>
        /// 描述 :行业类别 
        /// </summary>
        public string MmIndustry { get; set; }
        /// <summary>
        /// 描述 :物料类型 
        /// </summary>
        public string MmMatType { get; set; }
        /// <summary>
        /// 描述 :标准单位 
        /// </summary>
        public string MmBaseUnit { get; set; }
        /// <summary>
        /// 描述 :物料组 
        /// </summary>
        public string MmMatGroup { get; set; }
        /// <summary>
        /// 描述 :采购组 
        /// </summary>
        public string MmPurGroup { get; set; }
        /// <summary>
        /// 描述 :采购类型 
        /// </summary>
        public string MmPurType { get; set; }
        /// <summary>
        /// 描述 :利润中心 
        /// </summary>
        public string MmProfitCenter { get; set; }
        /// <summary>
        /// 描述 :评估类 
        /// </summary>
        public string MmValType { get; set; }
        /// <summary>
        /// 描述 :币种 
        /// </summary>
        public string MmCcy { get; set; }
        /// <summary>
        /// 描述 :采购仓库 
        /// </summary>
        public string MmSLoc { get; set; }
        /// <summary>
        /// 描述 :仓位 
        /// </summary>
        public string MmLocPosn { get; set; }
    }

    /// <summary>
    /// 物料信息输入输出对象
    /// </summary>
    public class MmMatsDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public int MmId { get; set; }

        /// <summary>
        /// 描述 :更新日期 
        /// </summary>
        [Required(ErrorMessage = "更新日期不能为空")]

        [ExcelColumn(Name = "更新日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MmLastDate { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]
        public string MmPlnt { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string MmMatItem { get; set; }

        /// <summary>
        /// 描述 :行业类别 
        /// </summary>
        [Required(ErrorMessage = "行业类别不能为空")]

        [ExcelColumn(Name = "行业类别")]
        public string MmIndustry { get; set; }

        /// <summary>
        /// 描述 :物料类型 
        /// </summary>
        [Required(ErrorMessage = "物料类型不能为空")]

        [ExcelColumn(Name = "物料类型")]
        public string MmMatType { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// </summary>
        [Required(ErrorMessage = "物料文本不能为空")]

        [ExcelColumn(Name = "物料文本")]
        public string MmMatDes { get; set; }

        /// <summary>
        /// 描述 :标准单位 
        /// </summary>
        [Required(ErrorMessage = "标准单位不能为空")]

        [ExcelColumn(Name = "标准单位")]
        public string MmBaseUnit { get; set; }

        /// <summary>
        /// 描述 :层次 
        /// </summary>

        [ExcelColumn(Name = "层次")]
        public string MmProLevel { get; set; }

        /// <summary>
        /// 描述 :物料组 
        /// </summary>
        [Required(ErrorMessage = "物料组不能为空")]

        [ExcelColumn(Name = "物料组")]
        public string MmMatGroup { get; set; }

        /// <summary>
        /// 描述 :采购组 
        /// </summary>

        [ExcelColumn(Name = "采购组")]
        public string MmPurGroup { get; set; }

        /// <summary>
        /// 描述 :采购类型 
        /// </summary>
        [Required(ErrorMessage = "采购类型不能为空")]

        [ExcelColumn(Name = "采购类型")]
        public string MmPurType { get; set; }

        /// <summary>
        /// 描述 :特殊采购类 
        /// </summary>

        [ExcelColumn(Name = "特殊采购类")]
        public string MmSpecType { get; set; }

        /// <summary>
        /// 描述 :散装物料 
        /// </summary>

        [ExcelColumn(Name = "散装物料")]
        public string MmBulkMat { get; set; }

        /// <summary>
        /// 描述 :最小批量 
        /// </summary>
        [Required(ErrorMessage = "最小批量不能为空")]

        [ExcelColumn(Name = "最小批量")]
        public int MmMoq { get; set; }

        /// <summary>
        /// 描述 :舍入值 
        /// </summary>
        [Required(ErrorMessage = "舍入值不能为空")]

        [ExcelColumn(Name = "舍入值")]
        public int MmRoundingVal { get; set; }

        /// <summary>
        /// 描述 :交货时间 
        /// </summary>
        [Required(ErrorMessage = "交货时间不能为空")]

        [ExcelColumn(Name = "交货时间")]
        public int MmLeadTime { get; set; }

        /// <summary>
        /// 描述 :生产天数 
        /// </summary>
        [Required(ErrorMessage = "生产天数不能为空")]

        [ExcelColumn(Name = "生产天数")]
        public decimal MmProDays { get; set; }

        /// <summary>
        /// 描述 :检验否 
        /// </summary>

        [ExcelColumn(Name = "检验否")]
        public string MmisChecked { get; set; }

        /// <summary>
        /// 描述 :利润中心 
        /// </summary>
        [Required(ErrorMessage = "利润中心不能为空")]

        [ExcelColumn(Name = "利润中心")]
        public string MmProfitCenter { get; set; }

        /// <summary>
        /// 描述 :差异码 
        /// </summary>

        [ExcelColumn(Name = "差异码")]
        public string MmDiffCode { get; set; }

        /// <summary>
        /// 描述 :批次管理 
        /// </summary>

        [ExcelColumn(Name = "批次管理")]
        public string MmisLot { get; set; }

        /// <summary>
        /// 描述 :制造商物料 
        /// </summary>

        [ExcelColumn(Name = "制造商物料")]
        public string MmMpn { get; set; }

        /// <summary>
        /// 描述 :制造商 
        /// </summary>

        [ExcelColumn(Name = "制造商")]
        public string MmMfrs { get; set; }

        /// <summary>
        /// 描述 :评估类 
        /// </summary>
        [Required(ErrorMessage = "评估类不能为空")]

        [ExcelColumn(Name = "评估类")]
        public string MmValType { get; set; }

        /// <summary>
        /// 描述 :移动平均价 
        /// </summary>
        [Required(ErrorMessage = "移动平均价不能为空")]

        [ExcelColumn(Name = "移动平均价")]
        public decimal MmMovingAvg { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// </summary>
        [Required(ErrorMessage = "币种不能为空")]

        [ExcelColumn(Name = "币种")]
        public string MmCcy { get; set; }

        /// <summary>
        /// 描述 :价格控制 
        /// </summary>
        [Required(ErrorMessage = "价格控制不能为空")]

        [ExcelColumn(Name = "价格控制")]
        public string MmPriceControl { get; set; }

        /// <summary>
        /// 描述 :价格单位 
        /// </summary>
        [Required(ErrorMessage = "价格单位不能为空")]

        [ExcelColumn(Name = "价格单位")]
        public int MmPriceUnit { get; set; }

        /// <summary>
        /// 描述 :采购仓库 
        /// </summary>

        [ExcelColumn(Name = "采购仓库")]
        public string MmSLoc { get; set; }

        /// <summary>
        /// 描述 :生产仓库 
        /// </summary>

        [ExcelColumn(Name = "生产仓库")]
        public string MmESLoc { get; set; }

        /// <summary>
        /// 描述 :仓位 
        /// </summary>

        [ExcelColumn(Name = "仓位")]
        public string MmLocPosn { get; set; }

        /// <summary>
        /// 描述 :库存 
        /// </summary>
        [Required(ErrorMessage = "库存不能为空")]

        [ExcelColumn(Name = "库存")]
        public decimal MmInventory { get; set; }

        /// <summary>
        /// 描述 :EOL 
        /// </summary>

        [ExcelColumn(Name = "EOL")]
        public string MmLocEol { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}