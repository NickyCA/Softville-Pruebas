using ElectronicNotebook.Controllers;
using ElectronicNotebook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ElectronicNotebookTesting.Controllers
{
    [TestClass]
    public class AppointmentControllerWhiteBox
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();

        //Tests method for index method
        [TestMethod]
        public void TestIndexViewData()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Index() as ViewResult;
            List<Appointment> appointments = (List<Appointment>)result.ViewData.Model; 
            Assert.AreEqual(6 , appointments.Count);
        }

        [TestMethod]
        // caso en el que se intenta registrar una cita en un slot ocupado (ya hay una registrada en esa fecha y hora)
        public void TestCreateUnavailableDateTime()
        {
            AppointmentController controller = new AppointmentController();          
            Appointment appointment = CreateAppointment(DateTime.Parse("2020-12-15"), TimeSpan.Parse("07:50"));
            ViewResult result = controller.Create(appointment) as ViewResult;
            Assert.IsNotNull(result);
           
        }

        [TestMethod]
        // caso en el que se intenta registrar una cita a una hora fuera del horario laboral
        public void TestCreateInNonWorkHours()
        {
            AppointmentController controller = new AppointmentController();
            Appointment appointment = CreateAppointment(DateTime.Parse("2020-12-15"), TimeSpan.Parse("3:50"));
            ViewResult result = controller.Create(appointment) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        // caso en el que se intenta registrar una cita a una hora escrita en un formato incorrecto
        public void TestCreateInvalidTimeFormat()
        {
            AppointmentController controller = new AppointmentController();
            Appointment appointment = CreateAppointment(DateTime.Parse("2020-12-15"), TimeSpan.Parse("350"));
            ViewResult result = controller.Create(appointment) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        // caso en el que se intenta registrar una cita valida
        public void TestCreateValidAppointment()
        {
            AppointmentController controller = new AppointmentController();
            Appointment appointment = CreateAppointment(DateTime.Parse("2020-12-15"), TimeSpan.Parse("15:24"));

            ViewResult result = controller.Create(appointment) as ViewResult;
            ViewResult result2 = controller.Create(appointment) as ViewResult; //se intenta registrar la misma cita (invalido)
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, result2); //tienen vistas diferentes ya que al crear una lista valida se ve en la lista de citas
        }


        public Appointment CreateAppointment(DateTime date, TimeSpan time) {
            Appointment appointment = new Appointment();
            appointment.date = date;
            appointment.time = time;
            appointment.patientId = 101110122;
            appointment.professionalId = 101110111;

            return appointment;
        }

        [TestMethod]
        public void TestDeleteWrongAppointment()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Delete(DateTime.Parse("2013-12-15"), TimeSpan.Parse("13:00")) as ViewResult;
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestDeleteNotNull()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Delete(DateTime.Parse("2020-12-15"), TimeSpan.Parse("07:50")) as ViewResult;
            Assert.IsNotNull(result);
        }

 
        [TestMethod]
        public void TestDeleteView()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Delete(DateTime.Parse("2020-12-15"), TimeSpan.Parse("07:00")) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }

    }
}
