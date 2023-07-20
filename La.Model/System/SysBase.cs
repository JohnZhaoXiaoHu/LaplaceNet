using MiniExcelLibs.Attributes;
using Newtonsoft.Json;
using SqlSugar;
using System;

namespace La.Model.System
{
    //[EpplusTable(PrintHeaders = true, AutofitColumns = true, AutoCalculate = true, ShowTotal = true)]
    public class SysBase
    {
        ///// <summary>
        ///// 自定义字段UDF01
        ///// </summary>
        //[SugarColumn(Length = 500)]
        //public string UDF01 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF02
        ///// </summary>
        //[SugarColumn(Length = 500)]
        //public string UDF02 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF03
        ///// </summary>
        //[SugarColumn(Length = 500)]
        //public string UDF03 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF04
        ///// </summary>
        //[SugarColumn(Length = 500)]
        //public string UDF04 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF05
        ///// </summary>
        //[SugarColumn(Length = 500)]
        //public string UDF05 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF06
        ///// </summary>
        //[SugarColumn(Length = 500)]
        //public string UDF06 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF51
        ///// </summary>
        //[SugarColumn(DefaultValue = "0")]
        //public int UDF51 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF52
        ///// </summary>
        //[SugarColumn(DefaultValue = "0")]
        //public int UDF52 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF53
        ///// </summary>
        //[SugarColumn(DefaultValue = "0")]
        //public int UDF53 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF54
        ///// </summary>
        //[SugarColumn(DefaultValue = "0")]
        //public decimal UDF54 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF55
        ///// </summary>
        //[SugarColumn(DefaultValue = "0")]
        //public decimal UDF55 { get; set; }
        ///// <summary>
        ///// 自定义字段UDF56
        ///// </summary>
        //[SugarColumn(DefaultValue = "0")]
        //public decimal UDF56 { get; set; }
        ///// <summary>
        ///// 描述 :软删除 
        ///// </summary>
        //[ExcelIgnore]
        //[SugarColumn(DefaultValue ="0")]
        //public int IsDeleted { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = 500)]
        public string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(IsOnlyIgnoreUpdate = true, Length = 24, IsNullable = true)]
        [JsonProperty(propertyName: "CreateBy")]
        [ExcelIgnore]
        public string Create_by { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsOnlyIgnoreUpdate = true, IsNullable = true)]
        [JsonProperty(propertyName: "CreateTime")]
        [ExcelColumn(Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime Create_time { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新人
        /// </summary>
        [JsonIgnore]
        [JsonProperty(propertyName: "UpdateBy")]
        [SugarColumn(IsOnlyIgnoreInsert = true, Length = 24, IsNullable = true)]
        [ExcelIgnore]
        public string Update_by { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        //[JsonIgnore]
        [SugarColumn(IsOnlyIgnoreInsert = true, IsNullable = true)]
        [JsonProperty(propertyName: "UpdateTime")]
        [ExcelColumn(Format = "yyyy-MM-dd HH:mm:ss")]
        [ExcelIgnore]
        public DateTime? Update_time { get; set; }


    }
}
