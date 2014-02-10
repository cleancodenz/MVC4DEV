using System.Web.SessionState;
using SessionLess.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace SessionLess.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
  
    public class ValidationController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        public JsonResult IsTitle_Available(string title)
        {
            if (db.Albums.Where(a => a.Title == title).FirstOrDefault() == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                "{0} is not available.", title);

            for (int i = 1; i < 100; i++) {
                string altCandidate = title + i.ToString();
                if (db.Albums.Where(a => a.Title == altCandidate).FirstOrDefault() == null)
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture,
                   "{0} is not available. Try {1}.", title, altCandidate);
                    break;
                }
            }
            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        
        }
	}
}