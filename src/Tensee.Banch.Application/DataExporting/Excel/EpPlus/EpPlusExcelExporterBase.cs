using System;
using System.Collections.Generic;
using System.IO;
using Abp.AspNetZeroCore.Net;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Tensee.Banch.Dto;
using OfficeOpenXml;

namespace Tensee.Banch.DataExporting.Excel.EpPlus
{
    public abstract class EpPlusExcelExporterBase : BanchServiceBase, ITransientDependency
    {
        public IAppFolders AppFolders { get; set; }

        protected FileDto CreateExcelPackage(string fileName, Action<ExcelPackage> creator)
        {
            var file = new FileDto(fileName, MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet);

            using (var excelPackage = new ExcelPackage())
            {
                creator(excelPackage);
                Save(excelPackage, file);
            }

            return file;
        }

        protected void AddHeader(ExcelWorksheet sheet, params string[] headerTexts)
        {
            if (headerTexts.IsNullOrEmpty())
            {
                return;
            }

            for (var i = 0; i < headerTexts.Length; i++)
            {
                AddHeader(sheet, i + 1, headerTexts[i]);
            }
        }

        protected void AddHeader(ExcelWorksheet sheet, int columnIndex, string headerText)
        {
            sheet.Cells[1, columnIndex].Value = headerText;
            sheet.Cells[1, columnIndex].Style.Font.Bold = true;
        }

        protected void AddObjects<T>(ExcelWorksheet sheet, int startRowIndex, IList<T> items, params Func<T, object>[] propertySelectors)
        {
            if (items.IsNullOrEmpty() || propertySelectors.IsNullOrEmpty())
            {
                return;
            }

            for (var i = 0; i < items.Count; i++)
            {
                for (var j = 0; j < propertySelectors.Length; j++)
                {
                    sheet.Cells[i + startRowIndex, j + 1].Value = propertySelectors[j](items[i]);
                    sheet.Cells[i + startRowIndex, j + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;//水平居中
                    sheet.Cells[i + startRowIndex, j + 1].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;//垂直居中
                }
                sheet.Row(i+1).CustomHeight = true;//自动行高
            }
            for (int i = 0; i < propertySelectors.Length; i++)
            {
                sheet.Column(i + 1).AutoFit();//自动列宽   
            }
        }

        protected void Save(ExcelPackage excelPackage, FileDto file)
        {
            var filePath = Path.Combine(AppFolders.TempFileDownloadFolder, file.FileToken);
            excelPackage.SaveAs(new FileInfo(filePath));
        }
    }
}