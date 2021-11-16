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
    public class LoginController : Controller
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View(db.Secretaries.ToList());
        }

        // GET: Login/Details/5
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

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,password")] Secretary secretary)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction("Index","Appointment");
            }
           // Appointment appointment = db.Appointments.Find(id); ;
            //return View(appointment);

            return View(secretary);

        }

        // GET: Login/Edit/5
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

        // POST: Login/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Login/Delete/5
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

        // POST: Login/Delete/5
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
