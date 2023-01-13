using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// oph从表查询对象
    /// </summary>
    public class PpOutputSlaveQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// oph从表输入输出对象
    /// </summary>
    public class PpOutputSlaveDto
    {
        [ExcelIgnore]
        public int? PosId { get; set; }

        [Required(ErrorMessage = "父GUID不能为空")]
        [ExcelColumn(Name = "父GUID")]
        public string PomGuid { get; set; }

        [ExcelColumn(Name = "生产时段")]
        public string PosStartEndTime { get; set; }

        [Required(ErrorMessage = "实际产能不能为空")]
        [ExcelColumn(Name = "实际产能")]
        public int PosRealOutput { get; set; }

        [Required(ErrorMessage = "停线时间不能为空")]
        [ExcelColumn(Name = "停线时间")]
        public int PosLineStopTime { get; set; }

        [ExcelColumn(Name = "停线原因")]
        public string PosStopCause { get; set; }

        [ExcelColumn(Name = "停线说明")]
        public string PosStopMemo { get; set; }

        [ExcelColumn(Name = "未达成原因")]
        public string PosBadCause { get; set; }

        [ExcelColumn(Name = "未达成说明")]
        public string PosBadMemo { get; set; }

        [Required(ErrorMessage = "实际工数不能为空")]
        [ExcelColumn(Name = "实际工数")]
        public int PosRealTime { get; set; }

        [Required(ErrorMessage = "实际工时不能为空")]
        [ExcelColumn(Name = "实际工时")]
        public decimal PosRealWork { get; set; }

        [Required(ErrorMessage = "工时差异不能为空")]
        [ExcelColumn(Name = "工时差异")]
        public decimal PosRealWorkDiff { get; set; }

        [Required(ErrorMessage = "产能差异不能为空")]
        [ExcelColumn(Name = "产能差异")]
        public decimal PosRealOutputDiff { get; set; }

        [Required(ErrorMessage = "达成率不能为空")]
        [ExcelColumn(Name = "达成率")]
        public int PosAchRatio { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        [ExcelIgnore]
        public string ReMark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}