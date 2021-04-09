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
    public class PasiensController : Controller
    {
        private TemanApotikEntities db = new TemanApotikEntities();

        // GET: Pasiens
        public ActionResult Index()
        {
            return View(db.Pasiens.ToList());
        }

        // GET: Pasiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            return View(pasien);
        }

        // GET: Pasiens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pasiens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Pasien,Nama_Pasien,Alamat_Pasien,Diagnosa_Penyakit")] Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                db.Pasiens.Add(pasien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pasien);
        }

        // GET: Pasiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            return View(pasien);
        }

        // POST: Pasiens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Pasien,Nama_Pasien,Alamat_Pasien,Diagnosa_Penyakit")] Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pasien);
        }

        // GET: Pasiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasien pasien = db.Pasiens.Find(id);
            if (pasien == null)
            {
                return HttpNotFound();
            }
            return View(pasien);
        }

        // POST: Pasiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pasien pasien = db.Pasiens.Find(id);
            db.Pasiens.Remove(pasien);
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
