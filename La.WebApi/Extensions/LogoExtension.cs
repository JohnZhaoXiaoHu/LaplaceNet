using JinianNet.JNTemplate;
using Microsoft.Extensions.DependencyInjection;
using System;
using La.Common;
using La.Infra;
namespace La.WebApi.Extensions
{
    public static class LogoExtension
    {
        public static void AddLogo(this IServiceCollection services)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var contentTpl = JnHelper.ReadTemplate("", "logo.txt");
            var content = contentTpl?.Render();
            //var github = HttpHelper.HttpGet("https://api.github.com/repos/Lean365/LaplaceNet/releases");
            Console.WriteLine(content);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("swagger: http://localhost:8888/swagger/index.html");
            Console.WriteLine("源码地址: https://github.com/Lean365/LaplaceNet");
            Console.WriteLine("官方文档：https://laplacenet.github.io/");
            Console.WriteLine("打赏作者：https://laplacenet.github.io/docs/others/donate.html");
            //Console.WriteLine("打赏作者："+ github);

        }
    }
}
