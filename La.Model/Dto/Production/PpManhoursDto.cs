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
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginMhEffDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndMhEffDate { get; set; }
        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        public string MhPlant { get; set; }
        /// <summary>
        /// 描述 :机种名 
        /// </summary>
        public string MhModelType { get; set; }
        /// <summary>
        /// 描述 :仕向别 
        /// </summary>
        public string MhRegionType { get; set; }
        /// <summary>
        /// 描述 :物料 
        /// </summary>
        public string MhItem { get; set; }
    }

    /// <summary>
    /// 标准工时输入输出对象
    /// </summary>
    public class PpManhoursDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public long MhId { get; set; }

        /// <summary>
        /// 描述 :生效日期 
        /// </summary>

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? MhEffDate { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]
        public string MhPlant { get; set; }

        /// <summary>
        /// 描述 :机种名 
        /// </summary>
        [Required(ErrorMessage = "机种名不能为空")]

        [ExcelColumn(Name = "机种名")]
        public string MhModelType { get; set; }

        /// <summary>
        /// 描述 :仕向别 
        /// </summary>

        [ExcelColumn(Name = "仕向别")]
        public string MhRegionType { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// </summary>

        [ExcelColumn(Name = "物料")]
        public string MhItem { get; set; }

        /// <summary>
        /// 描述 :物料文本 
        /// </summary>

        [ExcelColumn(Name = "物料文本")]
        public string MhItemText { get; set; }

        /// <summary>
        /// 描述 :工作中心 
        /// </summary>
        [Required(ErrorMessage = "工作中心不能为空")]

        [ExcelColumn(Name = "工作中心")]
        public string MhWcName { get; set; }

        /// <summary>
        /// 描述 :工作中心文本 
        /// </summary>

        [ExcelColumn(Name = "工作中心文本")]
        public string MhWcText { get; set; }

        /// <summary>
        /// 描述 :标准点数 
        /// </summary>
        [Required(ErrorMessage = "标准点数不能为空")]

        [ExcelColumn(Name = "标准点数")]
        public decimal MhStdShort { get; set; }

        /// <summary>
        /// 描述 :Short单位 
        /// </summary>

        [ExcelColumn(Name = "Short单位")]
        public string MhShortUnit { get; set; }

        /// <summary>
        /// 描述 :点数换算汇率 
        /// </summary>
        [Required(ErrorMessage = "点数换算汇率不能为空")]

        [ExcelColumn(Name = "点数换算汇率")]
        public decimal MhToMinRate { get; set; }

        /// <summary>
        /// 描述 :标准工时 
        /// </summary>
        [Required(ErrorMessage = "标准工时不能为空")]

        [ExcelColumn(Name = "标准工时")]
        public decimal MhStdTime { get; set; }

        /// <summary>
        /// 描述 :工时单位 
        /// </summary>

        [ExcelColumn(Name = "工时单位")]
        public string MhTimeUnit { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>
        [ExcelIgnore]
        public string Remark { get; set; }

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