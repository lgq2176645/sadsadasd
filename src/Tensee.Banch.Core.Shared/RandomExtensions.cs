using System;
using System.Text;

namespace Tensee.Banch
{
    public static class RandomExtensions
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="random">Random</param>
        /// <param name="size">字符串长度</param>
        /// <param name="lowerCase">字符串是小写</param>
        /// <returns>随机字符串</returns>
        public static string NextString(this Random random, int size, bool lowerCase)
        {
            StringBuilder _builder = new StringBuilder(size);
            int _startChar = lowerCase ? 97 : 65;//65 = A / 97 = a
            for (int i = 0; i < size; i++)
                _builder.Append((char)(26 * random.NextDouble() + _startChar));
            return _builder.ToString();
        }
    }
}
