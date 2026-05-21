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
    }
}
