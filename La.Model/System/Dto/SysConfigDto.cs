using System;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 参数配置输入对象模型
    /// </summary>
    public class SysConfigDto
    {
        /// <summary>
        /// 配置ID
        /// </summary>
        public int ConfigId { get; set; }
        /// <summary>
        /// 配置名称
        /// </summary>
        public string ConfigName { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        public string ConfigKey { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string ConfigValue { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string ConfigType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }

    /// <summary>
    /// 参数配置查询对象模型
    /// </summary>
    public class SysConfigQueryDto : PagerInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string ConfigName { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        public string ConfigKey { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string ConfigValue { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string ConfigType { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
