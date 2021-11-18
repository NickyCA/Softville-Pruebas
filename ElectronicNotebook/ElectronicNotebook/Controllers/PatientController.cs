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
    public class PatientController : Controller
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();

        // GET: Patient
        public ActionResult Index()
        {
            return View("Index",db.Patients.ToList());
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,lastName1,lastName2,email,phone")] Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch
            {
                Response.Write("<script language=javascript>alert('Cédula de paciente ya registrada')</script>");
            }
            return View(patient);
        }
        /*
         *  // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }
       // GET: Patient/Edit/5
       public ActionResult Edit(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Patient patient = db.Patients.Find(id);
           if (patient == null)
           {
               return HttpNotFound();
           }
           return View(patient);
       }


       // POST: Patient/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to, for 
       // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit([Bind(Include = "id,name,lastName1,lastName2,email,phone")] Patient patient)
       {
           if (ModelState.IsValid)
           {
               db.Entry(patient).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");
           }
           return View(patient);
       }
       */
        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View("Delete",patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);

            try
            {
                db.Patients.Remove(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Response.Write("<script language=javascript>alert('No se puede eliminar el paciente con citas asociadas, elimine las citas primero')</script>");
            }
            return View(patient);
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
