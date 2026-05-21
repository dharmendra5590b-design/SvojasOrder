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

        public static void WriteLogFile(Exception ex)
        {
            try
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLogs");

                // Create folder if not exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(
                    folderPath,
                    "ErrorLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"
                );

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine("Date Time : " + DateTime.Now);
                    writer.WriteLine("Message   : " + ex.Message);
                    writer.WriteLine("Source    : " + ex.Source);
                    writer.WriteLine("StackTrace: " + ex.StackTrace);

                    if (ex.InnerException != null)
                    {
                        writer.WriteLine("InnerException : " + ex.InnerException.Message);
                    }

                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine();
                }
            }
            catch
            {
                // Avoid throwing exception from logger
            }
        }

    }
}
