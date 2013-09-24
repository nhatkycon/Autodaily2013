using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace linh.common
{
    /// <summary>
    /// Represents a GigaCache
    /// </summary>
    public class myCache
    {
        #region Fields
        private static readonly Cache _cache;
        #endregion

        #region Ctor
        /// <summary>
        /// Creates a new instance of the NopCache class
        /// </summary>
        static myCache()
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                _cache = current.Cache;
            }
            else
            {
                _cache = HttpRuntime.Cache;
            }
        }

        /// <summary>
        /// Creates a new instance of the NopCache class
        /// </summary>
        private myCache()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Removes all keys and values from the cache
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                _cache.Remove(enumerator.Key.ToString());
            }
        }
        public static IDictionaryEnumerator GetAll()
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            return enumerator;
        }
        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public static object Get(string key)
        {
            return _cache[key];
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">object</param>
        public static void Max(string key, object obj)
        {
            Max(key, obj, null);
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="obj">object</param>
        /// <param name="dep">cache dependency</param>
        public static void Max(string key, object obj, CacheDependency dep)
        {
            if (IsEnabled && (obj != null))
            {
                //_cache.Insert(key, obj, dep, DateTime.Now.AddMinutes(20), TimeSpan.FromMinutes(10), CacheItemPriority.High,null);
                _cache.Insert(key, obj, dep, DateTime.MaxValue, TimeSpan.FromMinutes(20));
            }
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        public static void RemoveByPattern(string pattern)
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(enumerator.Key.ToString()))
                {
                    _cache.Remove(enumerator.Key.ToString());
                }
            }
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the cache is enabled
        /// </summary>
        public static bool IsEnabled
        {
            get
            {
                return myCache.IsCachable;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether the context is cachable
        /// </summary>
        public static bool IsCachable
        {
            get
            {
                return true;
            }
        }
        #endregion
    }
}
