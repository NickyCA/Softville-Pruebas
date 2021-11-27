﻿using ElectronicNotebook.Controllers;
using ElectronicNotebook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;


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
            patient.id = 101110111;
            patient.name = "Prueba";
            patient.lastName1 = "Prueba";
            patient.email = "Prueba@gmail.cm";
            patient.phone = 11111111 ;
            ViewResult vista = controller.Create(patient) as ViewResult;
            Assert.IsNotNull(vista);
            DeleteConfirmed(patient.id);
        }

        //
        [TestMethod]
        public void CreateInValidPatient()
        {
            PatientController controller = new PatientController();
            Patient patient = new Patient();
            patient.id = 101110111;
            patient.name = "Prueba";
            patient.lastName1 = "Prueba";
            patient.email = "Prueba@gmail.cm";
            patient.phone = 11111111;
            //inserta un nuevo paciente valido
            ViewResult vista = controller.Create(patient) as ViewResult;
            //segunda insercion invalida por que ya se encuentra en la bd
            ViewResult vista2 = controller.Create(patient) as ViewResult;
            //tienen vistas diferentes ya que al crear un paciente valido se ve en la lista de pacientes
            //al crear uno invalido devuelve a la vista de crear paciente
            Assert.AreNotEqual(vista2,vista);            
            DeleteConfirmed(patient.id);
        }
       
        [TestMethod]
        public void CorrectQuantityOfPatients()
        {
            //Arrange 
            PatientController patientcontroller = new PatientController();
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
