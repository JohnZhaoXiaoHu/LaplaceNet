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
    /// @author Davis.Cheng
    /// @date 2023-04-26
    /// </summary>
    public class FicoPrctrQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        public string FpPlnt { get; set; }
        /// <summary>
        /// 描述 :代码 
        /// </summary>
        public string FpCode { get; set; }
        /// <summary>
        /// 描述 :类别 
        /// </summary>
        public string FpType { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginFpActDate { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndFpActDate { get; set; }
    }

    /// <summary>
    /// 利润中心输入输出对象
    /// </summary>
    public class FicoPrctrDto
    {
        /// <summary>
        /// 描述 :Id主键 
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        [ExcelIgnore]
        public long FpId { get; set; }

        /// <summary>
        /// 描述 :工厂 
        /// </summary>
        [Required(ErrorMessage = "工厂不能为空")]

        [ExcelColumn(Name = "工厂")]
        public string FpPlnt { get; set; }

        /// <summary>
        /// 描述 :代码 
        /// </summary>
        [Required(ErrorMessage = "代码不能为空")]

        [ExcelColumn(Name = "代码")]
        public string FpCode { get; set; }

        /// <summary>
        /// 描述 :名称 
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]

        [ExcelColumn(Name = "名称")]
        public string FpName { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// </summary>
        [Required(ErrorMessage = "类别不能为空")]

        [ExcelColumn(Name = "类别")]
        public string FpType { get; set; }

        /// <summary>
        /// 描述 :有效从 
        /// </summary>
        [Required(ErrorMessage = "有效从不能为空")]

        [ExcelColumn(Name = "有效从", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? FpActDate { get; set; }

        /// <summary>
        /// 描述 :有效到 
        /// </summary>
        [Required(ErrorMessage = "有效到不能为空")]

        [ExcelColumn(Name = "有效到", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? FpExpDate { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
        /// </summary>

        [ExcelColumn(Name = "ReMark")]
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