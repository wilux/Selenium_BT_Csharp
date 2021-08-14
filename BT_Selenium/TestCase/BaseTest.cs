using NUnit.Framework;
using BT_Selenium.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using BT_Selenium.Handler;
using BT_Selenium.PageObject.WebPanel;

namespace BT_Selenium.TestCase
{
    /*
     * Clase base para todos los test
     */
    public class BaseTest
    {
        //Selenium Driver
        protected IWebDriver driver;
        protected string QaURL = "http://btwebqa.ar.bpn/BTWeb/hlogin.aspx";
        protected string DfURL = "";
        protected string ProdURL = "";


        [SetUp]
        public void BeforeBaseTest()
        {
            var options = new InternetExplorerOptions();
            options.EnsureCleanSession = true;
            options.RequireWindowFocus = true;
            driver = new InternetExplorerDriver("C:\\webdriver\\");
            driver.Navigate().GoToUrl(QaURL);
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
