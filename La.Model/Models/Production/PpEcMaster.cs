using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 主设变信息表，数据实体对象
    ///
    /// @author Laplace.Net:Davis.Cheng
    /// @date 2023-02-24
    /// </summary>
    [SugarTable("pp_ec_master")]
    public class PpEcMaster
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int EmId { get; set; }

        /// <summary>
        /// 描述 :发行日 
        /// 空值 :false 
        /// </summary>
        public DateTime? EmEcIssueDate { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// 空值 :false 
        /// </summary>
        public string EmEcNo { get; set; }

        /// <summary>
        /// 描述 :关联文件 
        /// 空值 :true 
        /// </summary>
        public string EmEcDoc { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :false 
        /// </summary>
        public string EmEcStatus { get; set; }

        /// <summary>
        /// 描述 :标题 
        /// 空值 :false 
        /// </summary>
        public string EmEcTitle { get; set; }

        /// <summary>
        /// 描述 :内容 
        /// 空值 :false 
        /// </summary>
        public string EmEcContent { get; set; }

        /// <summary>
        /// 描述 :担当 
        /// 空值 :false 
        /// </summary>
        public string EmEcAssigned { get; set; }

        /// <summary>
        /// 描述 :损失金额 
        /// 空值 :false 
        /// </summary>
        public decimal EmEcLossAmount { get; set; }

        /// <summary>
        /// 描述 :管理区分 
        /// 空值 :false 
        /// </summary>
        public int EmEcManageCategory { get; set; }

        /// <summary>
        /// 描述 :联络No. 
        /// 空值 :true 
        /// </summary>
        public string EmEcLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :联络文件 
        /// 空值 :true 
        /// </summary>
        public string EmEcLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :EppNo. 
        /// 空值 :true 
        /// </summary>
        public string EmEcEppLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :Epp文件 
        /// 空值 :true 
        /// </summary>
        public string EmEcEppLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :FppNo. 
        /// 空值 :true 
        /// </summary>
        public string EmEcFppLiaisonNo { get; set; }

        /// <summary>
        /// 描述 :Fpp文件 
        /// 空值 :true 
        /// </summary>
        public string EmEcFppLiaisonDoc { get; set; }

        /// <summary>
        /// 描述 :外部No. 
        /// 空值 :true 
        /// </summary>
        public string EmEcExternalNo { get; set; }

        /// <summary>
        /// 描述 :外部文件 
        /// 空值 :true 
        /// </summary>
        public string EmEcExternalDoc { get; set; }

        /// <summary>
        /// 描述 :实施部门 
        /// 空值 :false 
        /// </summary>
        public string EmEcImpDept { get; set; }

        /// <summary>
        /// 描述 :输入日 
        /// 空值 :false 
        /// </summary>
        public DateTime? EmEcEntryDate { get; set; }

        /// <summary>
        /// 描述 :SOP变更否 
        /// 空值 :false 
        /// </summary>
        public bool IsModifySop { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :备注 
        /// 空值 :true 
        /// </summary>
        public string ReMark { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 : 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}