using System;
using System.Collections.Generic;
using System.Text;

namespace La.WebApi.Hubs
{
    public class OnlineUsers
    {

        public OnlineUsers()
        {

        }
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
        public string? UserName { get; set; }
        public DateTime? LoginTime { get; set; }
        public string? Ipaddr { get; set; }
        public string? LoginLocation { get; set; }

        public string? Os { get; set; }
        public string? Browser { get; set; }


    }
}
