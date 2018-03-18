using System;
using System.IO;

namespace NexPayBankApp.Logging
{
    public class Log
    {
        public static void LogException(string sExceptionName, string sEventName, string sControlName, int nErrorLineNo)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = path + "logException.txt";
            StreamWriter log;
            if (!File.Exists(fileName))
            {
                log = new StreamWriter(fileName);
            }
            else
            {
                log = File.AppendText(fileName);
            }
            // Write to the file:
            log.WriteLine(Environment.NewLine);
            log.WriteLine("Data Time:" + DateTime.Now + ",");
            log.WriteLine("Exception Name:" + sExceptionName + ",");
            log.WriteLine("Event Name:" + sEventName + ",");
            log.WriteLine("Control Name:" + sControlName + ",");
            log.WriteLine("Error Line No.:" + nErrorLineNo + ",");
            
            // Close the stream:
            log.Close();
        }

        public static void LogInformation(string controller, string action,string name,string time,string routedata)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = path + "logActivity.txt";
            StreamWriter log;
            if (!File.Exists(fileName))
            {
                log = new StreamWriter(fileName);
            }
            else
            {
                log = File.AppendText(fileName);
            }
            // Write to the file:   
            log.WriteLine(Environment.NewLine);
            log.WriteLine("controller:" + controller + ",");
            log.WriteLine("Action:" + action);
            log.WriteLine(name + ":" + time + ",");
            log.WriteLine("RouteDate:" + routedata);
            log.WriteLine("Data Time:" + DateTime.Now + ",");
            // Close the stream:
            log.Close();
        }
    }
}