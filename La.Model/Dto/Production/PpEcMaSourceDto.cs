using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 主源设变查询对象
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    public class PpEcMaSourceQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :设变No. 
        /// </summary>
        public string DSapZpabdZ001 { get; set; }
        /// <summary>
        /// 描述 :标题 
        /// </summary>
        public string DSapZpabdZ003 { get; set; }
        /// <summary>
        /// 描述 :状态 
        /// </summary>
        public string DSapZpabdZ004 { get; set; }
        /// <summary>
        /// 描述 :开始时间
        /// </summary>
        public DateTime? BeginDSapZpabdZ005 { get; set; }
        /// <summary>
        /// 描述 :结束时间
        /// </summary>
        public DateTime? EndDSapZpabdZ005 { get; set; }
        /// <summary>
        /// 描述 :处理标记 
        /// </summary>
        public byte? IsSolved { get; set; }
    }

    /// <summary>
    /// 主源设变输入输出对象
    /// </summary>
    public class PpEcMaSourceDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        public string Guid { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// </summary>

        [ExcelColumn(Name = "设变No.")]
        public string DSapZpabdZ001 { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// </summary>

        [ExcelColumn(Name = "机种")]
        public string DSapZpabdZ002 { get; set; }

        /// <summary>
        /// 描述 :标题 
        /// </summary>

        [ExcelColumn(Name = "标题")]
        public string DSapZpabdZ003 { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// </summary>

        [ExcelColumn(Name = "状态")]
        public string DSapZpabdZ004 { get; set; }

        /// <summary>
        /// 描述 :发行日 
        /// </summary>

        [ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? DSapZpabdZ005 { get; set; }

        /// <summary>
        /// 描述 :担当 
        /// </summary>

        [ExcelColumn(Name = "担当")]
        public string DSapZpabdZ006 { get; set; }

        /// <summary>
        /// 描述 :依赖 
        /// </summary>

        [ExcelColumn(Name = "依赖")]
        public string DSapZpabdZ007 { get; set; }

        /// <summary>
        /// 描述 :会议 
        /// </summary>

        [ExcelColumn(Name = "会议")]
        public string DSapZpabdZ008 { get; set; }

        /// <summary>
        /// 描述 :PP番号 
        /// </summary>

        [ExcelColumn(Name = "PP番号")]
        public string DSapZpabdZ009 { get; set; }

        /// <summary>
        /// 描述 :联络书 
        /// </summary>

        [ExcelColumn(Name = "联络书")]
        public string DSapZpabdZ010 { get; set; }

        /// <summary>
        /// 描述 :实施 
        /// </summary>

        [ExcelColumn(Name = "实施")]
        public string DSapZpabdZ011 { get; set; }

        /// <summary>
        /// 描述 :主理由 
        /// </summary>

        [ExcelColumn(Name = "主理由")]
        public string DSapZpabdZ012 { get; set; }

        /// <summary>
        /// 描述 :次理由 
        /// </summary>

        [ExcelColumn(Name = "次理由")]
        public string DSapZpabdZ013 { get; set; }

        /// <summary>
        /// 描述 :安规 
        /// </summary>

        [ExcelColumn(Name = "安规")]
        public string DSapZpabdZ014 { get; set; }

        /// <summary>
        /// 描述 :状况 
        /// </summary>

        [ExcelColumn(Name = "状况")]
        public string DSapZpabdZ015 { get; set; }

        /// <summary>
        /// 描述 :机番 
        /// </summary>

        [ExcelColumn(Name = "机番")]
        public string DSapZpabdZ016 { get; set; }

        /// <summary>
        /// 描述 :承认 
        /// </summary>

        [ExcelColumn(Name = "承认")]
        public string DSapZpabdZ017 { get; set; }

        /// <summary>
        /// 描述 :服务手册订正 
        /// </summary>

        [ExcelColumn(Name = "服务手册订正")]
        public string DSapZpabdZ018 { get; set; }

        /// <summary>
        /// 描述 :用户手册订正 
        /// </summary>

        [ExcelColumn(Name = "用户手册订正")]
        public string DSapZpabdZ019 { get; set; }

        /// <summary>
        /// 描述 :宣传手册订正 
        /// </summary>

        [ExcelColumn(Name = "宣传手册订正")]
        public string DSapZpabdZ020 { get; set; }

        /// <summary>
        /// 描述 :SOP订正 
        /// </summary>

        [ExcelColumn(Name = "SOP订正")]
        public string DSapZpabdZ021 { get; set; }

        /// <summary>
        /// 描述 :信息发行 
        /// </summary>

        [ExcelColumn(Name = "信息发行")]
        public string DSapZpabdZ022 { get; set; }

        /// <summary>
        /// 描述 :成本变动 
        /// </summary>

        [ExcelColumn(Name = "成本变动")]
        public string DSapZpabdZ023 { get; set; }

        /// <summary>
        /// 描述 :单位成本 
        /// </summary>

        [ExcelColumn(Name = "单位成本")]
        public string DSapZpabdZ024 { get; set; }

        /// <summary>
        /// 描述 :模具改造费 
        /// </summary>

        [ExcelColumn(Name = "模具改造费")]
        public string DSapZpabdZ025 { get; set; }

        /// <summary>
        /// 描述 :图纸 
        /// </summary>

        [ExcelColumn(Name = "图纸")]
        public string DSapZpabdZ026 { get; set; }

        /// <summary>
        /// 描述 :设变内容 
        /// </summary>

        [ExcelColumn(Name = "设变内容")]
        public string DSapZpabdZ027 { get; set; }

        /// <summary>
        /// 描述 :处理标记 
        /// </summary>
        [Required(ErrorMessage = "处理标记不能为空")]

        [ExcelColumn(Name = "处理标记")]
        public byte IsSolved { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
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