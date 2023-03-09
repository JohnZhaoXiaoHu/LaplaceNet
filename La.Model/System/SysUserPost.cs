using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace La.Model.System
{
 
    /// <summary>
    /// 用户岗位
    /// </summary>
    [SugarTable("sys_user_post")]
    [Tenant("0")]
    public class SysUserPost
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 岗位ID
        /// </summary>
        public long PostId { get; set; }
    }
}
