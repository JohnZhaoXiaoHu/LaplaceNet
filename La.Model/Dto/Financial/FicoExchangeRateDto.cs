using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 汇率表查询对象
    /// </summary>
    public class FicoExchangeRateQueryDto : PagerInfo 
    {
        public DateTime? BeginErEffDate { get; set; }
        public DateTime? EndErEffDate { get; set; }
        public string ErfmCcy { get; set; }
    }

    /// <summary>
    /// 汇率表输入输出对象
    /// </summary>
    public class FicoExchangeRateDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long ErId { get; set; }

        [Required(ErrorMessage = "生效日期不能为空")]
        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? ErEffDate { get; set; }

        [Required(ErrorMessage = "基数不能为空")]
        [ExcelColumn(Name = "基数")]
        public int ErStd { get; set; }

        [Required(ErrorMessage = "Fm币别不能为空")]
        [ExcelColumn(Name = "Fm币别")]
        public string ErfmCcy { get; set; }

        [Required(ErrorMessage = "汇率不能为空")]
        [ExcelColumn(Name = "汇率")]
        public decimal ErRate { get; set; }

        [Required(ErrorMessage = "To币别不能为空")]
        [ExcelColumn(Name = "To币别")]
        public string ErtoCcy { get; set; }

        [ExcelIgnore]
        public bool IsDelete { get; set; }

        [ExcelColumn(Name = "说明")]
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