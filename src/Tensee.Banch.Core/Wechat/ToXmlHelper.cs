using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tensee.Banch
{
    public  class ToDicHelper
    {
        /// <summary>
        /// 获取排序后的属性和属性值 （只能获取第一级的基本类型）
        /// </summary>
        /// <param name="obj">目标对象</param>
        /// <returns></returns>
        public static SortedDictionary<string, string> GetPropertiesFromObj(object obj)
        {
            SortedDictionary<string, string> sParams = new SortedDictionary<string, string>();
            PropertyInfo[] properties = obj.GetType().GetProperties();
            Type[] types = new Type[] { typeof(int), typeof(string), typeof(double), typeof(decimal), typeof(decimal?) };
            foreach (PropertyInfo property in properties)
            {
                if (types.Contains(property.PropertyType))//基本类型ToString
                {
                    string value = property.GetValue(obj)?.ToString();
                    if (!string.IsNullOrWhiteSpace(value))//空值不加入字典
                    {
                        sParams.Add(property.Name, value);
                    }
                }
            }
            return sParams;
            
        }
    }
}
