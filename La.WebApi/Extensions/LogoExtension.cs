using JinianNet.JNTemplate;
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("源码地址: https://github.com/Lean365/LaplaceNet");
            Console.WriteLine("官方文档：https://laplacenet.github.io/");
            Console.WriteLine("打赏作者：https://laplacenet.github.io/docs/others/donate.html");
        }
    }
}
