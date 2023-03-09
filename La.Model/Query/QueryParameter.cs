using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La.Model.Query
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryParameter
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ConditionalType Type { get; set; } = ConditionalType.Like;
    }
}
