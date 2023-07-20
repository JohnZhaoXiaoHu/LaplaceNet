
namespace La.Model.Production
{
    /// <summary>
    /// oph从表
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [SugarTable("pp_output_slave")]
    public class PpOutputSlave
    {
        /// <summary>
        /// 描述 :ID 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int PosId { get; set; }

        /// <summary>
        /// 描述 :父GUID 
        /// 空值 :false 
        /// </summary>
        public string PomGuid { get; set; }

        /// <summary>
        /// 描述 :生产时段 
        /// 空值 :true 
        /// </summary>
        public string PosStartEndTime { get; set; }

        /// <summary>
        /// 描述 :实际产能 
        /// 空值 :false 
        /// </summary>
        public int PosRealOutput { get; set; }

        /// <summary>
        /// 描述 :停线时间 
        /// 空值 :false 
        /// </summary>
        public int PosLineStopTime { get; set; }

        /// <summary>
        /// 描述 :停线原因 
        /// 空值 :true 
        /// </summary>
        public string PosStopCause { get; set; }

        /// <summary>
        /// 描述 :停线说明 
        /// 空值 :true 
        /// </summary>
        public string PosStopMemo { get; set; }

        /// <summary>
        /// 描述 :未达成原因 
        /// 空值 :true 
        /// </summary>
        public string PosBadCause { get; set; }

        /// <summary>
        /// 描述 :未达成说明 
        /// 空值 :true 
        /// </summary>
        public string PosBadMemo { get; set; }

        /// <summary>
        /// 描述 :实际工数 
        /// 空值 :false 
        /// </summary>
        public int PosRealTime { get; set; }

        /// <summary>
        /// 描述 :实际工时 
        /// 空值 :false 
        /// </summary>
        public decimal PosRealWork { get; set; }

        /// <summary>
        /// 描述 :工时差异 
        /// 空值 :false 
        /// </summary>
        public decimal PosRealWorkDiff { get; set; }

        /// <summary>
        /// 描述 :产能差异 
        /// 空值 :false 
        /// </summary>
        public decimal PosRealOutputDiff { get; set; }

        /// <summary>
        /// 描述 :达成率 
        /// 空值 :false 
        /// </summary>
        public int PosAchRatio { get; set; }

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
        /// 描述 :说明 
        /// 空值 :true 
        /// </summary>
        public string Remark { get; set; }

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