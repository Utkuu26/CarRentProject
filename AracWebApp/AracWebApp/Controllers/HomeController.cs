using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracWebApp.Models;
using System.Data.Entity;
using System.Net;


namespace AracWebApp.Controllers
{
    public class HomeController : Controller

    {
        private AracEntities db = new AracEntities();
        public ActionResult Index()
        {

            var tblArac = db.tblArac.Include(t => t.tblModel);
            return View(tblArac.ToList());

        }
        public ActionResult Detay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArac tblArac = db.tblArac.Find(id);
            if (tblArac == null)
            {
                return HttpNotFound();
            }
            return View(tblArac);
        }
        // GET: Kiralama/Başvuru
        public ActionResult Basvur()
        {
            ViewBag.aracId = new SelectList(db.tblArac, "aracId", "aciklama");
            ViewBag.musteriId = new SelectList(db.tblMusteri, "musteriId", "musteriAd");
            return View();
        }

        // POST: Kiralama/Başvuru
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Basvur([Bind(Include = "kiralamaId,kiralamaDurum,aracId,musteriId,aciklama,gunSayisi,ucret,tarih")] tblKiralama tblKiralama)
        {
            if (ModelState.IsValid)
            {
                db.tblKiralama.Add(tblKiralama);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aracId = new SelectList(db.tblArac, "aracId", "aciklama", tblKiralama.aracId);
            ViewBag.musteriId = new SelectList(db.tblMusteri, "musteriId", "musteriAd", tblKiralama.musteriId);
            return View(tblKiralama);
        }
    }
}