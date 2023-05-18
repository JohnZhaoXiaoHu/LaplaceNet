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
    /// @author Davis.Cheng
    /// @date 2023-05-18
    /// </summary>
    public class FicoExchangeRateQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginErEffDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndErEffDate { get; set; }
        /// <summary>
        /// 描述 :Fm币别 
        /// </summary>
        public string ErfmCcy { get; set; }
        /// <summary>
        /// 描述 :To币别 
        /// </summary>
        public string ErtoCcy { get; set; }
    }

    /// <summary>
    /// 汇率表输入输出对象
    /// </summary>
    public class FicoExchangeRateDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public long ErId { get; set; }

        /// <summary>
        /// 描述 :生效日期 
        /// </summary>
        [Required(ErrorMessage = "生效日期不能为空")]

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? ErEffDate { get; set; }

        /// <summary>
        /// 描述 :基数 
        /// </summary>
        [Required(ErrorMessage = "基数不能为空")]

        [ExcelColumn(Name = "基数")]
        public int ErStd { get; set; }

        /// <summary>
        /// 描述 :Fm币别 
        /// </summary>
        [Required(ErrorMessage = "Fm币别不能为空")]

        [ExcelColumn(Name = "Fm币别")]
        public string ErfmCcy { get; set; }

        /// <summary>
        /// 描述 :汇率 
        /// </summary>
        [Required(ErrorMessage = "汇率不能为空")]

        [ExcelColumn(Name = "汇率")]
        public decimal ErRate { get; set; }

        /// <summary>
        /// 描述 :To币别 
        /// </summary>
        [Required(ErrorMessage = "To币别不能为空")]

        [ExcelColumn(Name = "To币别")]
        public string ErtoCcy { get; set; }

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
        /// 描述 :CreateBy 
        /// </summary>
        [ExcelIgnore]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}