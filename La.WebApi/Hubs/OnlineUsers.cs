using System;
using System.Collections.Generic;
using System.Text;

namespace La.WebApi.Hubs
{
    /// <summary>
    /// 在线用户
    /// </summary>
    public class OnlineUsers
    {
        /// <summary>
        /// 在线用户
        /// </summary>
        public OnlineUsers()
        {

        }
        /// <summary>
        /// 在线用户
        /// </summary>
        /// <param name="connnectionId"></param>
        public OnlineUsers(string connnectionId)
        {
            this.ConnnectionId = connnectionId;
        }

        /// <summary>
        /// 客户端连接Id
        /// </summary>
        public string? ConnnectionId { get; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long? UserId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 登入时间
        /// </summary>
        public DateTime? LoginTime { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string? Ipaddr { get; set; }
        /// <summary>
        /// 登入位置
        /// </summary>
        public string? LoginLocation { get; set; }
        /// <summary>
        /// 系统
        /// </summary>

        public string? Os { get; set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string? Browser { get; set; }


    }
}
