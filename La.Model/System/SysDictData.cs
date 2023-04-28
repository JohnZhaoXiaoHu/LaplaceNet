using MiniExcelLibs.Attributes;
using SqlSugar;
using System.Xml.Linq;

namespace La.Model.System
{
    /// <summary>
    /// 字典数据表
    /// </summary>
    [Tenant("0")]
    [SugarTable("sys_dict_data")]
    public class SysDictData: SysBase
    {
        /// <summary>
        /// 字典主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long DictCode{ get; set; }
        /// <summary>
        /// 字典排序
        /// </summary>
        public int DictSort { get; set; }
        /// <summary>
        /// 字典名称
        /// </summary>
        public string DictLabel { get; set; }
        /// <summary>
        /// 字典数值
        /// </summary>
        public string DictValue { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; }
        /// <summary>
        /// CssClass
        /// </summary>
        public string CssClass { get; set; } = string.Empty;
        /// <summary>
        /// ListClass
        /// </summary>
        public string ListClass { get; set; } = string.Empty;
        /// <summary>
        /// 默认
        /// </summary>
        public string IsDefault { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

    }
}
