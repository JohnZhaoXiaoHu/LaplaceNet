using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using La.Model.Dto;
using La.Model.Models;

namespace La.Model.Dto
{
    /// <summary>
    /// 部门消耗查询对象
    /// </summary>
    public class FicoDeptConsumingQueryDto : PagerInfo 
    {
        public string DcFy { get; set; }
        public string DcYm { get; set; }
        public string DcCorpCode { get; set; }
        public string DcPlant { get; set; }
        public string DcMateriel { get; set; }
    }

    /// <summary>
    /// 部门消耗输入输出对象
    /// </summary>
    public class FicoDeptConsumingDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        public long DcId { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        public string DcFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        public string DcYm { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        public string DcCorpCode { get; set; }

        [Required(ErrorMessage = "公司名称不能为空")]
        public string DcCorpName { get; set; }

        [Required(ErrorMessage = "统计类别不能为空")]
        public string DcExpCategory { get; set; }

        [Required(ErrorMessage = "成本代码不能为空")]
        public string DcCostCode { get; set; }

        [Required(ErrorMessage = "成本名称不能为空")]
        public string DcCostName { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        public string DcTitleCode { get; set; }

        [Required(ErrorMessage = "科目名称不能为空")]
        public string DcTitleName { get; set; }

        [Required(ErrorMessage = "科目分类不能为空")]
        public string DcTitleNote { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        public decimal DcBudgetAmt { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        public decimal DcActualAmt { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        public decimal DcDiffAmt { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        public string DcPlant { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        public string DcMateriel { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        public string DcStorageLocation { get; set; }

        [Required(ErrorMessage = "移动类型不能为空")]
        public string DcMoveType { get; set; }

        [Required(ErrorMessage = "物料凭证不能为空")]
        public string DcMaterielDoc { get; set; }

        [Required(ErrorMessage = "凭证明细不能为空")]
        public string DcMaterielDocDetails { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        public decimal DcUseQty { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        public decimal DcUseAmt { get; set; }

        [Required(ErrorMessage = "预留单不能为空")]
        public string DcReserveDoc { get; set; }

        [Required(ErrorMessage = "预留明细不能为空")]
        public string DcAccountant { get; set; }

        [Required(ErrorMessage = "登录日期不能为空")]
        public DateTime? DcBalanceDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Remark { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }



    }
}