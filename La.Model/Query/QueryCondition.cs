using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La.Model.Query
{
    /// <summary>
    /// 查询页面条件
    /// </summary>
    public class QueryPageCondition
    {
        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        public List<QueryParameter> Parameters { get; set; } = new List<QueryParameter>();
        /// <summary>
        /// 排序
        /// </summary>
        public List<string> OrderBys { get; set; } = new List<string>();
        /// <summary>
        /// 升序
        /// </summary>
        public bool IsAsc { get; set; } = false;
    }
    /// <summary>
    /// 查询条件
    /// </summary>
    public class QueryCondition
    {
        /// <summary>
        /// 参数
        /// </summary>
        public List<QueryParameter> Parameters { get; set; } = new List<QueryParameter>();
        /// <summary>
        /// 排序
        /// </summary>
        public List<string> OrderBys { get; set; } = new List<string>();
        /// <summary>
        /// 升序
        /// </summary>
        public bool IsAsc { get; set; } = false;

    }
}
