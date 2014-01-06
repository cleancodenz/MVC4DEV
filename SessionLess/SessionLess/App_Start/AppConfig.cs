using SessionLess.Models;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace SessionLess
{
    public class AppConfig
    {
        public static void Configure()
        {
            Database.SetInitializer(new SampleData());
        }
    }
}
