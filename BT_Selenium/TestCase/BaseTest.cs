using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Diagnostics;
using System.Windows.Forms;

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
            //IEDriverServer.exe
            //iexplore.exe
            if (Process.GetProcessesByName("iexplore").Length > 0 )
            {
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("iexplore"))
                    {
                        proc.Kill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (Process.GetProcessesByName("IEDriverServer").Length > 0)
            {
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("IEDriverServer"))
                    {
                        proc.Kill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            _ = new InternetExplorerOptions
            {
                EnsureCleanSession = true,
                RequireWindowFocus = true
            };
            driver = new InternetExplorerDriver("C:\\webdriver\\");
            driver.Navigate().GoToUrl(QaURL);
            driver.Manage().Window.Maximize();
            Login.In(driver);
            WaitHandler.Wait(7000);
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
