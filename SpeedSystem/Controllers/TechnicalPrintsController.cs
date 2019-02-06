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
    public class TechnicalPrintsController : Controller
    {
        private SpeedContext db = new SpeedContext();

        // GET: TechnicalPrints
        public async Task<ActionResult> Index()
        {
            return View(await db.TechnicalPrints.ToListAsync());
        }

        // GET: TechnicalPrints/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalPrint technicalPrint = await db.TechnicalPrints.FindAsync(id);
            if (technicalPrint == null)
            {
                return HttpNotFound();
            }
            return View(technicalPrint);
        }

        // GET: TechnicalPrints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicalPrints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TechnicalPrintId,Name,CustValue")] TechnicalPrint technicalPrint)
        {
            if (ModelState.IsValid)
            {

			try{

                db.TechnicalPrints.Add(technicalPrint);
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
                    return View( technicalPrint);
                    throw;
                }
                return RedirectToAction("Index");
            }

            return View(technicalPrint);
        }

        // GET: TechnicalPrints/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalPrint technicalPrint = await db.TechnicalPrints.FindAsync(id);
            if (technicalPrint == null)
            {
                return HttpNotFound();
            }
            return View(technicalPrint);
        }

        // POST: TechnicalPrints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TechnicalPrintId,Name,CustValue")] TechnicalPrint technicalPrint)
        {
            if (ModelState.IsValid)
            {
			try{

                db.Entry(technicalPrint).State = EntityState.Modified;
                await db.SaveChangesAsync();
			}
				catch (System.Exception)
					{
						ModelState.AddModelError(string.Empty, "Não possível adicionar, por ter um item cadastrado com esse mesmo nome!");
						return View(technicalPrint);
						throw;
					}
                return RedirectToAction("Index");
            }
            return View(technicalPrint);
        }

        // GET: TechnicalPrints/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalPrint technicalPrint = await db.TechnicalPrints.FindAsync(id);
            if (technicalPrint == null)
            {
                return HttpNotFound();
            }
            return View(technicalPrint);
        }

        // POST: TechnicalPrints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TechnicalPrint technicalPrint = await db.TechnicalPrints.FindAsync(id);
            db.TechnicalPrints.Remove(technicalPrint);
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
