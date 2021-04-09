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
    public class ObatKeluarsController : Controller
    {
        private TemanApotikEntities db = new TemanApotikEntities();

        // GET: ObatKeluars
        public ActionResult Index()
        {
            var obatKeluars = db.ObatKeluars.Include(o => o.Obat).Include(o => o.Pasien);
            return View(obatKeluars.ToList());
        }

        // GET: ObatKeluars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObatKeluar obatKeluar = db.ObatKeluars.Find(id);
            if (obatKeluar == null)
            {
                return HttpNotFound();
            }
            return View(obatKeluar);
        }

        // GET: ObatKeluars/Create
        public ActionResult Create()
        {
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat");
            ViewBag.Id_Pasien = new SelectList(db.Pasiens, "id_Pasien", "Nama_Pasien");
            return View();
        }

        // POST: ObatKeluars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Transaksi_Keluar,Tgl_Keluar,Id_Pasien,id_Obat,id_Jenis_Obat,Jumlah_Keluar,Total_Harga")] ObatKeluar obatKeluar)
        {
            if (ModelState.IsValid)
            {
                db.ObatKeluars.Add(obatKeluar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", obatKeluar.id_Obat);
            ViewBag.Id_Pasien = new SelectList(db.Pasiens, "id_Pasien", "Nama_Pasien", obatKeluar.Id_Pasien);
            return View(obatKeluar);
        }

        // GET: ObatKeluars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObatKeluar obatKeluar = db.ObatKeluars.Find(id);
            if (obatKeluar == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", obatKeluar.id_Obat);
            ViewBag.Id_Pasien = new SelectList(db.Pasiens, "id_Pasien", "Nama_Pasien", obatKeluar.Id_Pasien);
            return View(obatKeluar);
        }

        // POST: ObatKeluars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Transaksi_Keluar,Tgl_Keluar,Id_Pasien,id_Obat,id_Jenis_Obat,Jumlah_Keluar,Total_Harga")] ObatKeluar obatKeluar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obatKeluar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Obat = new SelectList(db.Obats, "id_Obat", "Kode_Obat", obatKeluar.id_Obat);
            ViewBag.Id_Pasien = new SelectList(db.Pasiens, "id_Pasien", "Nama_Pasien", obatKeluar.Id_Pasien);
            return View(obatKeluar);
        }

        // GET: ObatKeluars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObatKeluar obatKeluar = db.ObatKeluars.Find(id);
            if (obatKeluar == null)
            {
                return HttpNotFound();
            }
            return View(obatKeluar);
        }

        // POST: ObatKeluars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObatKeluar obatKeluar = db.ObatKeluars.Find(id);
            db.ObatKeluars.Remove(obatKeluar);
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
