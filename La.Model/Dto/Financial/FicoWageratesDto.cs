using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 工厂工资率查询对象
    /// @author Davis.Cheng
    /// @date 2023-04-11
    /// </summary>
    public class FicoWageratesQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :年月 
        /// </summary>
        public string FwYm { get; set; }
        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        public string FwPlant { get; set; }
    }

    /// <summary>
    /// 工厂工资率输入输出对象
    /// </summary>
    public class FicoWageratesDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public int FwId { get; set; }

        /// <summary>
        /// 描述 :年月 
        /// </summary>
        [Required(ErrorMessage = "年月不能为空")]

        [ExcelColumn(Name = "年月")]
        public string FwYm { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]
        public string FwPlant { get; set; }

        /// <summary>
        /// 描述 :币种 
        /// </summary>
        [Required(ErrorMessage = "币种不能为空")]

        [ExcelColumn(Name = "币种")]
        public string FwCcy { get; set; }

        /// <summary>
        /// 描述 :销售额 
        /// </summary>
        [Required(ErrorMessage = "销售额不能为空")]

        [ExcelColumn(Name = "销售额")]
        public decimal FwSalesVolume { get; set; }

        /// <summary>
        /// 描述 :工作天数 
        /// </summary>
        [Required(ErrorMessage = "工作天数不能为空")]

        [ExcelColumn(Name = "工作天数")]
        public decimal FwWorkingDays { get; set; }

        /// <summary>
        /// 描述 :直接工资率 
        /// </summary>
        [Required(ErrorMessage = "直接工资率不能为空")]

        [ExcelColumn(Name = "直接工资率")]
        public decimal FwDirectWageRate { get; set; }

        /// <summary>
        /// 描述 :直接人数 
        /// </summary>
        [Required(ErrorMessage = "直接人数不能为空")]

        [ExcelColumn(Name = "直接人数")]
        public decimal FwDirect { get; set; }

        /// <summary>
        /// 描述 :直接加班费 
        /// </summary>
        [Required(ErrorMessage = "直接加班费不能为空")]

        [ExcelColumn(Name = "直接加班费")]
        public decimal FwDirectOverTime { get; set; }

        /// <summary>
        /// 描述 :直接工资 
        /// </summary>
        [Required(ErrorMessage = "直接工资不能为空")]

        [ExcelColumn(Name = "直接工资")]
        public decimal FwDirectWages { get; set; }

        /// <summary>
        /// 描述 :间接工资率 
        /// </summary>
        [Required(ErrorMessage = "间接工资率不能为空")]

        [ExcelColumn(Name = "间接工资率")]
        public decimal FwInDirectWageRate { get; set; }

        /// <summary>
        /// 描述 :间接人数 
        /// </summary>
        [Required(ErrorMessage = "间接人数不能为空")]

        [ExcelColumn(Name = "间接人数")]
        public decimal FwInDirect { get; set; }

        /// <summary>
        /// 描述 :间接加班费 
        /// </summary>
        [Required(ErrorMessage = "间接加班费不能为空")]

        [ExcelColumn(Name = "间接加班费")]
        public decimal FwInDirectOverTime { get; set; }

        /// <summary>
        /// 描述 :间接工资 
        /// </summary>
        [Required(ErrorMessage = "间接工资不能为空")]

        [ExcelColumn(Name = "间接工资")]
        public decimal FwInDirectWages { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// </summary>
        [ExcelIgnore]
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// </summary>
        [ExcelIgnore]
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// </summary>
        [ExcelIgnore]
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// </summary>
        [ExcelIgnore]
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// </summary>
        [ExcelIgnore]
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// </summary>
        [ExcelIgnore]
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
        /// </summary>
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
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