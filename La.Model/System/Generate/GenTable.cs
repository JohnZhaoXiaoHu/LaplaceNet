﻿using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System.Generate
{
    /// <summary>
    /// 代码生成表
    /// </summary>
    [SqlSugar.SugarTable("gen_table")]
    [SqlSugar.Tenant("0")]
    public class GenTable : SysBase
    {
        /// <summary>
        /// 表id
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int TableId { get; set; }
        /// <summary>
        /// 数据库名
        /// </summary>
        public string DbName { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 表描述
        /// </summary>
        public string TableComment { get; set; }
        /// <summary>
        /// 关联父表的表名
        /// </summary>
        public string SubTableName { get; set; }
        /// <summary>
        /// 本表关联父表的外键名
        /// </summary>
        public string SubTableFkName { get; set; }
        /// <summary>
        /// csharp类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 使用的模板（crud单表操作 tree树表操作 sub主子表操作）
        /// </summary>
        public string TplCategory { get; set; }
        /// <summary>
        /// 基本命名空间前缀
        /// </summary>
        public string BaseNameSpace { get; set; }
        /// <summary>
        /// 生成模块名
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 生成业务名
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// 生成功能名
        /// </summary>
        public string FunctionName { get; set; }
        /// <summary>
        /// 生成作者名
        /// </summary>
        public string FunctionAuthor { get; set; }
        /// <summary>
        /// 生成代码方式（0zip压缩包 1自定义路径）
        /// </summary>
        public string GenType { get; set; }
        /// <summary>
        /// 代码生成路径
        /// </summary>
        public string GenPath { get; set; }
        /// <summary>
        /// 其他生成选项
        /// </summary>
        [SqlSugar.SugarColumn(IsJson = true, ColumnDataType = "nvarchar(4000)")]
        public Options Options { get; set; }

        #region 表额外字段
        /** 表列信息 */
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public List<GenTableColumn> Columns { get; set; }

        /// <summary>
        /// 字表信息
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public GenTable SubTable { get; set; }
        #endregion
    }

    /// <summary>
    /// 选项
    /// </summary>
    public class Options
    {
        /// <summary>
        /// 主菜单ID
        /// </summary>
        public long ParentMenuId { get; set; } = 0;
        /// <summary>
        /// 排序类别：升序默认
        /// </summary>
        public string SortType { get; set; } = "asc";
        /// <summary>
        /// 排序ID
        /// </summary>
        public string SortField { get; set; } = string.Empty;
        /// <summary>
        /// 树代码
        /// </summary>
        public string TreeCode { get; set; } = string.Empty;
        /// <summary>
        /// 树名称
        /// </summary>
        public string TreeName { get; set; } = string.Empty;
        /// <summary>
        /// 主树代码
        /// </summary>
        public string TreeParentCode { get; set; } = string.Empty;
        /// <summary>
        /// 权限前缀
        /// </summary>
        public string PermissionPrefix { get; set; } = string.Empty;
        /// <summary>
        /// 额外参数字符串
        /// </summary>
        public int[] CheckedBtn { get; set; } = new int[] { 1, 2, 3 };
        /// <summary>
        /// 列大小 12,24
        /// </summary>
        public int ColNum { get; set; } = 12;
        /// <summary>
        /// 是否生成仓储层
        /// </summary>
        public int GenerateRepo { get; set; }
    }
}
