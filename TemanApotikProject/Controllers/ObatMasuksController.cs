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
    public class ObatMasuksController : Controller
    {
        private TemanApotikEntities db = new TemanApotikEntities();

        // GET: ObatMasuks
        public ActionResult Index()
        {
            var obatMasuks = db.ObatMasuks.Include(o => o.Obat).Include(o => o.Supplier);
            return View(obatMasuks.ToList());
        }

        // GET: ObatMasuks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObatMasuk obatMasuk = db.ObatMasuks.Find(id);
            if (obatMasuk == null)
            {
                return HttpNotFound();
            }
            return View(obatMasuk);
        }

        // GET: ObatMasuks/Create
        public ActionResult Create()
        {
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat");
            ViewBag.id_Supplier = new SelectList(db.Suppliers, "id_Supplier", "Nama_Supplier");
            return View();
        }

        // POST: ObatMasuks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Transaksi_Masuk,Tgl_Masuk,id_Supplier,id_Obat,id_Jenis_Obat,Jumlah_Masuk,Harga_Beli")] ObatMasuk obatMasuk)
        {
            if (ModelState.IsValid)
            {
                db.ObatMasuks.Add(obatMasuk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", obatMasuk.id_Obat);
            ViewBag.id_Supplier = new SelectList(db.Suppliers, "id_Supplier", "Nama_Supplier", obatMasuk.id_Supplier);
            return View(obatMasuk);
        }

        // GET: ObatMasuks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObatMasuk obatMasuk = db.ObatMasuks.Find(id);
            if (obatMasuk == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", obatMasuk.id_Obat);
            ViewBag.id_Supplier = new SelectList(db.Suppliers, "id_Supplier", "Nama_Supplier", obatMasuk.id_Supplier);
            return View(obatMasuk);
        }

        // POST: ObatMasuks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Transaksi_Masuk,Tgl_Masuk,id_Supplier,id_Obat,id_Jenis_Obat,Jumlah_Masuk,Harga_Beli")] ObatMasuk obatMasuk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obatMasuk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", obatMasuk.id_Obat);
            ViewBag.id_Supplier = new SelectList(db.Suppliers, "id_Supplier", "Nama_Supplier", obatMasuk.id_Supplier);
            return View(obatMasuk);
        }

        // GET: ObatMasuks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObatMasuk obatMasuk = db.ObatMasuks.Find(id);
            if (obatMasuk == null)
            {
                return HttpNotFound();
            }
            return View(obatMasuk);
        }

        // POST: ObatMasuks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObatMasuk obatMasuk = db.ObatMasuks.Find(id);
            db.ObatMasuks.Remove(obatMasuk);
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
