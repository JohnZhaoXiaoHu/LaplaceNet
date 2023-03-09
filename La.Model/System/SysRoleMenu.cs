using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    [SugarTable("sys_role_menu")]
    [Tenant("0")]
    public class SysRoleMenu
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [JsonProperty("roleId")]
        [SugarColumn(IsPrimaryKey = true)]
        public long Role_id { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        [JsonProperty("menuId")]
        [SugarColumn(IsPrimaryKey = true)]
        public long Menu_id { get; set; }
        /// <summary>
        /// 新建时间
        /// </summary>
        public DateTime Create_time { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Create_by { get; set; }
    }
}
