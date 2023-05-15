﻿using SqlSugar;

namespace La.Model.System
{
    /// <summary>
    /// 用户岗位
    /// </summary>
    [SugarTable("sys_user_post")]
    [Tenant("0")]
    public class SysUserPost
    {
        public long UserId { get; set; }
        public long PostId { get; set; }
    }
}
