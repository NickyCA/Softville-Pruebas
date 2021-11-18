using ElectronicNotebook.Controllers;
using ElectronicNotebook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ElectronicNotebookTesting.Controllers
{
    [TestClass]
    public class AppointmentControllerIntegrationTest
    {
        //Tests method for index method
        [TestMethod]
        public void TestIndexViewData()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Index() as ViewResult;
            List<Appointment> appointments = (List<Appointment>)result.ViewData.Model; 
            Assert.AreEqual(4 , appointments.Count);
        }
    }
}
