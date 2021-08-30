using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;

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
        private bool stop;

        [SetUp]
        public void BeforeBaseTest()
        {

            if (stop)
            {
                try
                {
                    Assert.Inconclusive("Un test anterior falló.");
                }
                catch { }
            }

            //_ = new InternetExplorerOptions
            //{

            //    EnsureCleanSession = true,
            //    RequireWindowFocus = true
            //};
            //Local
            //driver = new InternetExplorerDriver("C:\\webdriver\\");
            //Remote
            InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions{
                //EnsureCleanSession = true,
                RequireWindowFocus = true
            };
            //3
            driver = new RemoteWebDriver(new Uri("http://192.168.23.16:4444/wd/hub"), internetExplorerOptions);
            //4
            //driver = new RemoteWebDriver(new Uri("http://192.168.23.16:4444/"), internetExplorerOptions);


            driver.Navigate().GoToUrl(QaURL);
            driver.Manage().Window.Maximize();
            Login.In(driver);
            
            //driver.SwitchTo().Window(driver.WindowHandles[1]);
            //driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Window.Maximize();



        }
        [TearDown]
        public void AfterBaseTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                stop = true;
                //Reporte.Logger(test + "Nro Entrevista: " + nroEntrevista);
                //if (driver != null)
                //{
                //    driver.Quit();

                //}
            }

            if (driver != null)
            {
                driver.Quit();
                //Console.WriteLine("FIN");
            }
        }
    }
}
