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
            //Console.Write(new string(' ', (Console.WindowWidth - content.Length) / 2));
            Console.WriteLine(content);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string LaAuthor = "Author: Davis.Cheng";
            Console.Write(new string(' ', (Console.WindowWidth - LaAuthor.Length) / 2));
            Console.WriteLine(LaAuthor);
            string LaDate = "Date:" + DateTime.Now.ToString("yyyy-MM-dd");
            Console.Write(new string(' ', (Console.WindowWidth - LaDate.Length) / 2));
            Console.WriteLine(LaDate);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("SwaggerDoc: La.WebApi.xml");
            Console.WriteLine("源码地址: https://github.com/Lean365/LaplaceNet");
            Console.WriteLine("官方文档：https://laplacenet.github.io/");
            Console.WriteLine("打赏作者：https://laplacenet.github.io/docs/others/donate.html");
            //Console.WriteLine("打赏作者："+ github);
        }
    }
}
