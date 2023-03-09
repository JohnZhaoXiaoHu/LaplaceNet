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
        /// <summary>
        /// 描述 :父GUID 
        /// </summary>
        public string PomGuid { get; set; }
    }

    /// <summary>
    /// oph从表输入输出对象
    /// </summary>
    public class PpOutputSlaveDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [ExcelIgnore]
        public int? PosId { get; set; }

        /// <summary>
        /// 描述 :父GUID 
        /// </summary>
        [Required(ErrorMessage = "父GUID不能为空")]

        [ExcelColumn(Name = "父GUID")]
        public string PomGuid { get; set; }

        /// <summary>
        /// 描述 :生产时段 
        /// </summary>

        [ExcelColumn(Name = "生产时段")]
        public string PosStartEndTime { get; set; }

        /// <summary>
        /// 描述 :实际产能 
        /// </summary>
        [Required(ErrorMessage = "实际产能不能为空")]

        [ExcelColumn(Name = "实际产能")]
        public int PosRealOutput { get; set; }

        /// <summary>
        /// 描述 :停线时间 
        /// </summary>
        [Required(ErrorMessage = "停线时间不能为空")]

        [ExcelColumn(Name = "停线时间")]
        public int PosLineStopTime { get; set; }

        /// <summary>
        /// 描述 :停线原因 
        /// </summary>

        [ExcelColumn(Name = "停线原因")]
        public string PosStopCause { get; set; }

        /// <summary>
        /// 描述 :停线说明 
        /// </summary>

        [ExcelColumn(Name = "停线说明")]
        public string PosStopMemo { get; set; }

        /// <summary>
        /// 描述 :未达成原因 
        /// </summary>

        [ExcelColumn(Name = "未达成原因")]
        public string PosBadCause { get; set; }

        /// <summary>
        /// 描述 :未达成说明 
        /// </summary>

        [ExcelColumn(Name = "未达成说明")]
        public string PosBadMemo { get; set; }

        /// <summary>
        /// 描述 :实际工数 
        /// </summary>
        [Required(ErrorMessage = "实际工数不能为空")]

        [ExcelColumn(Name = "实际工数")]
        public int PosRealTime { get; set; }

        /// <summary>
        /// 描述 :实际工时 
        /// </summary>
        [Required(ErrorMessage = "实际工时不能为空")]

        [ExcelColumn(Name = "实际工时")]
        public decimal PosRealWork { get; set; }

        /// <summary>
        /// 描述 :工时差异 
        /// </summary>
        [Required(ErrorMessage = "工时差异不能为空")]

        [ExcelColumn(Name = "工时差异")]
        public decimal PosRealWorkDiff { get; set; }

        /// <summary>
        /// 描述 :产能差异 
        /// </summary>
        [Required(ErrorMessage = "产能差异不能为空")]

        [ExcelColumn(Name = "产能差异")]
        public decimal PosRealOutputDiff { get; set; }

        /// <summary>
        /// 描述 :达成率 
        /// </summary>
        [Required(ErrorMessage = "达成率不能为空")]

        [ExcelColumn(Name = "达成率")]
        public int PosAchRatio { get; set; }

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
        /// 描述 :说明 
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