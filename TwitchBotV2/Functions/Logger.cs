using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBotV2.Functions
{
    public class Logger
    {

        public static void Log(string prefix, string message)
        {
            try
            {
                string filename = Globals.Settings.LoggingDirectory + "/" + File.Exists(DateTime.Today.ToString().Replace(".", "_").Replace(";", "_").Replace(" ", "_"));
                if (!File.Exists(filename))
                {
                    File.WriteAllText(filename, $"{DateTime.Now} [{prefix.ToUpper()}]\t{message}\n");
                }
                else
                {
                    File.AppendAllText(filename, $"{DateTime.Now} [{prefix.ToUpper()}]\t{message}\n");
                }
            }
            catch
            {

            }
        }

    }
}
