using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionLess.CustomControllerFactory
{
    public interface ILogger
    {
        void Log(string logData);
    }
    public class DefaultLogger : ILogger
    {
        public void Log(string logData)
        {
            System.Diagnostics.Debug.WriteLine(logData, "default");
        }
    } 
}