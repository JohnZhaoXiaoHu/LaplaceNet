using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 标准工时查询对象
    /// </summary>
    public class PpManhoursQueryDto : PagerInfo 
    {
        public DateTime? BeginMhEffDate { get; set; }
        public DateTime? EndMhEffDate { get; set; }
        public string MhPlant { get; set; }
        public string MhModelType { get; set; }
        public string MhRegionType { get; set; }
        public string MhItem { get; set; }
    }

    /// <summary>
    /// 标准工时输入输出对象
    /// </summary>
    public class PpManhoursDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long MhId { get; set; }

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MhEffDate { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        public string MhPlant { get; set; }

        [Required(ErrorMessage = "机种名不能为空")]
        [ExcelColumn(Name = "机种名")]
        public string MhModelType { get; set; }

        [ExcelColumn(Name = "仕向别")]
        public string MhRegionType { get; set; }

        [ExcelColumn(Name = "物料")]
        public string MhItem { get; set; }

        [ExcelColumn(Name = "物料文本")]
        public string MhItemText { get; set; }

        [Required(ErrorMessage = "工作中心不能为空")]
        [ExcelColumn(Name = "工作中心")]
        public string MhWcName { get; set; }

        [ExcelColumn(Name = "工作中心文本")]
        public string MhWcText { get; set; }

        [Required(ErrorMessage = "标准点数不能为空")]
        [ExcelColumn(Name = "标准点数")]
        public decimal MhStdShort { get; set; }

        [ExcelColumn(Name = "Short单位")]
        public string MhShortUnit { get; set; }

        [Required(ErrorMessage = "点数换算汇率不能为空")]
        [ExcelColumn(Name = "点数换算汇率")]
        public decimal MhToMinRate { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        [ExcelColumn(Name = "标准工时")]
        public decimal MhStdTime { get; set; }

        [ExcelColumn(Name = "工时单位")]
        public string MhTimeUnit { get; set; }

        [ExcelIgnore]
        public bool IsDelete { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

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