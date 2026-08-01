using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Utility
    {
        public static List<Dictionary<string, object>> ToList(DataTable dtable)
        {
            Dictionary<string, object> dict = null;
            List<Dictionary<string, object>> lookUpData = new List<Dictionary<string, object>>();

            try
            {
                foreach (DataRow drow in dtable.Rows)
                {
                    dict = new Dictionary<string, object>();
                    for (int intCol = 0; intCol <= dtable.Columns.Count - 1; intCol++)
                    {
                        //if (!string.IsNullOrEmpty(drow[intCol].ToString().Trim()))
                        if (drow[intCol] != null)
                        {
                            dict.Add(dtable.Columns[intCol].ColumnName.Trim(), drow[intCol]);
                        }
                        else
                        {
                            dict.Add(dtable.Columns[intCol].ColumnName.Trim(), null);
                        }
                    }
                    lookUpData.Add(dict);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return lookUpData;
        }

        public static List<SelectItem> ConvertToSelectList(
    DataTable dt,
    string textColumn,
    string valueColumn)
        {
            List<SelectItem> list = new List<SelectItem>();

            if (dt == null || dt.Rows.Count == 0)
                return list;

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SelectItem
                {
                    text = row[textColumn]?.ToString() ?? string.Empty,
                    value = row[valueColumn]?.ToString() ?? string.Empty
                });
            }

            return list;
        }

        public static string? GetRelativePath(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            return Uri.TryCreate(url, UriKind.Absolute, out var uri)
                ? uri.AbsolutePath.TrimStart('/')
                : url;
        }
        public static string GetVal(DataRow row, string colName)
        {
            if (!row.Table.Columns.Contains(colName)) return "";
            var val = row[colName];
            if (val == null || val == DBNull.Value) return "";
            if (val is DateTime dt) return dt.ToString("dd-MM-yyyy");
            return val.ToString();
        }


    }
}
