using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 任务日志查询
    /// </summary>
    public class TasksLogQueryDto
    {
        /// <summary>
        /// 描述 : 查询字符串 
        /// 空值 : False
        /// 默认 : 
        /// </summary>
        //[Display(Name = "查询字符串")]
        public string Name{ get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string JobId { get; set; }
        /// <summary>
        /// 组
        /// </summary>
        public string JobGroup { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// 任务日志输入输出
    /// </summary>
    public class TasksLogDto
    {

    }
}
