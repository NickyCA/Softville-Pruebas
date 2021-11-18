using ElectronicNotebook.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;


namespace ElectronicNotebookTesting
{
    /// <summary>
    /// Pruebas de unidad para el controlador de pacientes
    /// </summary>
    [TestClass]
    public class PatientControllerTest
    {
        [TestMethod]
        public void TestIndexNotNull()
        {
            PatientController controller = new PatientController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestIndexView()
        {
            PatientController controller = new PatientController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestCreateView()
        {
            PatientController controller = new PatientController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void TestCreateNotNull()
        {
            PatientController controller = new PatientController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDeleteNotNull()
        {
            PatientController controller = new PatientController();
            ViewResult result = controller.Delete(207770222) as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestDeleteView()
        {
            PatientController controller = new PatientController();
            ViewResult result = controller.Delete(207770222) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }

    }
}
