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
    public class MarkaController : Controller
    {
        private AracEntities db = new AracEntities();

        // GET: Marka
        public ActionResult Index()
        {
            return View(db.tblMarka.ToList());
        }

        // GET: Marka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMarka tblMarka = db.tblMarka.Find(id);
            if (tblMarka == null)
            {
                return HttpNotFound();
            }
            return View(tblMarka);
        }

        // GET: Marka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marka/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "markaId,markaAd")] tblMarka tblMarka)
        {
            if (ModelState.IsValid)
            {
                db.tblMarka.Add(tblMarka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMarka);
        }

        // GET: Marka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMarka tblMarka = db.tblMarka.Find(id);
            if (tblMarka == null)
            {
                return HttpNotFound();
            }
            return View(tblMarka);
        }

        // POST: Marka/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "markaId,markaAd")] tblMarka tblMarka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMarka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMarka);
        }

        // GET: Marka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMarka tblMarka = db.tblMarka.Find(id);
            if (tblMarka == null)
            {
                return HttpNotFound();
            }
            return View(tblMarka);
        }

        // POST: Marka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMarka tblMarka = db.tblMarka.Find(id);
            db.tblMarka.Remove(tblMarka);
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
