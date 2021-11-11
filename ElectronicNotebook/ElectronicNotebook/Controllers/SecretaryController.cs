using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectronicNotebook.Models;

namespace ElectronicNotebook.Controllers
{
    public class SecretaryController : Controller
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();

        // GET: Secretary
        public ActionResult Index()
        {
            return View(db.Secretaries.ToList());
        }

        // GET: Secretary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretary secretary = db.Secretaries.Find(id);
            if (secretary == null)
            {
                return HttpNotFound();
            }
            return View(secretary);
        }

        // GET: Secretary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Secretary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,lastName1,lastName2,password")] Secretary secretary)
        {
            if (ModelState.IsValid)
            {
                db.Secretaries.Add(secretary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secretary);
        }

        // GET: Secretary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretary secretary = db.Secretaries.Find(id);
            if (secretary == null)
            {
                return HttpNotFound();
            }
            return View(secretary);
        }

        // POST: Secretary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,lastName1,lastName2,password")] Secretary secretary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secretary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(secretary);
        }

        // GET: Secretary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secretary secretary = db.Secretaries.Find(id);
            if (secretary == null)
            {
                return HttpNotFound();
            }
            return View(secretary);
        }

        // POST: Secretary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secretary secretary = db.Secretaries.Find(id);
            db.Secretaries.Remove(secretary);
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
