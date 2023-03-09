using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 字典输入对象
    /// </summary>
    public class SysdictDataDto
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string DictType { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        public List<SysDictData> List { get; set; }
    }
}
