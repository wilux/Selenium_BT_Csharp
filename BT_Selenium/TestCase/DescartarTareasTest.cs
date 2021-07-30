using BT_Selenium.PageObject;
using BT_Selenium.Task;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.TestCase
{
    //[TestFixture]
    public class DescartarTareaTest : BaseTest
    {
     
        [Test]
        public void Descartar()
        {
            //Login
            LoginPage loginPage = new LoginPage(driver);
            PrincipalPage principalPage = loginPage.IngresarComo("floresnes", "Enilde2021");
            //Tareas
            DescartarTareaTask descartarTareaTask = new DescartarTareaTask(driver);
            descartarTareaTask.Descartar();

        }

    }
}
