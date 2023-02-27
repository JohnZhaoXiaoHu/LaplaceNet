using System;

namespace La.Infra
{
    /// <summary>
    /// 自定义异常
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// 代码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 日志消息
        /// </summary>
        public string LogMsg { get; set; }
        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="msg"></param>

        public CustomException(string msg) : base(msg)
        {
        }
        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public CustomException(int code, string msg) : base(msg)
        {
            Code = code;
            Msg = msg;
        }
        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="msg"></param>
        public CustomException(ResultCode resultCode, string msg) : base(msg)
        {
            Code = (int)resultCode;
        }

        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="msg"></param>
        /// <param name="errorMsg">用于记录详细日志到输出介质</param>
        public CustomException(ResultCode resultCode, string msg, object errorMsg) : base(msg)
        {
            Code = (int)resultCode;
            LogMsg = errorMsg.ToString();
        }
    }
}