using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 利润中心查询对象
    /// </summary>
    public class FicoPrctrQueryDto : PagerInfo 
    {
        public string FpPlnt { get; set; }
        public string FpCode { get; set; }
        public string FpName { get; set; }
        public string FpType { get; set; }
    }

    /// <summary>
    /// 利润中心输入输出对象
    /// </summary>
    public class FicoPrctrDto
    {
        [ExcelIgnore]
        public long? FpId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        public string FpPlnt { get; set; }

        [Required(ErrorMessage = "代码不能为空")]
        [ExcelColumn(Name = "代码")]
        public string FpCode { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        public string FpName { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        public string FpType { get; set; }

        [Required(ErrorMessage = "有效从不能为空")]
        [ExcelColumn(Name = "有效从", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? FpActDate { get; set; }

        [Required(ErrorMessage = "有效到不能为空")]
        [ExcelColumn(Name = "有效到", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? FpExpDate { get; set; }

        [ExcelIgnore]
        public bool IsDeleted { get; set; }

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