using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DataRowExtensions
    {
        public static int? GetNullableInt(this DataRow dr, string column)
        {
            if (!dr.Table.Columns.Contains(column))
                return null;

            string value = Convert.ToString(dr[column])?.Trim();

            return int.TryParse(value, out int result)
                ? result
                : (int?)null;
        }

        public static decimal? GetNullableDecimal(this DataRow dr, string column)
        {
            if (!dr.Table.Columns.Contains(column))
                return null;

            string value = Convert.ToString(dr[column])?.Trim();

            return decimal.TryParse(value, out decimal result)
                ? result
                : (decimal?)null;
        }

        public static DateTime? GetNullableDateTime(this DataRow dr, string column)
        {
            if (!dr.Table.Columns.Contains(column))
                return null;

            string value = Convert.ToString(dr[column])?.Trim();

            return DateTime.TryParse(value, out DateTime result)
                ? result
                : (DateTime?)null;
        }

        public static bool GetBool(this DataRow dr, string column)
        {
            if (!dr.Table.Columns.Contains(column))
                return false;

            string value = Convert.ToString(dr[column])?.Trim();

            if (string.IsNullOrWhiteSpace(value))
                return false;

            if (bool.TryParse(value, out bool result))
                return result;

            if (value == "1")
                return true;

            if (value == "0")
                return false;

            return false;
        }

        public static string GetString(this DataRow dr, string column)
        {
            if (!dr.Table.Columns.Contains(column))
                return string.Empty;

            return Convert.ToString(dr[column])?.Trim() ?? string.Empty;
        }
    }
}
