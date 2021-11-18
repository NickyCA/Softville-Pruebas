using ElectronicNotebook.Controllers;
using ElectronicNotebook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ElectronicNotebookTesting.Controllers
{
    [TestClass]
    public class PatientControllerIntegrationTest
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();

        [TestMethod]
        public void CreateNewValidPatient ()
        {
            PatientController controller = new PatientController();
            Patient patient = new Patient();
            patient.id = 705470144;
            patient.name = "Carlos";
            patient.lastName1 = "Alvarado";
            patient.email = "carAl@gmail.cm";
            patient.phone = 25698744 ;
            ViewResult result = controller.Create(patient) as ViewResult;
            Assert.AreEqual("Index", controller.Create(patient));
            DeleteConfirmed(patient.id);
        }

        [TestMethod]
        public void CreateInValidPatient()
        {
            PatientController controller = new PatientController();
            Patient patient = new Patient();
            patient.id = 305550333;
            patient.name = "Carolina";
            patient.lastName1 = "Sanchez";
            patient.email = "caro@gmail.cm";
            patient.phone = 74142525;
            ViewResult result = controller.Create(patient) as ViewResult;
            RedirectToRouteResult vista = controller.Create(patient) as
            RedirectToRouteResult;

            //Assert 
            Assert.AreEqual("Index", vista.RouteValues["action"]);
        }
        /*
        [TestMethod]
        public void CorrectQuantityOfPatients()
        {
            //Arrange 
            PatientController patientcontroller = new PatientController();
            ViewResult result = patientcontroller.Index() as ViewResult;
            List<Patient> patients = (List<Patient>)result.ViewData.Model;
            Assert.AreEqual(7, patients.Count);
        }
        */

        public void DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

    }
}
