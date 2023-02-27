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
        public string PlLineType { get; set; }
        public string PlLineCode { get; set; }
    }

    /// <summary>
    /// 生产班组输入输出对象
    /// </summary>
    public class PpLinesDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        public long PlId { get; set; }

        [Required(ErrorMessage = "班组类别不能为空")]
        [ExcelColumn(Name = "班组类别")]
        public string PlLineType { get; set; }

        [Required(ErrorMessage = "班组代码不能为空")]
        [ExcelColumn(Name = "班组代码")]
        public string PlLineCode { get; set; }

        [ExcelColumn(Name = "软件删除")]
        public bool IsDelete { get; set; }

        [ExcelColumn(Name = "Remark")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }

        [ExcelColumn(Name = "班组名称")]
        public string PlLineName { get; set; }



    }
}