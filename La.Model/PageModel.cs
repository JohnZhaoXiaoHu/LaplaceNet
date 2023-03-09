using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La.Model
{
    /// <summary>
    /// 页面模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageModel<T>
    {
        /// <summary>
        /// 页面模型
        /// </summary>
        public PageModel() { }
        /// <summary>
        /// 页面模型
        /// </summary>
        /// <param name="data"></param>
        /// <param name="total"></param>
        public PageModel(T data, int total)
        {
            Data = data;
            Total = total;
        }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }
    /// <summary>
    /// 页面模型
    /// </summary>
    public class PageModel : PageModel<object>
    {
        /// <summary>
        /// 页面模型
        /// </summary>
        public PageModel() { }
        /// <summary>
        /// 页面模型
        /// </summary>
        /// <param name="data"></param>
        /// <param name="total"></param>
        public PageModel(object data, int total) : base(data, total)
        {
        }
    }
}
