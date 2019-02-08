using System;
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

namespace SpeedSystem.Controllers
{
    public class ColorMeshesController : Controller
    {
        private SpeedContext db = new SpeedContext();

        // GET: ColorMeshes
        public async Task<ActionResult> Index()
        {
            return View(await db.ColorMeshes.ToListAsync());
        }

        // GET: ColorMeshes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorMesh colorMesh = await db.ColorMeshes.FindAsync(id);
            if (colorMesh == null)
            {
                return HttpNotFound();
            }
            return View(colorMesh);
        }

        // GET: ColorMeshes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorMeshes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ColorMeshId,Color,DataCreate")] ColorMesh colorMesh)
        {
            if (ModelState.IsValid)
            {
                colorMesh.DataCreate = DateTime.Now;

			try{

                db.ColorMeshes.Add(colorMesh);
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View(colorMesh);
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(colorMesh);
        }

        // GET: ColorMeshes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorMesh colorMesh = await db.ColorMeshes.FindAsync(id);
            if (colorMesh == null)
            {
                return HttpNotFound();
            }
            return View(colorMesh);
        }

        // POST: ColorMeshes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ColorMeshId,Color,DataCreate")] ColorMesh colorMesh)
        {
            if (ModelState.IsValid)
            {
			try{

                db.Entry(colorMesh).State = EntityState.Modified;
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
					{
						ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
						return View(colorMesh);
						throw;
					}
                return RedirectToAction("Index");
            }
            return View(colorMesh);
        }

        // GET: ColorMeshes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorMesh colorMesh = await db.ColorMeshes.FindAsync(id);
            if (colorMesh == null)
            {
                return HttpNotFound();
            }
            return View(colorMesh);
        }

        // POST: ColorMeshes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ColorMesh colorMesh = await db.ColorMeshes.FindAsync(id);
            db.ColorMeshes.Remove(colorMesh);
            try
            {
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            // Verificando se existe um relacionamento e nega a exclusão.
            catch (Exception ex)
            {
                if (ex.InnerException != null &&
                        ex.InnerException.InnerException != null &&
                        ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, "Não é possível remover a cor, porque existe outros relacionamentos a ela, primeiro remova as os relacionamentos  e volte a tentar!!");
                }
                return View(colorMesh);
            }
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
