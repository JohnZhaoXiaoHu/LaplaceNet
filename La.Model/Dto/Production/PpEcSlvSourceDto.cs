using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 从源设变查询对象
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    public class PpEcSlvSourceQueryDto : PagerInfo 
    {
        /// <summary>
        /// 描述 :设变No. 
        /// </summary>
        public string DSapZpabdS001 { get; set; }
        /// <summary>
        /// 描述 :完成品 
        /// </summary>
        public string DSapZpabdS002 { get; set; }
        /// <summary>
        /// 描述 :上阶 
        /// </summary>
        public string DSapZpabdS003 { get; set; }
        /// <summary>
        /// 描述 :旧物料 
        /// </summary>
        public string DSapZpabdS004 { get; set; }
        /// <summary>
        /// 描述 :新物料 
        /// </summary>
        public string DSapZpabdS008 { get; set; }
        /// <summary>
        /// 描述 :处理标记 
        /// </summary>
        public byte? IsSolved { get; set; }
    }

    /// <summary>
    /// 从源设变输入输出对象
    /// </summary>
    public class PpEcSlvSourceDto
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
        public string DSapZpabdS001 { get; set; }

        /// <summary>
        /// 描述 :完成品 
        /// </summary>

        [ExcelColumn(Name = "完成品")]
        public string DSapZpabdS002 { get; set; }

        /// <summary>
        /// 描述 :上阶 
        /// </summary>

        [ExcelColumn(Name = "上阶")]
        public string DSapZpabdS003 { get; set; }

        /// <summary>
        /// 描述 :旧物料 
        /// </summary>

        [ExcelColumn(Name = "旧物料")]
        public string DSapZpabdS004 { get; set; }

        /// <summary>
        /// 描述 :品名 
        /// </summary>

        [ExcelColumn(Name = "品名")]
        public string DSapZpabdS005 { get; set; }

        /// <summary>
        /// 描述 :数量 
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]

        [ExcelColumn(Name = "数量")]
        public decimal DSapZpabdS006 { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// </summary>

        [ExcelColumn(Name = "位置")]
        public string DSapZpabdS007 { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// </summary>

        [ExcelColumn(Name = "新物料")]
        public string DSapZpabdS008 { get; set; }

        /// <summary>
        /// 描述 :品名 
        /// </summary>

        [ExcelColumn(Name = "品名")]
        public string DSapZpabdS009 { get; set; }

        /// <summary>
        /// 描述 :数量 
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]

        [ExcelColumn(Name = "数量")]
        public decimal DSapZpabdS010 { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// </summary>

        [ExcelColumn(Name = "位置")]
        public string DSapZpabdS011 { get; set; }

        /// <summary>
        /// 描述 :BOM番号 
        /// </summary>

        [ExcelColumn(Name = "BOM番号")]
        public string DSapZpabdS012 { get; set; }

        /// <summary>
        /// 描述 :互换性 
        /// </summary>

        [ExcelColumn(Name = "互换性")]
        public string DSapZpabdS013 { get; set; }

        /// <summary>
        /// 描述 :区分 
        /// </summary>

        [ExcelColumn(Name = "区分")]
        public string DSapZpabdS014 { get; set; }

        /// <summary>
        /// 描述 :安排指示 
        /// </summary>

        [ExcelColumn(Name = "安排指示")]
        public string DSapZpabdS015 { get; set; }

        /// <summary>
        /// 描述 :旧品处理 
        /// </summary>

        [ExcelColumn(Name = "旧品处理")]
        public string DSapZpabdS016 { get; set; }

        /// <summary>
        /// 描述 :BOM生效 
        /// </summary>

        [ExcelColumn(Name = "BOM生效", Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime? DSapZpabdS017 { get; set; }

        /// <summary>
        /// 描述 :处理标记 
        /// </summary>
        [Required(ErrorMessage = "处理标记不能为空")]

        [ExcelColumn(Name = "处理标记")]
        public byte IsSolved { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
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