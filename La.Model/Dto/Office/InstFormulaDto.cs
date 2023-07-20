using System.ComponentModel.DataAnnotations;
using MiniExcelLibs.Attributes;

namespace La.Model.Dto
{
    /// <summary>
    /// 计算公式
    /// 查询对象
    /// @author Lean365
    /// @date 2023-07-20
    /// </summary>
    public class InstFormulaQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 计算公式
    /// 输入输出对象
    /// </summary>
    public class InstFormulaDto
    {
        /// <summary>
        /// 描述 :Guid 
        /// </summary>
        [Required(ErrorMessage = "Guid不能为空")]
        [ExcelIgnore]
        public string IfGuid { get; set; }

        /// <summary>
        /// 描述 :类别 
        /// </summary>
        [Required(ErrorMessage = "类别不能为空")]

        [ExcelColumn(Name = "类别")]
        public string IfType { get; set; }

        /// <summary>
        /// 描述 :语言 
        /// </summary>
        [Required(ErrorMessage = "语言不能为空")]

        [ExcelColumn(Name = "语言")]
        public string IfLangKey { get; set; }

        /// <summary>
        /// 描述 :公式 
        /// </summary>
        [Required(ErrorMessage = "公式不能为空")]

        [ExcelColumn(Name = "公式")]
        public string IfFormula { get; set; }

        /// <summary>
        /// 描述 :软删除 
        /// </summary>
        [ExcelIgnore]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 描述 :Remark 
        /// </summary>
        [ExcelIgnore]
        public string Remark { get; set; }

        /// <summary>
        /// 描述 :CreateBy 
        /// </summary>
        [ExcelIgnore]
        public string CreateBy { get; set; }

        /// <summary>
        /// 描述 :CreateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 描述 :UpdateBy 
        /// </summary>
        [ExcelIgnore]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 描述 :UpdateTime 
        /// </summary>
        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }
}