using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ErrorLog
    {
        public static void WriteLogFile(string text)
        {
            try
            {
                string pathToConfigFile = AppDomain.CurrentDomain.BaseDirectory;
                string LogDir = Path.Combine(pathToConfigFile, "Logs");

                if (!Directory.Exists(LogDir))
                {
                    Directory.CreateDirectory(LogDir);
                }
                string path = Path.Combine(LogDir, "ErrorLog" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(text);
                    writer.WriteLine(string.Format("\n"));
                    writer.WriteLine(string.Format(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                    writer.WriteLine(string.Format("\n"));
                    writer.Close();
                }
            }
            catch (Exception Ex)
            {
                //throw Ex;
            }
        }
    }
}
