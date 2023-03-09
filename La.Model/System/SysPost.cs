using SqlSugar;

namespace La.Model.System
{
    /// <summary>
    /// 岗位
    /// </summary>
    [SugarTable("sys_post")]
    [Tenant("0")]
    public class SysPost : SysBase
    {
        /// <summary>
        /// 岗位Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long PostId { get; set; }
        /// <summary>
        /// 岗位代码
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string PostName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int PostSort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
    }
}
