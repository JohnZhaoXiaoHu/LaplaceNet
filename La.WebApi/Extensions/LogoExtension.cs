using JinianNet.JNTemplate;
using Microsoft.Extensions.DependencyInjection;
using System;
using La.Common;

namespace La.WebApi.Extensions
{
    public static class LogoExtension
    {
        public static void AddLogo(this IServiceCollection services)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var contentTpl = JnHelper.ReadTemplate("", "logo.txt");
            var content = contentTpl?.Render();

            Console.WriteLine(content);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("源码地址: https://gitee.com/Lean365/LaplaceNET");
            Console.WriteLine("官方文档：http://www.Lean365.cn/doc");
            Console.WriteLine("打赏作者：http://www.Lean365.cn/doc/support.html");
        }
    }
}
