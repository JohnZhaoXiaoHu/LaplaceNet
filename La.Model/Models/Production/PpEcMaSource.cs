using System;
using SqlSugar;
using System.Collections.Generic;

namespace La.Model.Models
{
    /// <summary>
    /// 主源设变，数据实体对象
    ///
    /// @author Davis.Cheng
    /// @date 2023-04-13
    /// </summary>
    [SugarTable("pp_ec_ma_source")]
    public class PpEcMaSource
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
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z001")]
        public string DSapZpabdZ001 { get; set; }

        /// <summary>
        /// 描述 :机种 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z002")]
        public string DSapZpabdZ002 { get; set; }

        /// <summary>
        /// 描述 :标题 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z003")]
        public string DSapZpabdZ003 { get; set; }

        /// <summary>
        /// 描述 :状态 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z004")]
        public string DSapZpabdZ004 { get; set; }

        /// <summary>
        /// 描述 :发行日 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z005")]
        public DateTime? DSapZpabdZ005 { get; set; }

        /// <summary>
        /// 描述 :担当 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z006")]
        public string DSapZpabdZ006 { get; set; }

        /// <summary>
        /// 描述 :依赖 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z007")]
        public string DSapZpabdZ007 { get; set; }

        /// <summary>
        /// 描述 :会议 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z008")]
        public string DSapZpabdZ008 { get; set; }

        /// <summary>
        /// 描述 :PP番号 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z009")]
        public string DSapZpabdZ009 { get; set; }

        /// <summary>
        /// 描述 :联络书 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z010")]
        public string DSapZpabdZ010 { get; set; }

        /// <summary>
        /// 描述 :实施 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z011")]
        public string DSapZpabdZ011 { get; set; }

        /// <summary>
        /// 描述 :主理由 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z012")]
        public string DSapZpabdZ012 { get; set; }

        /// <summary>
        /// 描述 :次理由 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z013")]
        public string DSapZpabdZ013 { get; set; }

        /// <summary>
        /// 描述 :安规 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z014")]
        public string DSapZpabdZ014 { get; set; }

        /// <summary>
        /// 描述 :状况 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z015")]
        public string DSapZpabdZ015 { get; set; }

        /// <summary>
        /// 描述 :机番 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z016")]
        public string DSapZpabdZ016 { get; set; }

        /// <summary>
        /// 描述 :承认 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z017")]
        public string DSapZpabdZ017 { get; set; }

        /// <summary>
        /// 描述 :服务手册订正 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z018")]
        public string DSapZpabdZ018 { get; set; }

        /// <summary>
        /// 描述 :用户手册订正 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z019")]
        public string DSapZpabdZ019 { get; set; }

        /// <summary>
        /// 描述 :宣传手册订正 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z020")]
        public string DSapZpabdZ020 { get; set; }

        /// <summary>
        /// 描述 :SOP订正 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z021")]
        public string DSapZpabdZ021 { get; set; }

        /// <summary>
        /// 描述 :信息发行 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z022")]
        public string DSapZpabdZ022 { get; set; }

        /// <summary>
        /// 描述 :成本变动 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z023")]
        public string DSapZpabdZ023 { get; set; }

        /// <summary>
        /// 描述 :单位成本 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z024")]
        public string DSapZpabdZ024 { get; set; }

        /// <summary>
        /// 描述 :模具改造费 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z025")]
        public string DSapZpabdZ025 { get; set; }

        /// <summary>
        /// 描述 :图纸 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z026")]
        public string DSapZpabdZ026 { get; set; }

        /// <summary>
        /// 描述 :设变内容 
        /// 空值 :true 
        /// </summary>
        [SugarColumn(ColumnName = "d_SAP_ZPABD_Z027")]
        public string DSapZpabdZ027 { get; set; }

        /// <summary>
        /// 描述 :处理标记 
        /// 空值 :false 
        /// </summary>
        public byte IsSolved { get; set; }

        /// <summary>
        /// 描述 :IsDeleted 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :ReMark 
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