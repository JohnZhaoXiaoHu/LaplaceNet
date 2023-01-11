﻿using System;
using System.Collections.Generic;
using System.Text;
using La.Model.System;

namespace La.Model.System.Dto
{
    public class SysUserOnlineDto : SysBase
    {
        public int pageNum { get; set; }
        /// <summary>
        /// IP 地址
        /// </summary>
        public string Ipaddr { get; set; }
        /// <summary>
        /// 登录状态 0成功 1失败
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

    }
}
