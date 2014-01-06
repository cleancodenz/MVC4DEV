using SessionLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SessionLess.Controllers
{
    //http://www.asp.net/mvc/tutorials/hands-on-labs/aspnet-mvc-4-helpers,-forms-and-validation#Exercise6

    public class StoreManagerController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        //
        // GET: /StoreManager/
        public ActionResult Index()
        {
            // Get the list
            var albums = db.Albums.
                Include(a => a.Genre)
                .Include(a => a.Artist)
                .OrderBy(a => a.Price);

            return View(albums);
        }
	}
}