using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 表单，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-03-14
    /// </summary>
    [SugarTable("wf_form")]
    public class WfForm
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :表单名称 
        /// 空值 :true 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述 :表单类型 
        /// 空值 :true 
        /// </summary>
        public int? FrmType { get; set; }

        /// <summary>
        /// 描述 :自定义表单 
        /// 空值 :true 
        /// </summary>
        public string WebId { get; set; }

        /// <summary>
        /// 描述 :字段数 
        /// 空值 :true 
        /// </summary>
        public int? Fields { get; set; }

        /// <summary>
        /// 描述 :字段 
        /// 空值 :true 
        /// </summary>
        public string ContentData { get; set; }

        /// <summary>
        /// 描述 :字段格式化 
        /// 空值 :true 
        /// </summary>
        public string ContentParse { get; set; }

        /// <summary>
        /// 描述 :表单内容 
        /// 空值 :true 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 描述 :数据库备用 
        /// 空值 :true 
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// 描述 :组织id 
        /// 空值 :true 
        /// </summary>
        public long? OrgId { get; set; }

        /// <summary>
        /// 描述 :执行 
        /// 空值 :true 
        /// </summary>
        public string Active { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :false 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 描述 :排序 
        /// 空值 :false 
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// 空值 :true 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}