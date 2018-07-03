using System;

namespace Tensee.Banch
{
    public class BanchConsts
    {
        public const string LocalizationSourceName = "Banch";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        public const int PaymentCacheDurationInMinutes = 120;
        /// <summary>
        /// 根据生日计算出年龄
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <returns>年龄</returns>
        public static int GetAgeByBirthday (DateTime birthday)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthday.Year;//当前年份减去出生年
            if (now.Month < birthday.Month || (now.Month == birthday.Month && now.Day < birthday.Day))
            {
                age--;//月份小于生日或者月份相等但天数小于生日则年龄-1
            }
            return age < 0 ? 0 : age;//最小返回0
        }
    }
}