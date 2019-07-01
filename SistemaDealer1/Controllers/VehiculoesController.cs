using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaDealer1.Models;

namespace SistemaDealer1.Controllers
{
    public class VehiculoesController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Vehiculoes
        public ActionResult Index()
        {
            var vehiculos = db.Vehiculos.Include(v => v.Combustible).Include(v => v.Marca).Include(v => v.Modelo).Include(v => v.Transmision);
            return View(vehiculos.ToList());
        }

        // GET: Vehiculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculoes/Create
        public ActionResult Create()
        {
            ViewBag.CombustibleId = new SelectList(db.Combustibles, "CombustibleId", "Descripcion");
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion");
            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion");
            ViewBag.TransmisionId = new SelectList(db.Transmisions, "TransmisionId", "Descripcion");
            return View();
        }

        // POST: Vehiculoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculos.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CombustibleId = new SelectList(db.Combustibles, "CombustibleId", "Descripcion", vehiculo.CombustibleId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", vehiculo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", vehiculo.ModeloId);
            ViewBag.TransmisionId = new SelectList(db.Transmisions, "TransmisionId", "Descripcion", vehiculo.TransmisionId);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CombustibleId = new SelectList(db.Combustibles, "CombustibleId", "Descripcion", vehiculo.CombustibleId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", vehiculo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", vehiculo.ModeloId);
            ViewBag.TransmisionId = new SelectList(db.Transmisions, "TransmisionId", "Descripcion", vehiculo.TransmisionId);
            return View(vehiculo);
        }

        // POST: Vehiculoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CombustibleId = new SelectList(db.Combustibles, "CombustibleId", "Descripcion", vehiculo.CombustibleId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", vehiculo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", vehiculo.ModeloId);
            ViewBag.TransmisionId = new SelectList(db.Transmisions, "TransmisionId", "Descripcion", vehiculo.TransmisionId);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            db.Vehiculos.Remove(vehiculo);
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
