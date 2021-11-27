using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ElectronicNotebook.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using ElectronicNotebook.Models;


namespace ElectronicNotebookTesting.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void TestCreateNotNull()
        {
            LoginController controller = new LoginController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod] 
        public void TestCreateView() { 
            var controller = new LoginController(); 
            var result = controller.Create() as ViewResult; 
            Assert.AreEqual("Create", result.ViewName); 
        }
    /*    
        [TestMethod] 
        public void AboutViewBag()
                { // Arrange
                     LoginController controller = new LoginController(); 
                    // Act
                  ViewResult result = controller.Create() as ViewResult; 
                    // Assert
                  Assert.AreEqual("Login for secretary.", result.ViewBag.Message); 
                }
        */
/*
        [TestMethod] 
        public void TestCreateDatabaseView() {
            LoginController controller = new LoginController();
            
            ViewResult result = controller.Create() as ViewResult; 
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod] 
        public void TestCreateDatabaseNotNull()
        {

            LoginController controller = new LoginController();
            //Secretary secretary = db.Secretaries.Find("207540415"); 
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
*/
    }
}
