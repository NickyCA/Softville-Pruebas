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
        
        // GET: Login/Create
        public ActionResult Create()
        {
            ViewBag.Message = "Login for secretary.";
            return View("Create");
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,password")] Secretary secretary)
        {            
            string input_password = secretary.password;
            
            System.Diagnostics.Debug.WriteLine(secretary.id);
            System.Diagnostics.Debug.WriteLine(secretary.password);


            
            
            if (ModelState.IsValid)
            {
                secretary = db.Secretaries.Find(secretary.id);

                if (secretary == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid UserName.");

                    return View("Create", secretary);
                }

                LoginAttempt la = db.LoginAttempts.Find(secretary.id);
                if (la.attempts == 5)
                {
                    ModelState.AddModelError(string.Empty, "You have reached the maximum number of login attempts");
                    return View("Create", secretary);
                }

                if (secretary.password != input_password)
                {
                    

                    ModelState.AddModelError(string.Empty, "Invalid Password.");
                    
                    db.LoginAttempts.Remove(la);
                    db.SaveChanges();
                    la.attempts++;
                    System.Diagnostics.Debug.WriteLine(la.attempts);
                    db.LoginAttempts.Add(la);
                    db.SaveChanges();
                    return View("Create", secretary);
                }
                /* if (la.attempts == 5)
                 {
                     db.LoginAttempts.Remove(la);
                     db.SaveChanges();
                     la.attempts=0;
                     System.Diagnostics.Debug.WriteLine("Si contraseña correcta");

                     System.Diagnostics.Debug.WriteLine(la.attempts);
                     db.LoginAttempts.Add(la);
                     db.SaveChanges();
                 }*/
                Session["id"] = secretary.id;
                //Session["UserId"] = user.UserId;
                return RedirectToAction("Index", "Appointment");
            }

            return View("Create", secretary);

        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["id"] = string.Empty;
            return RedirectToAction("Create", "Login");
        }
    }
}


// GET: Login
//public ActionResult Index()
//{
//    return View(db.Secretaries.ToList());
//}

//// GET: Login/Details/5
//public ActionResult Details(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    Secretary secretary = db.Secretaries.Find(id);
//    if (secretary == null)
//    {
//        return HttpNotFound();
//    }
//    return View(secretary);
//}

//// GET: Login/Edit/5
//public ActionResult Edit(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    Secretary secretary = db.Secretaries.Find(id);
//    if (secretary == null)
//    {
//        return HttpNotFound();
//    }
//    return View(secretary);
//}

//// POST: Login/Edit/5
//// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
//// más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Edit([Bind(Include = "id,name,lastName1,lastName2,password")] Secretary secretary)
//{
//    if (ModelState.IsValid)
//    {
//        db.Entry(secretary).State = EntityState.Modified;
//        db.SaveChanges();
//        return RedirectToAction("Index");
//    }
//    return View(secretary);
//}

//// GET: Login/Delete/5
//public ActionResult Delete(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    Secretary secretary = db.Secretaries.Find(id);
//    if (secretary == null)
//    {
//        return HttpNotFound();
//    }
//    return View(secretary);
//}

//// POST: Login/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public ActionResult DeleteConfirmed(int id)
//{
//    Secretary secretary = db.Secretaries.Find(id);
//    db.Secretaries.Remove(secretary);
//    db.SaveChanges();
//    return RedirectToAction("Index");
//}
