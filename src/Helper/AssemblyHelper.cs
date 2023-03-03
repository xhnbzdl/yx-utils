using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yx.Utils.Helper
{
    /// <summary>
    /// 程序集帮助类
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// 按名称获取当前项目中的程序集
        /// </summary>
        /// <param name="allAssemblyFilesSearchPattern">程序集名称，支持通配符，如“TemplateSystem.*.dll”</param>
        /// <returns></returns>
        public static Assembly[] GetCurrentProjectAssembly(string allAssemblyFilesSearchPattern)
        {
            // 获取文件名 xxx.dll
            string[] allAssemblyFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, allAssemblyFilesSearchPattern);
            Assembly[] assemblys = new Assembly[allAssemblyFiles.Length];
            for (int i = 0; i < allAssemblyFiles.Length; i++)
            {
                // 加载指定路径的程序集
                assemblys[i] = Assembly.LoadFrom(allAssemblyFiles[i]);
            }
            return assemblys;
        }
    }
}
