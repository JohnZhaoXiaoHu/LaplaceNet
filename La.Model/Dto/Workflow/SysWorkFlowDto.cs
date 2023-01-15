using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 工作流查询对象
    /// </summary>
    public class SysWorkFlowQueryDto : PagerInfo 
    {
        public string WorkName { get; set; }
        public string WorkTable { get; set; }
        public DateTime? BeginCreateTime { get; set; }
        public DateTime? EndCreateTime { get; set; }
    }

    /// <summary>
    /// 工作流输入输出对象
    /// </summary>
    public class SysWorkFlowDto
    {
        [Required(ErrorMessage = "GUID不能为空")]
        public Guid WorkflowId { get; set; }

        [Required(ErrorMessage = "流程名称不能为空")]
        public string WorkName { get; set; }

        [Required(ErrorMessage = "表名不能为空")]
        public string WorkTable { get; set; }

        public string WorkTableName { get; set; }

        public string NodeConfig { get; set; }

        public string LineConfig { get; set; }

        public byte Enable { get; set; }

        public bool IsDeleted { get; set; }

        public string Remark { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }



    }
}