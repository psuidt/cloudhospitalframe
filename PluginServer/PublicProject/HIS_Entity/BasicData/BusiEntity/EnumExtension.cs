using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace HIS_Entity.BasicData.BusiEntity
{
    public static class EnumExtension
    {
        private static Dictionary<string, Dictionary<string, string>> enumCache;
         
        private static Dictionary<string, Dictionary<string, string>> EnumCache
        {
            get
            {
                if (enumCache == null)
                {
                    enumCache = new Dictionary<string, Dictionary<string, string>>();
                }
                return enumCache;
            }
            set { enumCache = value; }
        }

        /// <summary>
        /// 获取枚举的中文名称
        /// </summary>
        /// <param name="en">枚举</param>
        /// <returns></returns>
        public static string GetEnumDisplay(this Enum en)
        {
            string enString = string.Empty;
            if (null == en) return enString;
            var type = en.GetType();
            enString = en.ToString();
            if (!EnumCache.ContainsKey(type.FullName))
            {
                var fields = type.GetFields();
                Dictionary<string, string> temp = new Dictionary<string, string>();
                foreach (var item in fields)
                {
                    var display = item.GetCustomAttributes(typeof(DisplayAttribute),false);
                    if (display != null && display.Any())
                    {
                        DisplayAttribute v = display.FirstOrDefault() as DisplayAttribute;
                        temp.Add(item.Name, v.Name);
                    }
                }
                EnumCache.Add(type.FullName, temp);
            }
            if (EnumCache[type.FullName].ContainsKey(enString))
            {
                return EnumCache[type.FullName][enString];
            }
            return enString;
        }

        /// <summary>
        /// 将整型转换为枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="val">整型值</param>
        /// <param name="defaultvalue">无法转换时返回默认值</param>
        /// <returns>枚举T</returns>
        public static T ToEnum<T>(this int val, T defaultvalue) where T : struct
        {
            Type enumType = typeof(T);

            if (!enumType.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            if (Enum.IsDefined(enumType, val))
            {
                return (T)Enum.ToObject(enumType, val);
            }
            return defaultvalue;
        }
    }
}
