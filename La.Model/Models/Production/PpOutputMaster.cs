
namespace La.Model.Production
{
    /// <summary>
    /// oph主表
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [SugarTable("pp_output_master")]
    public class PpOutputMaster
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int PomId { get; set; }

        /// <summary>
        /// 描述 :GUID 
        /// 空值 :false 
        /// </summary>
        public string PomGuid { get; set; }

        /// <summary>
        /// 描述 :生产工单 
        /// 空值 :false 
        /// </summary>
        public string PomOrder { get; set; }

        /// <summary>
        /// 描述 :工单数量 
        /// 空值 :false 
        /// </summary>
        public decimal PomOrderQty { get; set; }

        /// <summary>
        /// 描述 :管理序列号 
        /// 空值 :false 
        /// </summary>
        public string PomOrderSerial { get; set; }

        /// <summary>
        /// 描述 :生产批次 
        /// 空值 :false 
        /// </summary>
        public string PomMflot { get; set; }

        /// <summary>
        /// 描述 :机种名 
        /// 空值 :false 
        /// </summary>
        public string PomModelName { get; set; }

        /// <summary>
        /// 描述 :物料 
        /// 空值 :false 
        /// </summary>
        public string PomMfItem { get; set; }

        /// <summary>
        /// 描述 :生产日期 
        /// 空值 :false 
        /// </summary>
        public DateTime? PomMfDate { get; set; }

        /// <summary>
        /// 描述 :生产班组 
        /// 空值 :false 
        /// </summary>
        public string PomLineName { get; set; }

        /// <summary>
        /// 描述 :直接人数 
        /// 空值 :false 
        /// </summary>
        public int PomDirect { get; set; }

        /// <summary>
        /// 描述 :间接人数 
        /// 空值 :false 
        /// </summary>
        public int PomIndirect { get; set; }

        /// <summary>
        /// 描述 :标准工时 
        /// 空值 :false 
        /// </summary>
        public decimal PomStdTime { get; set; }

        /// <summary>
        /// 描述 :标准产能 
        /// 空值 :false 
        /// </summary>
        public decimal PomStdOutput { get; set; }

        /// <summary>
        /// 描述 :UDF01 
        /// 空值 :true 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 描述 :UDF02 
        /// 空值 :true 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 描述 :UDF03 
        /// 空值 :true 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 描述 :UDF04 
        /// 空值 :true 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 描述 :UDF05 
        /// 空值 :true 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 描述 :UDF06 
        /// 空值 :true 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 描述 :UDF51 
        /// 空值 :true 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 描述 :UDF52 
        /// 空值 :true 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 描述 :UDF53 
        /// 空值 :true 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 描述 :UDF54 
        /// 空值 :true 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 描述 :UDF55 
        /// 空值 :true 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 描述 :UDF56 
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