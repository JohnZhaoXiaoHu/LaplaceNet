using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model.System.Vo
{
    /// <summary>
    /// 路由展示
    /// </summary>
    public class RouterVo
    {
        /// <summary>
        /// 当你一个路由下面的 children 声明的路由大于1个时，自动会变成嵌套的模式--如组件页面
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool AlwaysShow { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        private string component;
        /// <summary>
        /// 隐藏
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Hidden { get; set; }
        /// <summary>
        /// // 设定路由的名字，一定要填写不然使用keep-alive时会出现各种问题
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 重定向 // 当设置 noRedirect 的时候该路由在面包屑导航中不可被点击
        /// </summary>
        public string Redirect { get; set; }
        /// <summary>
        /// Meta标签
        /// </summary>
        public Meta Meta { get; set; }
        /// <summary>
        /// Children子项
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<RouterVo> Children { get; set; }
        /// <summary>
        /// Component组件
        /// </summary>
        public string Component { get => component; set => component = value; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// 设置该路由在侧边栏和面包屑中展示的名字
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 设置该路由的图标，对应路径src/assets/icons/svg
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 设置为true，则不会被 keep-alive缓存
        /// </summary>
        public bool NoCache { get; set; }
        /// <summary>
        /// 国际和翻译key值，如果不为空将使用i18n
        /// </summary>
        public string TitleKey { get; set; } = string.Empty;
        /// <summary>
        /// 连接
        /// </summary>
        public string Link { get; set; } = string.Empty;
        /// <summary>
        /// Meta
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>

        public Meta(string title, string icon)
        {
            Title = title;
            Icon = icon;
        }
        /// <summary>
        /// Meta
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="path"></param>
        public Meta(string title, string icon, string path)
        {
            Title = title;
            Icon = icon;
            Link = path;
        }
        /// <summary>
        /// Meta
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="noCache"></param>
        /// <param name="titleKey"></param>
        /// <param name="path"></param>
        public Meta(string title, string icon, bool noCache, string titleKey, string path)
        {
            Title = title;
            Icon = icon;
            NoCache = noCache;
            TitleKey = titleKey;
            if (!string.IsNullOrEmpty(path) && (path.StartsWith(UserConstants.HTTP) || path.StartsWith(UserConstants.HTTPS)))
            {
                Link = path;
            }
        }
    }
}
