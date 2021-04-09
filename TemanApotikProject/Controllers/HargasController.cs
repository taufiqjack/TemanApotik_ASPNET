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
    public class HargasController : Controller
    {
        private TemanApotikEntities db = new TemanApotikEntities();

        // GET: Hargas
        public ActionResult Index()
        {
            var hargas = db.Hargas.Include(h => h.Obat);
            return View(hargas.ToList());
        }

        // GET: Hargas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Harga harga = db.Hargas.Find(id);
            if (harga == null)
            {
                return HttpNotFound();
            }
            return View(harga);
        }

        // GET: Hargas/Create
        public ActionResult Create()
        {
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat");
            ViewBag.id_Jenis_Obat = new SelectList(db.JenisObats, "id_Jenis_Obat", "Jenis_Obat");
            return View();
        }

        // POST: Hargas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Harga,id_Obat,id_Jenis_Obat,Harga_Awal,Diskon,Harga_Akhir")] Harga harga)
        {
            if (ModelState.IsValid)
            {
                db.Hargas.Add(harga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", harga.id_Obat);
            return View(harga);
        }

        // GET: Hargas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Harga harga = db.Hargas.Find(id);
            if (harga == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", harga.id_Obat);
            return View(harga);
        }

        // POST: Hargas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Harga,id_Obat,id_Jenis_Obat,Harga_Awal,Diskon,Harga_Akhir")] Harga harga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(harga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", harga.id_Obat);
            return View(harga);
        }

        // GET: Hargas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Harga harga = db.Hargas.Find(id);
            if (harga == null)
            {
                return HttpNotFound();
            }
            return View(harga);
        }

        // POST: Hargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Harga harga = db.Hargas.Find(id);
            db.Hargas.Remove(harga);
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
