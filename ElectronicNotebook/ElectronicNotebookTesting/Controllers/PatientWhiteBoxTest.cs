using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicNotebook.Models;
using System.Web.Mvc;
using System.Linq;
using ElectronicNotebook.Controllers;

namespace ElectronicNotebookTesting.Controllers
{
    [TestClass]
    public class PatientWhiteBoxTest
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();

        //caso de crear un paciente sin errores 
        [TestMethod]
        public void CreateNewValidPatient()
        {
            PatientController controller = new PatientController();
            Patient patient = new Patient();
            patient.id = 101110111;
            patient.name = "Prueba";
            patient.lastName1 = "Prueba";
            patient.email = "Prueba@gmail.cm";
            patient.phone = 88888888;
            ViewResult vista = controller.Create(patient) as ViewResult;
            Assert.IsNotNull(vista);
            //DeleteConfirmed(patient.id);
        }

        //caso de crear un paciente con cédula repetida
        [TestMethod]
        public void CreateInValidPatient()
        {
            PatientController controller = new PatientController();
            Patient patient = new Patient();
            patient.id = 101110111;
            patient.name = "Prueba";
            patient.lastName1 = "Prueba";
            patient.email = "Prueba@gmail.cm";
            patient.phone = 88888888;
            //inserta un nuevo paciente valido
            ViewResult vista = controller.Create(patient) as ViewResult;
            //segunda insercion invalida por que ya se encuentra en la bd
            ViewResult vista2 = controller.Create(patient) as ViewResult;
            //tienen vistas diferentes ya que al crear un paciente valido se ve en la lista de pacientes
            //al crear uno invalido devuelve a la vista de crear paciente
            Assert.AreNotEqual(vista2, vista);
        }

        //caso de crear un paciente con errores 
        [TestMethod]
        public void CreateErrorPatient()
        {
            PatientController controller = new PatientController();
            Patient patient = new Patient();
            patient.id = 101110111;
            patient.name = "Prueba";
            patient.lastName1 = "Prueba";
            patient.email = "Prueba@prueba.com";
            patient.phone = 88888888;
            ViewResult vistaValida = controller.Create(patient) as ViewResult;

            patient.id = 0000000;
            patient.name = "15151";
            patient.lastName1 = "151515";
            patient.email = "Prueba";
            patient.phone = 000;
            ViewResult vistaInvalida = controller.Create(patient) as ViewResult;

            //se comparan las vistas de una creacion valida de paciente con una con errores
            Assert.AreNotEqual(vistaValida, vistaInvalida);
        }

        [TestMethod]
        public void CorrectQuantityOfPatients()
        {
            //Arrange 
            ElectronicNotebook.Controllers.PatientController patientcontroller = new ElectronicNotebook.Controllers.PatientController();
            ViewResult result = patientcontroller.Index() as ViewResult;
            List<Patient> patients = (List<Patient>)result.ViewData.Model;
            Assert.AreEqual(db.Patients.ToList().Count, patients.Count);
        }


        public void DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

    }
}
