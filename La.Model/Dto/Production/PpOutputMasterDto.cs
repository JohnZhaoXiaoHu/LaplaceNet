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
        /// <summary>
        /// 描述 :生产工单 
        /// </summary>
        public string PomOrder { get; set; }
        /// <summary>
        /// 描述 :生产批次 
        /// </summary>
        public string PomMflot { get; set; }
        /// <summary>
        /// 描述 :机种名 
        /// </summary>
        public string PomModelName { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string PomMfItem { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginPomMfDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndPomMfDate { get; set; }
        /// <summary>
        /// 描述 :生产班组 
        /// </summary>
        public string PomLineName { get; set; }
    }

    /// <summary>
    /// oph主表输入输出对象
    /// </summary>
    public class PpOutputMasterDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [ExcelIgnore]
        public int? PomId { get; set; }

        /// <summary>
        /// 描述 :GUID 
        /// </summary>
        [Required(ErrorMessage = "GUID不能为空")]

        [ExcelColumn(Name = "GUID")]
        public string PomGuid { get; set; }

        /// <summary>
        /// 描述 :生产工单 
        /// </summary>
        [Required(ErrorMessage = "生产工单不能为空")]

        [ExcelColumn(Name = "生产工单")]
        public string PomOrder { get; set; }

        /// <summary>
        /// 描述 :工单数量 
        /// </summary>
        [Required(ErrorMessage = "工单数量不能为空")]

        [ExcelColumn(Name = "工单数量")]
        public decimal PomOrderQty { get; set; }

        /// <summary>
        /// 描述 :管理序列号 
        /// </summary>
        [Required(ErrorMessage = "管理序列号不能为空")]

        [ExcelColumn(Name = "管理序列号")]
        public string PomOrderSerial { get; set; }

        /// <summary>
        /// 描述 :生产批次 
        /// </summary>
        [Required(ErrorMessage = "生产批次不能为空")]

        [ExcelColumn(Name = "生产批次")]
        public string PomMflot { get; set; }

        /// <summary>
        /// 描述 :机种名 
        /// </summary>
        [Required(ErrorMessage = "机种名不能为空")]

        [ExcelColumn(Name = "机种名")]
        public string PomModelName { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>
        [Required(ErrorMessage = "物料不能为空")]

        [ExcelColumn(Name = "物料")]
        public string PomMfItem { get; set; }

        /// <summary>
        /// 描述 :生产日期 
        /// </summary>
        [Required(ErrorMessage = "生产日期不能为空")]

        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? PomMfDate { get; set; }

        /// <summary>
        /// 描述 :生产班组 
        /// </summary>
        [Required(ErrorMessage = "生产班组不能为空")]

        [ExcelColumn(Name = "生产班组")]
        public string PomLineName { get; set; }

        /// <summary>
        /// 描述 :直接人数 
        /// </summary>
        [Required(ErrorMessage = "直接人数不能为空")]

        [ExcelColumn(Name = "直接人数")]
        public int PomDirect { get; set; }

        /// <summary>
        /// 描述 :间接人数 
        /// </summary>
        [Required(ErrorMessage = "间接人数不能为空")]

        [ExcelColumn(Name = "间接人数")]
        public int PomIndirect { get; set; }

        /// <summary>
        /// 描述 :标准工时 
        /// </summary>
        [Required(ErrorMessage = "标准工时不能为空")]

        [ExcelColumn(Name = "标准工时")]
        public decimal PomStdTime { get; set; }

        /// <summary>
        /// 描述 :标准产能 
        /// </summary>
        [Required(ErrorMessage = "标准产能不能为空")]

        [ExcelColumn(Name = "标准产能")]
        public decimal PomStdOutput { get; set; }

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
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF54")]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF55")]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [Required(ErrorMessage = "不能为空")]

        [ExcelColumn(Name = "UDF56")]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
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