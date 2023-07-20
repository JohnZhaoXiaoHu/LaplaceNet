﻿namespace La.Model.System.Dto
{
    public class SysLogininfoDto : SysBase
    {
        public int PageNum { get; set; }
        /// <summary>
        /// IP 地址
        /// </summary>
        public string Ipaddr { get; set; }
        /// <summary>
        /// 登录状态 0成功 1失败
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

    }
}
