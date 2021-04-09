using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TemanApotikProject.Models;

namespace TemanApotikProject.Controllers
{
    public class JenisObatsController : Controller
    {
        private TemanApotikEntities db = new TemanApotikEntities();

        // GET: JenisObats
        public ActionResult Index()
        {
            return View(db.JenisObats.ToList());
        }

        // GET: JenisObats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenisObat jenisObat = db.JenisObats.Find(id);
            if (jenisObat == null)
            {
                return HttpNotFound();
            }
            return View(jenisObat);
        }

        // GET: JenisObats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JenisObats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Jenis_Obat,Jenis_Obat")] JenisObat jenisObat)
        {
            if (ModelState.IsValid)
            {
                db.JenisObats.Add(jenisObat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jenisObat);
        }

        // GET: JenisObats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenisObat jenisObat = db.JenisObats.Find(id);
            if (jenisObat == null)
            {
                return HttpNotFound();
            }
            return View(jenisObat);
        }

        // POST: JenisObats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Jenis_Obat,Jenis_Obat")] JenisObat jenisObat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jenisObat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jenisObat);
        }

        // GET: JenisObats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JenisObat jenisObat = db.JenisObats.Find(id);
            if (jenisObat == null)
            {
                return HttpNotFound();
            }
            return View(jenisObat);
        }

        // POST: JenisObats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JenisObat jenisObat = db.JenisObats.Find(id);
            db.JenisObats.Remove(jenisObat);
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
