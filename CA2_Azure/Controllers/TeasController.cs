using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CA2_Azure.Models;

namespace CA2_Azure.Controllers
{
    public class TeasController : Controller
    {
        private TeaModelContainer db = new TeaModelContainer();

        // GET: Teas
        public ActionResult Index()
        {
            return View(db.Teas.ToList());
        }

        // GET: Teas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea tea = db.Teas.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        // GET: Teas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Name,Qty,Price,Year")] Tea tea)
        {
            if (ModelState.IsValid)
            {
                db.Teas.Add(tea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tea);
        }

        // GET: Teas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea tea = db.Teas.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        // POST: Teas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Name,Qty,Price,Year")] Tea tea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tea);
        }

        // GET: Teas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tea tea = db.Teas.Find(id);
            if (tea == null)
            {
                return HttpNotFound();
            }
            return View(tea);
        }

        // POST: Teas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tea tea = db.Teas.Find(id);
            db.Teas.Remove(tea);
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
