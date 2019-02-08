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
    public class MeasuresController : Controller
    {
        private SpeedContext db = new SpeedContext();

        // GET: Measures
        public async Task<ActionResult> Index()
        {
            return View(await db.Measures.ToListAsync());
        }

        // GET: Measures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = await db.Measures.FindAsync(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // GET: Measures/Create
        public ActionResult Create()
        {
           
            
            return View();
        }

        // POST: Measures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MeasureId,Name")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                measure.DataCreate = DateTime.Now;
               
                try
                {

                    db.Measures.Add(measure);
                    await db.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View(measure);
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(measure);
        }

        // GET: Measures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = await db.Measures.FindAsync(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: Measures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MeasureId,Name")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    db.Entry(measure).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View(measure);
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(measure);
        }

        // GET: Measures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = await db.Measures.FindAsync(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: Measures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Measure measure = await db.Measures.FindAsync(id);
            db.Measures.Remove(measure);
            try
            {
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null &&
                        ex.InnerException.InnerException != null &&
                        ex.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, "Não é possível remover a cor, porque existe outros relacionamentos a ele, primeiro remova as os relacionamentos  e volte a tentar!!");
                }
                return View(measure);
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
