using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 工作流实例操作记录查询对象
    /// </summary>
    public class WfFlowinstanceinfoQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 工作流实例操作记录输入输出对象
    /// </summary>
    public class WfFlowinstanceinfoDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :实例进程Id 
        /// </summary>
        [Required(ErrorMessage = "实例进程Id不能为空")]
        public string InstanceId { get; set; }

        /// <summary>
        /// 描述 :操作内容 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 描述 :Remark 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :创建用户 
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :创建时间 
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        public DateTime? UpdateTime { get; set; }



    }
}