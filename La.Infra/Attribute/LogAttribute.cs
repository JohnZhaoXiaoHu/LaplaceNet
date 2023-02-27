using La.Infra.Enums;

namespace La.Infra.Attribute
{
    /// <summary>
    /// 自定义操作日志记录注解
    /// </summary>
    public class LogAttribute : System.Attribute
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public BusinessType BusinessType { get; set; }
        /// <summary>
        /// 是否保存请求数据
        /// </summary>
        public bool IsSaveRequestData { get; set; } = true;
        /// <summary>
        /// 是否保存返回数据
        /// </summary>
        public bool IsSaveResponseData { get; set; } = true;
        /// <summary>
        /// 属性
        /// </summary>
        public LogAttribute() { }
        /// <summary>
        /// 日志名称
        /// </summary>
        /// <param name="name"></param>
        public LogAttribute(string name)
        {
            Title = name;
        }
        /// <summary>
        /// 日志属性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="businessType"></param>
        /// <param name="saveRequestData"></param>
        /// <param name="saveResponseData"></param>
        public LogAttribute(string name, BusinessType businessType, bool saveRequestData = true, bool saveResponseData = true)
        {
            Title = name;
            BusinessType = businessType;
            IsSaveRequestData = saveRequestData;
            IsSaveResponseData = saveResponseData;
        }
    }
}
