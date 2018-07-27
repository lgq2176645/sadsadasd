using System;

namespace Tensee.Banch
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 获取此时间的月初日期 如2018-3-14 返回 2018-3-1
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime GetStartInMonth(this DateTime source)
        {
            return source.AddDays(-source.Day + 1) - source.TimeOfDay;
        }
        /// <summary>
        /// 获取此时间的月末日期 如2018-3-14 返回2018-3-31
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime GetEndInMonth(this DateTime source)
        {
            return source.GetStartInMonth().AddMonths(1).AddMilliseconds(-1);
        }
    }
}
