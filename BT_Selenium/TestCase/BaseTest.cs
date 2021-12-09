using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.IE;
using BT_Selenium.Tools;

namespace BT_Selenium.TestCase
{
    /*
     * Clase base para todos los test
     */
    [TestFixture]
    public class BaseTest
    {
        //Selenium Driver
        protected IWebDriver driver;
        protected string QaURL = "http://btwebqa.ar.bpn/BTWeb/hlogin.aspx";
        protected string DfURL = "";
        protected string ProdURL = "";


        [OneTimeSetUp]
        public void BeforeClass()
        {
            try
            {
                 _ = new InternetExplorerOptions
                {
                    EnsureCleanSession = true,
                    RequireWindowFocus = false //true
                };
                driver = new InternetExplorerDriver("C:\\webdriver\\");
                driver.Navigate().GoToUrl(QaURL);
                
            }
            catch (Exception e)
            {
                throw (e);
            }

        }


        [SetUp]
        public void BeforeTest()
        {

        }

        [TearDown]
        public void AfterTest()
        {

        }


        [OneTimeTearDown]
        public void AfterClass()
        {
            //try
            //{

            //    if (driver != null)
            //    {
            //        driver.Quit();

            //    }


            //}
            //catch (Exception e)
            //{
            //    throw (e);
            //}

            //Kill.IE();

        }

    }
}