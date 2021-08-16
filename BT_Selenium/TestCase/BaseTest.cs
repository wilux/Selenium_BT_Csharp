using NUnit.Framework;
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
            var options = new InternetExplorerOptions
            {
                EnsureCleanSession = true,
                RequireWindowFocus = true
            };
            driver = new InternetExplorerDriver("C:\\webdriver\\");
            driver.Navigate().GoToUrl(QaURL);
            driver.Manage().Window.Maximize();
            Login.In(driver);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Manage().Window.Maximize();

        }
        [TearDown]
        public void AfterBaseTest()
        {
            if (driver != null)
            {
                driver.Quit();
                //Console.WriteLine("FIN");
            }
        }
    }
}
