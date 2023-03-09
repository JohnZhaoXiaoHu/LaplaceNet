using System.Collections.Generic;
using La.Model.System.Generate;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 代码生成输入对象
    /// </summary>
    public class GenTableDto
    {
        /// <summary>
        /// 表ID
        /// </summary>
        public int TableId { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 表注释
        /// </summary>
        public string TableComment { get; set; }
        /// <summary>
        /// 子表名称
        /// </summary>
        public string SubTableName { get; set; }
        /// <summary>
        /// 子表主键名称
        /// </summary>
        public string SubTableFkName { get; set; }
        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string TplCategory { get; set; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string BaseNameSpace { get; set; }
        /// <summary>
        /// 模组名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        /// 业务名称
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        public string FunctionName { get; set; }
        /// <summary>
        /// 人员
        /// </summary>
        public string FunctionAuthor { get; set; }
        /// <summary>
        /// 生成方式
        /// </summary>
        public string GenType { get; set; }
        /// <summary>
        /// 生成路径
        /// </summary>
        public string GenPath { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        //public string PermissionPrefix { get; set; }
        public string Remark { get; set; }
        
        /// <summary>
        /// 额外参数
        /// </summary>
        public Options Params { get; set; }
        /// <summary>
        /// 列显示
        /// </summary>
        public List<GenTableColumnDto> Columns { get; set; }
    }

    /// <summary>
    /// 额外参数
    /// ****注意里面参数统一首字母小写*****
    /// </summary>
    public class Params
    {
        /// <summary>
        /// 树形代码
        /// </summary>
        public string TreeCode { get; set; }
        /// <summary>
        /// 树形名称
        /// </summary>
        public string TreeName { get; set; }
        /// <summary>
        /// 树父代码
        /// </summary>
        public string TreeParentCode { get; set; }
        /// <summary>
        /// 父菜单ID
        /// </summary>
        public int? ParentMenuId { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public string SortField { get; set; }
        /// <summary>
        /// 排序类别
        /// </summary>
        public string SortType { get; set; }
        /// <summary>
        /// 额外参数字符串
        /// </summary>
        public string CheckedBtn { get; set; }
        /// <summary>
        /// 权限前缀
        /// </summary>
        public string PermissionPrefix { get; set; }
    }
    /// <summary>
    /// 生成查询对象
    /// </summary>
    public class GenTableColumnDto
    {
        /// <summary>
        /// 列ID
        /// </summary>
        public int ColumnId { get; set; }
        /// <summary>
        /// 表ID
        /// </summary>
        public int TableId { get; set; }
        /// <summary>
        /// 字段描述
        /// </summary>
        public string ColumnComment { get; set; }
        /// <summary>
        /// C#类型
        /// </summary>
        public string CsharpType { get; set; }
        /// <summary>
        /// C#字段
        /// </summary>
        public string CsharpField { get; set; }
        /// <summary>
        /// 插入
        /// </summary>
        public bool IsInsert { get; set; }
        /// <summary>
        /// 编辑
        /// </summary>
        public bool IsEdit { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        public bool IsList { get; set; }
        /// <summary>
        /// 查询
        /// </summary>
        public bool IsQuery { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public bool IsSort { get; set; }
        /// <summary>
        /// 必填
        /// </summary>
        public bool IsRequired { get; set; }
        /// <summary>
        /// 导出
        /// </summary>
        public bool IsExport { get; set; }
        /// <summary>
        /// 显示类型（文本框、文本域、下拉框、复选框、单选框、日期控件）
        /// </summary>
        public string HtmlType { get; set; }
        /// <summary>
        /// 查询类型（等于、不等于、大于、小于、范围）
        /// </summary>
        public string QueryType { get; set; } = "EQ";
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 自动填充类型
        /// </summary>
        public int? AutoFillType { get; set; }
    }
}
