using System;
using System.Collections.Generic;

namespace Yx.Utils.ClassExtended
{
    /// <summary>
    /// 字典扩展类
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// 获取字典中存在的值
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="dictionary">集合对象</param>
        /// <param name="key">Key</param>
        /// <param name="value">键的值(如果键不存在则为默认值)</param>
        /// <returns>如果key在字典中存在，则为True</returns>
        internal static bool TryGetValue<T>(this IDictionary<string, object> dictionary, string key, out T value)
        {
            object valueObj;
            if (dictionary.TryGetValue(key, out valueObj) && valueObj is T)
            {
                value = (T)valueObj;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// 获取字典中存在的值，如果找不到则返回默认值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue obj;
            return dictionary.TryGetValue(key, out obj) ? obj : default;
        }

        /// <summary>
        /// 获取字典中存在的值，如果找不到则返回默认值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="factory">如果在字典中找不到该值，则用于创建该值的工厂方法</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory)
        {
            TValue obj;
            if (dictionary.TryGetValue(key, out obj))
            {
                return obj;
            }

            return dictionary[key] = factory(key);
        }

        /// <summary>
        /// 获取字典中存在的值，如果找不到则返回默认值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="factory">如果在字典中找不到该值，则用于创建该值的工厂方法</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory)
        {
            return dictionary.GetOrAdd(key, k => factory());
        }
    }
}