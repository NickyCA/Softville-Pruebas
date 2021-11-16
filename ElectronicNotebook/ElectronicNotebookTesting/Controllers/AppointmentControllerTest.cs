using ElectronicNotebook.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;


namespace ElectronicNotebookTesting.Controllers
{
    [TestClass]
    public class AppointmentControllerTest
    {
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
    }
}
