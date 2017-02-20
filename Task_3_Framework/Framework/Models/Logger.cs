using log4net;
using System;

namespace Framework
{
    public class Logger
    {
        private static ILog Log { get; set; }

        public Logger()
        {
            try
            {
                Log = LogManager.GetLogger(typeof(Logger));
                log4net.Config.XmlConfigurator.Configure();
               
            }
            catch (Exception e)
            {
                Log.Error("Error with loggin work!\t" + e.Message);
            }
        }

        public void Info(string infoMsg)
        {
            Log.Info(infoMsg);
        }

        public void Debug(string debugMsg)
        {
            Log.Debug(debugMsg);
        }

        public void Error(string errorMsg)
        {
            Log.Error(errorMsg);
        }

        public void Fatal(string fatalMsg)
        {
            Log.Fatal(fatalMsg);
        }
    }
}