using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AracWebApp.Models;

namespace AracWebApp.Controllers
{
    public class KiralamaController : Controller
    {
        private AracEntities db = new AracEntities();

        // GET: Kiralama
        public ActionResult Index()
        {
            var tblKiralama = db.tblKiralama.Include(t => t.tblArac).Include(t => t.tblMusteri);
            return View(tblKiralama.ToList());
        }

        // GET: Kiralama/Details/5
        public ActionResult Details(int? id)
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
            return View(tblKiralama);
        }

        // GET: Kiralama/Create
        public ActionResult Create()
        {
            ViewBag.aracId = new SelectList(db.tblArac, "aracId", "aciklama");
            ViewBag.musteriId = new SelectList(db.tblMusteri, "musteriId", "musteriAd");
            return View();
        }

        // POST: Kiralama/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kiralamaId,kiralamaDurum,aracId,musteriId,aciklama,gunSayisi,ucret,tarih")] tblKiralama tblKiralama)
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

        // GET: Kiralama/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Kiralama/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kiralamaId,kiralamaDurum,aracId,musteriId,aciklama,gunSayisi,ucret,tarih")] tblKiralama tblKiralama)
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

        // GET: Kiralama/Delete/5
        public ActionResult Delete(int? id)
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
            return View(tblKiralama);
        }

        // POST: Kiralama/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblKiralama tblKiralama = db.tblKiralama.Find(id);
            db.tblKiralama.Remove(tblKiralama);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
