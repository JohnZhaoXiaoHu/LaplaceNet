using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La.Generator
{
    /// <summary>
    /// 生成代码删除类
    /// </summary>
    public class GenDeleteClass
    {
        public static void DelectDir(string srcPath,string srcFileName)
        {
            //string[] files = Directory.GetFiles(filepath + @"\", "*.xls");
            //string[] files = Directory.GetFiles(filepath + @"\", filename);  //查找时不包括子目录
            try
            {
                string[] files = Directory.GetFiles(srcPath + @"\", "*" + srcFileName + "*.*", SearchOption.AllDirectories);   //查找时包括子目录
                foreach (string delFile in files)
                {
                    File.Delete(delFile); //删除指定文件
                }



            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
