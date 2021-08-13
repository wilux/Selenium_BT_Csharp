using NUnit.Framework;
using BT_Selenium.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT_Selenium.Handler;
using BT_Selenium.PageObject.WebPanel;

namespace BT_Selenium.TestCase
{
    /*
     * Clase base para todos los test
     */
    public abstract class BaseTest
    {
        //Selenium Driver
        protected IWebDriver driver;

               
        [SetUp]
        public void BeforeBaseTest()
        {
            var options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            options.RequireWindowFocus = true;
            driver = new InternetExplorerDriver("C:\\webdriver\\");
            driver.Navigate().GoToUrl("http://btwebqa.ar.bpn/BTWeb/hlogin.aspx");
            driver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Ingresar();

        }
        [TearDown]
        public void AfterBaseTest()
        {
            if (driver != null)
            {

                //Capturar.Pantalla(driver, "Fin", "000000000");
                //driver.Close();
                driver.Quit();
                //Console.WriteLine("FIN");
            }
        }
    }
}
