using ElectronicNotebook.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;


namespace ElectronicNotebookTesting.Controllers
{
    [TestClass]
    public class AppointmentControllerUnitTest
    {

        //Tests method for index method
        [TestMethod]
        public void TestIndexNotNull()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestIndexView()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        //Tests method por delete method
        [TestMethod] public void TestDeleteNotNull() 
        {
            AppointmentController controller = new AppointmentController(); 
            ViewResult result = controller.Delete(DateTime.Parse("2020-12-15"), TimeSpan.Parse("13:00")) as ViewResult; 
            Assert.IsNotNull(result); 
        }
        [TestMethod] public void TestDeleteView() 
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Delete(DateTime.Parse("2020-12-15"), TimeSpan.Parse("13:00")) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName); 
        }

        //Tests method for create method
        [TestMethod]
        public void TestCreateView()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TestCreateNotNull()
        {
            AppointmentController controller = new AppointmentController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

    }
}
