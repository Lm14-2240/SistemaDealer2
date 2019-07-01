﻿using System;
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
    public class FacturasController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Facturas
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Cliente).Include(f => f.Empleado).Include(f => f.Vehiculo);
            return View(facturas.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus");
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario");
            ViewBag.VehiculoId = new SelectList(db.Vehiculos, "VehiculoId", "Color");
            return View();
        }

        // POST: Facturas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", factura.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", factura.EmpleadoId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculos, "VehiculoId", "Color", factura.VehiculoId);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", factura.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", factura.EmpleadoId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculos, "VehiculoId", "Color", factura.VehiculoId);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", factura.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", factura.EmpleadoId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculos, "VehiculoId", "Color", factura.VehiculoId);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
