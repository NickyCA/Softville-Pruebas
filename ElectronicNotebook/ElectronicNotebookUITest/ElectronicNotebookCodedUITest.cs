using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace ElectronicNotebookUITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class ElectronicNotebookCodedUITest
    {
        public ElectronicNotebookCodedUITest()
        {
        }

        [TestInitialize()]        
        public void MyTestInitialize()
        {            
        }

        [TestMethod]
        public void LoginPageElements()
        {
            this.UIMap.openApplicationHomePage();
            this.UIMap.existHiperLinkPaginaPrincipal();
            this.UIMap.existHiperLinkRegistrarCita();
            this.UIMap.existHiperLinkRegistrarPaciente();
            this.UIMap.existHomePageTitle();
            this.UIMap.existIdInput();
            this.UIMap.existPasswordInput();
            this.UIMap.existLogInButton();
        }

        [TestMethod]
        public void AppointmentsListElements()
        {
            this.UIMap.login();
            this.UIMap.existAppointmentTitle();
            this.UIMap.existDateColumn();
            this.UIMap.existTimeColumn();
            this.UIMap.existPacientNameColumn();
            this.UIMap.existProfessionalColumnName();

        }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
