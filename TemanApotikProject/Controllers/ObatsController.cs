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
    public class ObatsController : Controller
    {
        private TemanApotikEntities db = new TemanApotikEntities();

        // GET: Obats
        public ActionResult Index()
        {
            var obats = db.Obats.Include(o => o.JenisObat);
            return View(obats.ToList());
        }

        // GET: Obats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obat obat = db.Obats.Find(id);
            if (obat == null)
            {
                return HttpNotFound();
            }
            return View(obat);
        }

        // GET: Obats/Create
        public ActionResult Create()
        {
            ViewBag.id_Jenis_Obat = new SelectList(db.JenisObats, "id_Jenis_Obat", "Jenis_Obat");
            return View();
        }

        // POST: Obats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Obat,Kode_Obat,Nama_Obat,id_Jenis_Obat")] Obat obat)
        {
            if (ModelState.IsValid)
            {
                db.Obats.Add(obat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Jenis_Obat = new SelectList(db.JenisObats, "id_Jenis_Obat", "Jenis_Obat", obat.id_Jenis_Obat);
            return View(obat);
        }

        // GET: Obats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obat obat = db.Obats.Find(id);
            if (obat == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Jenis_Obat = new SelectList(db.JenisObats, "id_Jenis_Obat", "Jenis_Obat", obat.id_Jenis_Obat);
            return View(obat);
        }

        // POST: Obats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Obat,Kode_Obat,Nama_Obat,id_Jenis_Obat")] Obat obat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Jenis_Obat = new SelectList(db.JenisObats, "id_Jenis_Obat", "Jenis_Obat", obat.id_Jenis_Obat);
            return View(obat);
        }

        // GET: Obats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obat obat = db.Obats.Find(id);
            if (obat == null)
            {
                return HttpNotFound();
            }
            return View(obat);
        }

        // POST: Obats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obat obat = db.Obats.Find(id);
            db.Obats.Remove(obat);
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
