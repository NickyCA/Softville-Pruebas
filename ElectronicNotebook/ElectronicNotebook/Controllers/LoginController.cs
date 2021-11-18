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
            ViewBag.Message = "Login for secretary.";
            return View("Create");
        }

        // POST: Login/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,password")] Secretary secretary)
        {
            int input_id = secretary.id;
            string input_password = secretary.password;

            System.Diagnostics.Debug.WriteLine(secretary.id);
            System.Diagnostics.Debug.WriteLine(secretary.password);
            
            if (ModelState.IsValid)
            {
                secretary = db.Secretaries.Find(secretary.id);
                if (secretary == null)
                 {
                    ModelState.AddModelError(string.Empty, "Invalid UserName.");
                    return View(secretary);
                }
                
                if (secretary.password != input_password)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Password.");
                    return View(secretary);
                }
               

                return RedirectToAction("Index", "Appointment");
            }

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
