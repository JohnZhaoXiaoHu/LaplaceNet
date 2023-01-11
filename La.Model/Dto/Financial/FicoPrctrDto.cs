using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 利润中心查询对象
    /// </summary>
    public class FicoPrctrQueryDto : PagerInfo 
    {
        public string FpPlnt { get; set; }
        public string FpCode { get; set; }
        public string FpName { get; set; }
        public string FpType { get; set; }
        public DateTime? BeginFpActDate { get; set; }
        public DateTime? EndFpActDate { get; set; }
    }

    /// <summary>
    /// 利润中心输入输出对象
    /// </summary>
    public class FicoPrctrDto
    {
        public long? FpId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        public string FpPlnt { get; set; }

        [Required(ErrorMessage = "代码不能为空")]
        public string FpCode { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        public string FpName { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        public string FpType { get; set; }

        [Required(ErrorMessage = "有效从不能为空")]
        public DateTime? FpActDate { get; set; }

        [Required(ErrorMessage = "有效到不能为空")]
        public DateTime? FpExpDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Remark { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }



    }
}