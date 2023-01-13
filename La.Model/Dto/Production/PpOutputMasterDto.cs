using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// oph主表查询对象
    /// </summary>
    public class PpOutputMasterQueryDto : PagerInfo 
    {
        public string PomOrder { get; set; }
        public string PomMflot { get; set; }
        public string PomModelName { get; set; }
        public string PomMfItem { get; set; }
        public DateTime? BeginPomMfDate { get; set; }
        public DateTime? EndPomMfDate { get; set; }
        public string PomLineName { get; set; }
    }

    /// <summary>
    /// oph主表输入输出对象
    /// </summary>
    public class PpOutputMasterDto
    {
        [ExcelIgnore]
        public int? PomId { get; set; }

        [Required(ErrorMessage = "GUID不能为空")]
        [ExcelColumn(Name = "GUID")]
        public string PomGuid { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        [ExcelColumn(Name = "生产工单")]
        public string PomOrder { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        public decimal PomOrderQty { get; set; }

        [Required(ErrorMessage = "管理序列号不能为空")]
        [ExcelColumn(Name = "管理序列号")]
        public string PomOrderSerial { get; set; }

        [Required(ErrorMessage = "生产批次不能为空")]
        [ExcelColumn(Name = "生产批次")]
        public string PomMflot { get; set; }

        [Required(ErrorMessage = "机种名不能为空")]
        [ExcelColumn(Name = "机种名")]
        public string PomModelName { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        public string PomMfItem { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? PomMfDate { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        [ExcelColumn(Name = "生产班组")]
        public string PomLineName { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        [ExcelColumn(Name = "直接人数")]
        public int PomDirect { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        public int PomIndirect { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        [ExcelColumn(Name = "标准工时")]
        public decimal PomStdTime { get; set; }

        [Required(ErrorMessage = "标准产能不能为空")]
        [ExcelColumn(Name = "标准产能")]
        public decimal PomStdOutput { get; set; }

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

        [Required(ErrorMessage = "不能为空")]
        [ExcelColumn(Name = "UDF54")]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "不能为空")]
        [ExcelColumn(Name = "UDF55")]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "不能为空")]
        [ExcelColumn(Name = "UDF56")]
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