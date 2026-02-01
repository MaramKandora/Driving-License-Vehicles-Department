using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class clsLogger
    {
        public static string SourceName = "DVLD";
        public static void LogError(Exception ex)
        {
            string fullMessage =
          $"Exception: {ex.Message}{Environment.NewLine}" +
          $"Method: {ex.TargetSite?.DeclaringType?.FullName}.{ex.TargetSite?.Name}{Environment.NewLine}" +
          $"StackTrace:{Environment.NewLine}{ex.StackTrace}";

            EventLog.WriteEntry(SourceName, fullMessage, EventLogEntryType.Error);
        }

        public static void LogError(IOException ex)
        {
            string fullMessage =
          $"Exception: {ex.Message}{Environment.NewLine}" +
          $"Method: {ex.TargetSite?.DeclaringType?.FullName}.{ex.TargetSite?.Name}{Environment.NewLine}" +
          $"StackTrace:{Environment.NewLine}{ex.StackTrace}";

            EventLog.WriteEntry(SourceName, fullMessage, EventLogEntryType.Error);
        }

        public static void LogInformation(string Message)
        {

            EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Information);
        }

        public static void LogWarning(string Message)
        {
            EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Warning);
        }

        public static void Initialize()
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
        }

    }
}
