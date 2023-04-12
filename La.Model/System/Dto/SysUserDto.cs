using System;
using System.Collections.Generic;
using System.Text;
using La.Model.System;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 用户输入输出
    /// </summary>
    public class SysUserDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phonenumber { get; set; }
        /// <summary>
        /// '用户性别（0男 1女 2未知）',
        /// </summary>
        public int Sex { get; set; }
    }
}
