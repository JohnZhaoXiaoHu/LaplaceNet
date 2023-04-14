using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 从源设变，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    [SugarTable("pp_ec_slv_source")]
    public class PpEcSlvSource
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Guid { get; set; }

        /// <summary>
        /// 描述 :设变No. 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S001")]
        public string DSapZpabdS001 { get; set; }

        /// <summary>
        /// 描述 :完成品 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S002")]
        public string DSapZpabdS002 { get; set; }

        /// <summary>
        /// 描述 :上阶 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S003")]
        public string DSapZpabdS003 { get; set; }

        /// <summary>
        /// 描述 :旧物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S004")]
        public string DSapZpabdS004 { get; set; }

        /// <summary>
        /// 描述 :品名 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S005")]
        public string DSapZpabdS005 { get; set; }

        /// <summary>
        /// 描述 :数量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S006")]
        public decimal DSapZpabdS006 { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S007")]
        public string DSapZpabdS007 { get; set; }

        /// <summary>
        /// 描述 :新物料 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S008")]
        public string DSapZpabdS008 { get; set; }

        /// <summary>
        /// 描述 :品名 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S009")]
        public string DSapZpabdS009 { get; set; }

        /// <summary>
        /// 描述 :数量 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S010")]
        public decimal DSapZpabdS010 { get; set; }

        /// <summary>
        /// 描述 :位置 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S011")]
        public string DSapZpabdS011 { get; set; }

        /// <summary>
        /// 描述 :BOM番号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S012")]
        public string DSapZpabdS012 { get; set; }

        /// <summary>
        /// 描述 :互换性 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S013")]
        public string DSapZpabdS013 { get; set; }

        /// <summary>
        /// 描述 :区分 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S014")]
        public string DSapZpabdS014 { get; set; }

        /// <summary>
        /// 描述 :安排指示 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S015")]
        public string DSapZpabdS015 { get; set; }

        /// <summary>
        /// 描述 :旧品处理 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S016")]
        public string DSapZpabdS016 { get; set; }

        /// <summary>
        /// 描述 :BOM生效 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_S017")]
        public DateTime? DSapZpabdS017 { get; set; }

        /// <summary>
        /// 描述 :处理标记 
        /// 空值 :false 
        /// </summary>
        public byte IsSolved { get; set; }

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
        /// 描述 :CreateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }




    }
}