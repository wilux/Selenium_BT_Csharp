using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            driver = new InternetExplorerDriver("C:\\webdriver\\");
            driver.Navigate().GoToUrl("http://btwebqa.ar.bpn/BTWeb/hlogin.aspx");
            driver.Manage().Window.Maximize();
            
        }
        [TearDown]
        public void AfterBaseTest()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
