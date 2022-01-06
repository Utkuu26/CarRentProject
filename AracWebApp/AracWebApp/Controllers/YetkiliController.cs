using AracWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace AracWebApp.Controllers
{
    public class YetkiliController : Controller
    {
        private AracEntities db = new AracEntities();
        // GET: Yetkili
        public ActionResult Index()
        {
            var tblArac = db.tblArac.Include(t => t.tblModel);
            return View(tblArac.ToList());
            
        }
        // GET: Arac/Create
        public ActionResult AracEkle()
        {
            ViewBag.modelId = new SelectList(db.tblModel, "modelId", "modelAd");
            return View();
        }

        // POST: Arac/AracEkle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AracEkle([Bind(Include = "aracId,modelId,airbag,aciklama,gunlukFiyat,koltukSayisi,bagajHacmi,km,resim")] tblArac tblArac)
        {
            if (ModelState.IsValid)
            {
                db.tblArac.Add(tblArac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.modelId = new SelectList(db.tblModel, "modelId", "modelAd", tblArac.modelId);
            return View(tblArac);
        }
        // GET: Arac/Duzenle/5
        public ActionResult AracDuzenle(int? id)
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
            ViewBag.modelId = new SelectList(db.tblModel, "modelId", "modelAd", tblArac.modelId);
            return View(tblArac);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AracDuzenle([Bind(Include = "aracId,modelId,airbag,aciklama,gunlukFiyat,koltukSayisi,bagajHacmi,km,resim")] tblArac tblArac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblArac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.modelId = new SelectList(db.tblModel, "modelId", "modelAd", tblArac.modelId);
            return View(tblArac);
        }

        public ActionResult AracDetay(int? id)
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

        // GET: Arac/Sil/5
        public ActionResult AracSil(int? id)
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

        // POST: Arac/Sil/5
        [HttpPost, ActionName("AracSil")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblArac tblArac = db.tblArac.Find(id);
            db.tblArac.Remove(tblArac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Basvurular()
        {
            var tblKiralama = db.tblKiralama.Include(t => t.tblArac).Include(t => t.tblMusteri);
            return View(tblKiralama.ToList());
        }
        // GET: Kiralama/KabulEt/5
        public ActionResult KabulEt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblKiralama tblKiralama = db.tblKiralama.Find(id);
            if (tblKiralama == null)
            {
                return HttpNotFound();
            }
            ViewBag.aracId = new SelectList(db.tblArac, "aracId", "aciklama", tblKiralama.aracId);
            ViewBag.musteriId = new SelectList(db.tblMusteri, "musteriId", "musteriAd", tblKiralama.musteriId);
            return View(tblKiralama);
        }

        // POST: Kiralama/KabulEt/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KabulEt([Bind(Include = "kiralamaId,kiralamaDurum,aracId,musteriId,aciklama,gunSayisi,ucret,tarih")] tblKiralama tblKiralama)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKiralama).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aracId = new SelectList(db.tblArac, "aracId", "aciklama", tblKiralama.aracId);
            ViewBag.musteriId = new SelectList(db.tblMusteri, "musteriId", "musteriAd", tblKiralama.musteriId);
            return View(tblKiralama);
        }


    }
}