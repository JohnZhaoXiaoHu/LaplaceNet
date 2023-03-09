using MiniExcelLibs.Attributes;
using Newtonsoft.Json;
using SqlSugar;
using System;

namespace La.Model.System
{
    //[EpplusTable(PrintHeaders = true, AutofitColumns = true, AutoCalculate = true, ShowTotal = true)]
    /// <summary>
    /// 标准字段
    /// </summary>
    public class SysBase
    {
        /// <summary>
        /// 新建
        /// </summary>
        [SugarColumn(IsOnlyIgnoreUpdate = true)]
        [JsonProperty(propertyName: "CreateBy")]
        [ExcelIgnore]
        public string Create_by { get; set; }
        /// <summary>
        /// 新建时间
        /// </summary>

        [SugarColumn(IsOnlyIgnoreUpdate = true)]
        [JsonProperty(propertyName: "CreateTime")]
        [ExcelColumn(Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime Create_time { get; set; } = DateTime.Now;
        /// <summary>
        /// 更新
        /// </summary>
        [JsonIgnore]
        [JsonProperty(propertyName: "UpdateBy")]
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        [ExcelIgnore]
        public string Update_by { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        //[JsonIgnore]
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        [JsonProperty(propertyName: "UpdateTime")]
        [ExcelIgnore]
        public DateTime? Update_time { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [JsonIgnore]
        [ExcelIgnore]
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [JsonIgnore]
        [ExcelIgnore]
        public DateTime? EndTime { get; set; }
    }
}
