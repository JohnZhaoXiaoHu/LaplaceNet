﻿using SqlSugar;
using System;

namespace La.Model.System
{
    /// <summary>
    /// sys_logininfor 表
    /// </summary>
    [SugarTable("sys_logininfor", "登录日志表")]
    [Tenant("0")]
    public class SysLogininfor
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long InfoId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录状态 0成功 1失败
        /// </summary>
        [SugarColumn(Length = 1, DefaultValue = "0")]
        public int Status { get; set; }

        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string Ipaddr { get; set; } = string.Empty;

        /// <summary>
        /// 登录地点
        /// </summary>
        public string LoginLocation { get; set; } = string.Empty;

        /// <summary>
        /// 浏览器类型
        /// </summary>
        public string Browser { get; set; } = string.Empty;

        /// <summary>
        /// 操作系统
        /// </summary>
        public string Os { get; set; } = string.Empty;

        /// <summary>
        /// 提示消息
        /// </summary>
        public string Msg { get; set; } = string.Empty;

        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime LoginTime { get; set; } = DateTime.Now;
        [SugarColumn(IsIgnore = true)]
        public DateTime? BeginTime { get; set; }
        [SugarColumn(IsIgnore = true)]
        public DateTime? EndTime { get; set; }
    }
}
