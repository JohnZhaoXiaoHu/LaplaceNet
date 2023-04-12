using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 工作流实例流转历史记录查询对象
    /// </summary>
    public class WfFlowinstancehisQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 工作流实例流转历史记录输入输出对象
    /// </summary>
    public class WfFlowinstancehisDto
    {
        /// <summary>
        /// 描述 :ID 
        /// </summary>
        [Required(ErrorMessage = "ID不能为空")]
        public long Id { get; set; }

        /// <summary>
        /// 描述 :实例Id 
        /// </summary>
        [Required(ErrorMessage = "实例Id不能为空")]
        public long InstanceId { get; set; }

        /// <summary>
        /// 描述 :开始节点Id 
        /// </summary>
        public string FromNodeId { get; set; }

        /// <summary>
        /// 描述 :开始节点类型 
        /// </summary>
        public long? FromNodeType { get; set; }

        /// <summary>
        /// 描述 :开始节点名称 
        /// </summary>
        public string FromNodeName { get; set; }

        /// <summary>
        /// 描述 :结束节点Id 
        /// </summary>
        public string ToNodeId { get; set; }

        /// <summary>
        /// 描述 :结束节点类型 
        /// </summary>
        public long? ToNodeType { get; set; }

        /// <summary>
        /// 描述 :结束节点名称 
        /// </summary>
        public string ToNodeName { get; set; }

        /// <summary>
        /// 描述 :转化状态 
        /// </summary>
        [Required(ErrorMessage = "转化状态不能为空")]
        public long TransitionSate { get; set; }

        /// <summary>
        /// 描述 :是否结束 
        /// </summary>
        [Required(ErrorMessage = "是否结束不能为空")]
        public long IsFinish { get; set; }

        /// <summary>
        /// 描述 :ReMark 
        /// </summary>
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 :创建用户 
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :转化时间 
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