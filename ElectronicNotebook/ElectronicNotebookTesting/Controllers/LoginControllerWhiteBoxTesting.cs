
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicNotebook.Controllers;
using ElectronicNotebook.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ElectronicNotebookTesting.Controllers
{
    [TestClass]
    public class LoginControllerWhiteBoxTesting
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();

        
        [TestMethod]
        // caso en el que se ingresan usuario y contraseña correctas
         public void TestLoginCorrectUserAndPassword()
        {

            LoginController controller = new LoginController();
            Secretary secretary = CreateSecretary();
            RedirectToRouteResult result = controller.Create(secretary) as RedirectToRouteResult;

            System.Diagnostics.Debug.WriteLine("TestLoginCorrectUserAndPassword");
            //System.Diagnostics.Debug.WriteLine(result.RouteName);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        // caso en el que se intenta ingresar con usuario inexistente
        public void TestLoginIncorrectUser()
        {
            LoginController controller = new LoginController();
            Secretary secretary = CreateSecretaryForTesting(1234, "admin1234");
            ViewResult result = controller.Create(secretary) as ViewResult;

            System.Diagnostics.Debug.WriteLine("TestLoginIncorrectUser");
            System.Diagnostics.Debug.WriteLine(result.ViewName);
            
            Assert.AreEqual(result.ViewName, "Create");
            //Assert.AreNotEqual(result,result2);
            //Assert.IsNotNull(result);

        }

        [TestMethod]
        // caso en el que se intenta ingresar con usuario existente pero contraseña errónea
        public void TestLoginIncorrectPassword()
        {
            LoginController controller = new LoginController();
            Secretary secretary = CreateSecretaryForTesting(207540415, "incorrect111");
            ViewResult result = controller.Create(secretary) as ViewResult;

            System.Diagnostics.Debug.WriteLine("TestLoginIncorrectPassword");
            System.Diagnostics.Debug.WriteLine(result.ViewName);
            Assert.AreEqual(result.ViewName, "Create");
            //Assert.AreNotEqual(result.ViewName, "Index");
            //Assert.IsNull(result);

        }

        // caso en el que se ingrese usuario y contraseña ya pasados los 5 intentos fallidos

        [TestMethod]
        // caso en el que se ingresan usuario y contraseña correctas
         public void TestLoginBlockedUser()
        {
            
            LoginAttempt la = db.LoginAttempts.Find(701420987);
            
            db.LoginAttempts.Remove(la);
            db.SaveChanges();
            la.attempts = 5;
            db.LoginAttempts.Add(la);
            db.SaveChanges();

            //Intento extra despues de los 5 intentos
            LoginController controller = new LoginController();
            Secretary secretary = CreateSecretaryForTesting(701420987, "admin1234");
            ViewResult result = controller.Create(secretary) as ViewResult;

            System.Diagnostics.Debug.WriteLine("TestLoginBlockedUser");
            System.Diagnostics.Debug.WriteLine(result.ViewName);

            Assert.AreEqual(result.ViewName, "Create");
            //Assert.IsNotNull(result);


            db.LoginAttempts.Remove(la);
            db.SaveChanges();
            la.attempts = 0;
            db.LoginAttempts.Add(la);
            db.SaveChanges();

        }


        public Secretary CreateSecretary()
        {
           
            Secretary secretary = new Secretary();
            secretary.id = 207540415;
            secretary.name = "Veronica";
            secretary.lastName1 = "Hernández";
            secretary.lastName2 = "Chavarría";
            secretary.password = "admin1234";

            return secretary;
        }
        public Secretary CreateSecretaryForTesting(int userId,string pass)
        {

            Secretary secretary = new Secretary();
            secretary.id = userId;
            secretary.password = pass;

            secretary.name = "Veronica";
            secretary.lastName1 = "Hernández";
            secretary.lastName2 = "Chavarría";

            return secretary;
        }
    }
}
