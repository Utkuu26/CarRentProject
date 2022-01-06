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
    public class ModelController : Controller
    {
        private AracEntities db = new AracEntities();

        // GET: Model
        public ActionResult Index()
        {
            var tblModel = db.tblModel.Include(t => t.tblMarka);
            return View(tblModel.ToList());
        }

        // GET: Model/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblModel = db.tblModel.Find(id);
            if (tblModel == null)
            {
                return HttpNotFound();
            }
            return View(tblModel);
        }

        // GET: Model/Create
        public ActionResult Create()
        {
            ViewBag.markaId = new SelectList(db.tblMarka, "markaId", "markaAd");
            return View();
        }

        // POST: Model/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "modelId,modelAd,markaId")] tblModel tblModel)
        {
            if (ModelState.IsValid)
            {
                db.tblModel.Add(tblModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.markaId = new SelectList(db.tblMarka, "markaId", "markaAd", tblModel.markaId);
            return View(tblModel);
        }

        // GET: Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblModel = db.tblModel.Find(id);
            if (tblModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.markaId = new SelectList(db.tblMarka, "markaId", "markaAd", tblModel.markaId);
            return View(tblModel);
        }

        // POST: Model/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "modelId,modelAd,markaId")] tblModel tblModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.markaId = new SelectList(db.tblMarka, "markaId", "markaAd", tblModel.markaId);
            return View(tblModel);
        }

        // GET: Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblModel tblModel = db.tblModel.Find(id);
            if (tblModel == null)
            {
                return HttpNotFound();
            }
            return View(tblModel);
        }

        // POST: Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblModel tblModel = db.tblModel.Find(id);
            db.tblModel.Remove(tblModel);
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
