using System.ComponentModel;

namespace La.Infra
{
    /// <summary>
    /// 定义结果码
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("success")]
        SUCCESS = 200,
        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("参数错误")]
        PARAM_ERROR = 101,
        /// <summary>
        /// 验证码错误
        /// </summary>
        [Description("验证码错误")]
        CAPTCHA_ERROR = 103,
        /// <summary>
        /// 登录错误
        /// </summary>
        [Description("登录错误")]
        LOGIN_ERROR = 105,
        /// <summary>
        /// 操作失败
        /// </summary>
        [Description("操作失败")]
        FAIL = 1,
        /// <summary>
        /// 服务端出错啦
        /// </summary>
        [Description("服务端出错啦")]
        GLOBAL_ERROR = 500,
        /// <summary>
        /// 自定义异常
        /// </summary>
        [Description("自定义异常")]
        CUSTOM_ERROR = 110,
        /// <summary>
        /// 非法请求
        /// </summary>
        [Description("非法请求")]
        INVALID_REQUEST = 116,
        /// <summary>
        /// 授权失败
        /// </summary>
        [Description("授权失败")]
        OAUTH_FAIL = 201,
        /// <summary>
        /// 未授权
        /// </summary>
        [Description("未授权")]
        DENY = 401,
        /// <summary>
        /// 授权访问失败
        /// </summary>
        [Description("授权访问失败")]
        FORBIDDEN = 403,
        /// <summary>
        /// 错误请求
        /// </summary>
        [Description("Bad Request")]
        BAD_REQUEST = 400
    }
}
