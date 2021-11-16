using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ElectronicNotebook.Models;

namespace ElectronicNotebook.Controllers
{
    public class AppointmentController : Controller
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();

        // GET: Appointment
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Patient).Include(a => a.Professional);

            return View(appointments.ToList());
        }

        // GET: Appointment/Details/5
        public ActionResult Details(DateTime date, TimeSpan time)
        {
            if (date == null || time == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(date, time);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            ViewBag.patientId = new SelectList(db.Patients, "id", "name");
            ViewBag.professionalId = new SelectList(db.Professionals, "id", "name");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "date,time,patientId,professionalId")] Appointment appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } catch {
                Response.Write("<script language=javascript>alert('Ya hay una cita agendada a la hora y fecha digitadas. Por favor agendarla en otro momento. Volverá a la página de registro de citas.')</script>");
            }
            ViewBag.patientId = new SelectList(db.Patients, "id", "name", appointment.patientId);
            ViewBag.professionalId = new SelectList(db.Professionals, "id", "name", appointment.professionalId);
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(DateTime date, TimeSpan time)
        {
            if (date == null || time == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(date, time);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.patientId = new SelectList(db.Patients, "id", "name", appointment.patientId);
            ViewBag.professionalId = new SelectList(db.Professionals, "id", "name", appointment.professionalId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "date,time,patientId,professionalId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.patientId = new SelectList(db.Patients, "id", "name", appointment.patientId);
            ViewBag.professionalId = new SelectList(db.Professionals, "id", "name", appointment.professionalId);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(DateTime date, TimeSpan time)
        {
            if (date == null || time == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(date , time);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime date, TimeSpan time)
        {
            Appointment appointment = db.Appointments.Find(date, time);
            db.Appointments.Remove(appointment);
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
