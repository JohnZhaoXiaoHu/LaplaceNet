using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System
{
    /// <summary>
    /// 角色部门
    /// </summary>
    [SqlSugar.SugarTable("sys_role_dept")]
    [SqlSugar.Tenant(0)]
    public class SysRoleDept
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
