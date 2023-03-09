using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace La.Model.System
{
    /// <summary>
    /// 角色部门
    /// </summary>
    [SugarTable("sys_role_post")]
    [Tenant("0")]
    public class SysRolePost
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public long DeptId { get; set; }
    }
}
