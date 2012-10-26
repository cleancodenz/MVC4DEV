using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using log4net;

namespace MyCompany.Logging
{
    public static class LogUtil
    {
        static LogUtil()
        {
            FileInfo configfile = new FileInfo(
                 GetAssemblyDirecotry(Assembly.GetExecutingAssembly().CodeBase)
                             + @"\" + "log4net.config");

            log4net.Config.XmlConfigurator.
              ConfigureAndWatch(configfile);

        }

        public static string GetAssemblyDirecotry(string codebase)
        {
            UriBuilder uri = new UriBuilder(codebase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);

        }


        public static void Debug(Type _type, object message)
        {
            LogManager.GetLogger(_type).Debug(message);
        }

        public static void Error(Type _type, object message)
        {
            LogManager.GetLogger(_type).Error(message);
        }

        public static void Error(Type _type, object message, Exception ex)
        {
            LogManager.GetLogger(_type).Error(message, ex);
        }
        public static void Error(Type _type, Exception ex)
        {
            LogManager.GetLogger(_type).Error(ex);
        }

        public static void Info(Type _type, object message)
        {
            LogManager.GetLogger(_type).Info(message);
        }
    }
}
