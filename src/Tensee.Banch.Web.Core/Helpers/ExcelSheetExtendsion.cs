using OfficeOpenXml;
using System.Collections.Generic;

namespace Tensee.Banch.Web.Helpers
{
    public static class ExcelSheetExtendsion
    {
        /// <summary>
        /// 获取有值的行数
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static int GetValuedRows(this ExcelWorksheet sheet)
        {
            if (sheet == null)
            {
                throw new System.ArgumentNullException(nameof(sheet));
            }
            int count = 0;
            while (sheet.GetValue(count, 0) != null)
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// 获取具体一行的连续指定长度数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="sheet">工作簿</param>
        /// <param name="row">行</param>
        /// <param name="startIndex">起始索引，默认0</param>
        /// <param name="endindex">结束索引</param>
        /// <returns></returns>
        public static List<T> GetRowValues<T>(this ExcelWorksheet sheet, int row, int endindex, int startIndex = 0)
        {
            var objs = sheet.Cells.Value as object[,];
            List<T> result = new List<T>();
            for (int i = startIndex; i <= endindex; i++)
            {
                result.Add((T)objs[row, i]);
            }

            return result;
        }


    }
}
