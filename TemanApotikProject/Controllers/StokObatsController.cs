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
    public class StokObatsController : Controller
    {
        private TemanApotikEntities db = new TemanApotikEntities();

        // GET: StokObats
        public ActionResult Index()
        {
            var stokObats = db.StokObats.Include(s => s.Obat);
            return View(stokObats.ToList());
        }

        // GET: StokObats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokObat stokObat = db.StokObats.Find(id);
            if (stokObat == null)
            {
                return HttpNotFound();
            }
            return View(stokObat);
        }

        // GET: StokObats/Create
        public ActionResult Create()
        {
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat");
            return View();
        }

        // POST: StokObats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Stok_Obat,id_Obat,id_Jenis_Obat,Stock_In_Hand")] StokObat stokObat)
        {
            if (ModelState.IsValid)
            {
                db.StokObats.Add(stokObat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", stokObat.id_Obat);
            return View(stokObat);
        }

        // GET: StokObats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokObat stokObat = db.StokObats.Find(id);
            if (stokObat == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", stokObat.id_Obat);
            return View(stokObat);
        }

        // POST: StokObats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Stok_Obat,id_Obat,id_Jenis_Obat,Stock_In_Hand")] StokObat stokObat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stokObat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", stokObat.id_Obat);
            return View(stokObat);
        }

        // GET: StokObats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StokObat stokObat = db.StokObats.Find(id);
            if (stokObat == null)
            {
                return HttpNotFound();
            }
            return View(stokObat);
        }

        // POST: StokObats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StokObat stokObat = db.StokObats.Find(id);
            db.StokObats.Remove(stokObat);
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
