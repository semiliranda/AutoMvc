using System.Collections.Generic;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMvc.Models;

namespace AutoMvc.Controllers
{
    public class AutosController : Controller
    {
        private readonly AutoDBContext db = new AutoDBContext();

        // GET: Autos
        public ActionResult Index(string autoStatus, string searchString)
        {
            var StatusList = new List<string>();

            var StatusQry = from d in db.Autos
                            orderby d.Status
                            select d.Status;

            StatusList.AddRange(StatusQry.Distinct());
            ViewBag.autoStatus = new SelectList(StatusList, "Rented");

            var autos = from m in db.Autos
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                autos = autos.Where(s => s.Lessee.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(autoStatus))
            {
                autos = autos.Where(x => x.Status == autoStatus);
            }

            return View(autos);
        }

        // GET: Autos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Autos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Type,Price")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Autos.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auto);
        }

        // GET: Autos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Autos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Type,Price")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auto);
        }

        // GET: Autos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Autos.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto auto = db.Autos.Find(id);
            db.Autos.Remove(auto);
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
