﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpeedSystem.Data;
using SpeedSystem.Models;
using SpeedSystem.Helpers;

namespace SpeedSystem.Controllers
{
    public class MeshesController : Controller
    {
        private SpeedContext db = new SpeedContext();

        // GET: Meshes
        public async Task<ActionResult> Index()
        {
            var meshes = db.Meshes.Include(m => m.ColorMesh).Include(m => m.Measure);
            return View(await meshes.ToListAsync());
        }

        // GET: Meshes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesh mesh = await db.Meshes.FindAsync(id);
            if (mesh == null)
            {
                return HttpNotFound();
            }
            return View(mesh);
        }

        // GET: Meshes/Create
        public ActionResult Create()
        {
            ViewBag.ColorMeshId = new SelectList(CombosHelper.GetColors(), "ColorMeshId", "Color");
            ViewBag.MeasureId = new SelectList(CombosHelper.GetMeasures(), "MeasureId", "Name");
            return View();
        }

        // POST: Meshes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MeshId,Name,CustValue,Yeild,Sublimation,MeasureId,ColorMeshId,DataCreate")] Mesh mesh)
        {
            if (ModelState.IsValid)
            {

			try{

                db.Meshes.Add(mesh);
                await db.SaveChangesAsync();
			}
                catch (System.Exception ex)
                {

                    if (ex.InnerException != null &&
                                           ex.InnerException.InnerException != null &&
                                           ex.InnerException.InnerException.Message.Contains("Mesh_Name_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "Não é possível inserir com o mesmo nome!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }

                    ViewBag.MeasureId = new SelectList(CombosHelper.GetMeasures(), "MeasureId", "Name", mesh.MeasureId);
                    ViewBag.ColorMeshId = new SelectList(CombosHelper.GetColors(), "ColorMeshId", "Color", mesh.ColorMeshId);
                    return View(mesh);
                }
            }

            ViewBag.ColorMeshId = new SelectList(CombosHelper.GetColors(), "ColorMeshId", "Color", mesh.ColorMeshId);
            ViewBag.MeasureId = new SelectList(CombosHelper.GetMeasures(), "MeasureId", "Name", mesh.MeasureId);
            return View(mesh);
        }

        // GET: Meshes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesh mesh = await db.Meshes.FindAsync(id);
            if (mesh == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorMeshId = new SelectList(CombosHelper.GetColors(), "ColorMeshId", "Color", mesh.ColorMeshId);
            ViewBag.MeasureId = new SelectList(CombosHelper.GetMeasures(), "MeasureId", "Name", mesh.MeasureId);
            return View(mesh);
        }

        // POST: Meshes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MeshId,Name,CustValue,Yeild,Sublimation,MeasureId,ColorMeshId,DataCreate")] Mesh mesh)
        {
            if (ModelState.IsValid)
            {
			try{

                db.Entry(mesh).State = EntityState.Modified;
                await db.SaveChangesAsync();
			}
                catch (System.Exception ex)
                {

                    if (ex.InnerException != null &&
                                           ex.InnerException.InnerException != null &&
                                           ex.InnerException.InnerException.Message.Contains("Mesh_Name_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "Não é possível inserir com o mesmo nome!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }

                    ViewBag.MeasureId = new SelectList(CombosHelper.GetMeasures(), "MeasureId", "Name", mesh.MeasureId);
                    ViewBag.ColorMeshId = new SelectList(CombosHelper.GetColors(), "ColorMeshId", "Color", mesh.ColorMeshId);
                    return View(mesh);
                }
            }
            ViewBag.ColorMeshId = new SelectList(CombosHelper.GetColors(), "ColorMeshId", "Color", mesh.ColorMeshId);
            ViewBag.MeasureId = new SelectList(CombosHelper.GetMeasures(), "MeasureId", "Name", mesh.MeasureId);
            return View(mesh);
        }

        // GET: Meshes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mesh mesh = await db.Meshes.FindAsync(id);
            if (mesh == null)
            {
                return HttpNotFound();
            }
            return View(mesh);
        }

        // POST: Meshes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mesh mesh = await db.Meshes.FindAsync(id);
            db.Meshes.Remove(mesh);
            await db.SaveChangesAsync();
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
