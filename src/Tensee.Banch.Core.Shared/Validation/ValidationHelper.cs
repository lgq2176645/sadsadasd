using System.Text.RegularExpressions;
using Abp.Extensions;

namespace Tensee.Banch.Validation
{
    public static class ValidationHelper
    {
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public static bool IsEmail(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            var regex = new Regex(EmailRegex);
            return regex.IsMatch(value);
        }

        /// <summary>
        /// 验证手机号是否有效
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>是否有效</returns>
        public static bool IsPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }
            string pattern = @"^1\d{10}$";//1开头，11位
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
