using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace La.Model.System
{
    /// <summary>
    /// 登录用户信息存储
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// 用户iD
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public long DeptId { get; set; }
        /// <summary>
        /// 用户史
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 角色集合
        /// </summary>
        public List<string> RoleIds { get; set; }
        /// <summary>
        /// 角色集合(数据权限过滤使用)
        /// </summary>
        public List<SysRole> Roles { get; set; }
        /// <summary>
        /// 权限集合
        /// </summary>
        public List<string> Permissions { get; set; } = new List<string>();
        /// <summary>
        /// 登录用户信息存储
        /// </summary>
        public LoginUser()
        {
        }
        /// <summary>
        /// 登录用户信息存储
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <param name="permissions"></param>

        public LoginUser(SysUser user, List<SysRole> roles, List<string> permissions)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            DeptId = user.DeptId;
            Roles = roles;
            RoleIds = roles.Select(f => f.RoleKey).ToList();
            Permissions = permissions;
        }
    }
}
