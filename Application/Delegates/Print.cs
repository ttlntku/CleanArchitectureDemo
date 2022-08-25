using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;

namespace Application.Delegates
{
    public static class PrintDelegate
    {
        public delegate MemoryStream print<T>(List<T> obj);

        public static DataTable ToDataTable<T>(this List<T> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static MemoryStream ExportToXlsx<T>(List<T> listObj)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            var datatable = ToDataTable(listObj);
            using (MemoryStream stream = new MemoryStream())
            {
                using (ExcelPackage pck = new ExcelPackage(stream))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
                    ws.Cells["A1"].LoadFromDataTable(datatable, true);
                    pck.Save();
                }
                return stream;
            }
        }

        public static MemoryStream ExportToCSV<T>(List<T> listObj)
        {
            var table = ToDataTable(listObj);

            var result = new StringBuilder();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                result.Append(table.Columns[i].ColumnName);
                result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
            }

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == table.Columns.Count - 1 ? "\n" : ",");
                }
            }
            var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(result.ToString());
            MemoryStream stream = new MemoryStream(bytes);

            return stream;
        }
    }
}
