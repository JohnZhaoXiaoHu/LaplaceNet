using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 生产班组查询对象
    /// </summary>
    public class PpLinesQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :班组类别 
        /// </summary>
        public string PlLineType { get; set; }
        /// <summary>
        /// 描述 :班组代码 
        /// </summary>
        public string PlLineCode { get; set; }
    }

    /// <summary>
    /// 生产班组输入输出对象
    /// </summary>
    public class PpLinesDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]

        [ExcelColumn(Name = "ID")]
        public long PlId { get; set; }

        /// <summary>
        /// 描述 :班组类别 
        /// </summary>
        [Required(ErrorMessage = "班组类别不能为空")]

        [ExcelColumn(Name = "班组类别")]
        public string PlLineType { get; set; }

        /// <summary>
        /// 描述 :班组代码 
        /// </summary>
        [Required(ErrorMessage = "班组代码不能为空")]

        [ExcelColumn(Name = "班组代码")]
        public string PlLineCode { get; set; }

        /// <summary>
        /// 描述 :软件删除 
        /// </summary>

        [ExcelColumn(Name = "软件删除")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 描述 : 
        /// </summary>

        [ExcelColumn(Name = "Remark")]
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

        /// <summary>
        /// 描述 :班组名称 
        /// </summary>

        [ExcelColumn(Name = "班组名称")]
        public string PlLineName { get; set; }



    }
}