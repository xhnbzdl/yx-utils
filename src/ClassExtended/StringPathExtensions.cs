using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yx.Utils.ClassExtended
{
    /// <summary>
    /// 当字符串为路径时使用
    /// </summary>
    public static class StringPathExtensions
    {
        public static UTF8Encoding UTF8Encoding { get; } = new UTF8Encoding(false);

        /// <summary>
        /// 读取文件的所有内容
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string Read(this string path)
        {
            return File.ReadAllText(path, UTF8Encoding);
        }

        /// <summary>
        /// 读取所有行
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] ReadLines(this string path)
        {
            return File.ReadAllLines(path, UTF8Encoding);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void Save(this string path, string content)
        {
            var dir = Path.GetDirectoryName(path);
            dir.CreateIfNotExist();

            File.WriteAllText(path, content, UTF8Encoding);
        }

        /// <summary>
        /// 保存json文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contentObj"></param>
        public static void SaveJson(this string path, object contentObj)
        {
            var content = JsonConvert.SerializeObject(contentObj, Formatting.Indented);
            path.Save(content);
        }

        /// <summary>
        /// 如果目录不存在，那么创建目录
        /// </summary>
        /// <param name="path"></param>
        public static void CreateIfNotExist(this string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        /// <summary>
        /// 获取filePath对flagPath的相对路径
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="flagPath"></param>
        /// <returns></returns>
        public static string GetRelativePath(this string filePath, string flagPath)
        {
            var filePathUri = new Uri(filePath);
            var flagPathUri = new Uri(flagPath);
            return flagPathUri.MakeRelativeUri(filePathUri).ToString();
        }
    }
}
