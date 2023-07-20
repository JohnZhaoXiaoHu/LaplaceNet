
namespace La.Model.Office
{
    /// <summary>
    /// 计算公式
    /// 数据实体对象
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    [SugarTable("inst_formula")]
    public class InstFormula
    {
        /// <summary>
        /// 描述 :Guid 
        /// 空值 :false 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string IfGuid { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// 空值 :false 
        /// </summary>
        public string IfType { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// 空值 :false 
        /// </summary>
        public string IfLangKey { get; set; }

        /// <summary>
        /// 描述 :公式 
        /// 空值 :false 
        /// </summary>
        public string IfFormula { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// 空值 :true 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :Remark 
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