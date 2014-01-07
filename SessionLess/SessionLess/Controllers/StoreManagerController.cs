using SessionLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SessionLess.Controllers
{
    
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

        public ActionResult Edit(int id)
        {
            Album album = this.db.Albums.Find(id);

            if (album == null)
            {
                return this.HttpNotFound();
            }

            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

            return this.View(album);

        }
        [HttpPost]
        public ActionResult Edit(Album album)
        {

            if (ModelState.IsValid)
            {
                this.db.Entry(album).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

            return this.View(album);

        }

        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Details(int id)
        {

            return View();
        }

        public ActionResult Delete(int id)
        {

            return View();
        }

	}
}