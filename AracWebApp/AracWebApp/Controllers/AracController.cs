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
    public class AracController : Controller
    {
        private AracEntities db = new AracEntities();

        // GET: Arac
        public ActionResult Index()
        {
            var tblArac = db.tblArac.Include(t => t.tblModel);
            return View(tblArac.ToList());
        }

        // GET: Arac/Details/5
        public ActionResult Details(int? id)
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

        // GET: Arac/Create
        public ActionResult Create()
        {
            ViewBag.modelId = new SelectList(db.tblModel, "modelId", "modelAd");
            return View();
        }

        // POST: Arac/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aracId,modelId,airbag,aciklama,gunlukFiyat,koltukSayisi,bagajHacmi,km,resim")] tblArac tblArac)
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

        // GET: Arac/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Arac/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aracId,modelId,airbag,aciklama,gunlukFiyat,koltukSayisi,bagajHacmi,km,resim")] tblArac tblArac)
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

        // GET: Arac/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Arac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblArac tblArac = db.tblArac.Find(id);
            db.tblArac.Remove(tblArac);
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
