using System;
using System.Collections.Generic;
using System.Text;
using La.Model.System;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 角色输入对象
    /// </summary>
    public class SysRoleDto: SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public long RoleId { get; set; }
        /// <summary>
        /// 角色分配菜单
        /// </summary>
        public List<long> MenuIds { get; set; } = new List<long>();
        /// <summary>
        /// 名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        public string RoleKey { get; set; }
        /// <summary>
        /// 排序 
        /// </summary>
        public int RoleSort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
    }
}
