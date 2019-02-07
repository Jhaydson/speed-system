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

namespace SpeedSystem.Controllers
{
    public class PrintSizesController : Controller
    {
        private SpeedContext db = new SpeedContext();

        // GET: PrintSizes
        public async Task<ActionResult> Index()
        {
            var printSizes = db.PrintSizes.Include(p => p.Measure);
            return View(await printSizes.ToListAsync());
        }

        // GET: PrintSizes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrintSize printSize = await db.PrintSizes.FindAsync(id);
            if (printSize == null)
            {
                return HttpNotFound();
            }
            return View(printSize);
        }

        // GET: PrintSizes/Create
        public ActionResult Create()
        {
            ViewBag.MeasureId = new SelectList(db.Measures, "MeasureId", "Name");
            return View();
        }

        // POST: PrintSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrintSizeId,Name,SizeX,SizeY,ValueSize,MeasureId,DataCreate")] PrintSize printSize)
        {
            if (ModelState.IsValid)
            {

			try{

                db.PrintSizes.Add(printSize);
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View( printSize);
                    throw;
                }
                return RedirectToAction("Index");
            }

            ViewBag.MeasureId = new SelectList(db.Measures, "MeasureId", "Name", printSize.MeasureId);
            return View(printSize);
        }

        // GET: PrintSizes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrintSize printSize = await db.PrintSizes.FindAsync(id);
            if (printSize == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeasureId = new SelectList(db.Measures, "MeasureId", "Name", printSize.MeasureId);
            return View(printSize);
        }

        // POST: PrintSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrintSizeId,Name,SizeX,SizeY,ValueSize,MeasureId,DataCreate")] PrintSize printSize)
        {
            if (ModelState.IsValid)
            {
			try{

                db.Entry(printSize).State = EntityState.Modified;
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
					{
						ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
						return View(printSize);
						throw;
					}
                return RedirectToAction("Index");
            }
            ViewBag.MeasureId = new SelectList(db.Measures, "MeasureId", "Name", printSize.MeasureId);
            return View(printSize);
        }

        // GET: PrintSizes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrintSize printSize = await db.PrintSizes.FindAsync(id);
            if (printSize == null)
            {
                return HttpNotFound();
            }
            return View(printSize);
        }

        // POST: PrintSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PrintSize printSize = await db.PrintSizes.FindAsync(id);
            db.PrintSizes.Remove(printSize);
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
