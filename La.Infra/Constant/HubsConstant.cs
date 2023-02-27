using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La.Infra.Constant
{
    /// <summary>
    /// 定义消息常量
    /// </summary>
    public class HubsConstant
    {
        /// <summary>
        /// 接收通知
        /// </summary>
        private const string V = "receiveNotice";
        /// <summary>
        /// 接收通知
        /// </summary>
        public static string ReceiveNotice = V;
        /// <summary>
        /// 在线数量
        /// </summary>
        public static string OnlineNum = "onlineNum";
        /// <summary>
        /// 更多通知
        /// </summary>
        public static string MoreNotice = "moreNotice";
        /// <summary>
        /// 在线用户
        /// </summary>
        public static string OnlineUser = "onlineUser";
    }
}
