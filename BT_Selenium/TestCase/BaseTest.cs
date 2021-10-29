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
        protected ExtentReports _extent;
        protected ExtentTest _test;
        protected string QaURL = "http://btwebqa.ar.bpn/BTWeb/hlogin.aspx";
        protected string DfURL = "";
        protected string ProdURL = "";


        [OneTimeSetUp]
        public void BeforeClass()
        {
            try
            {
                Kill.IE();

                _ = new InternetExplorerOptions
                {
                    EnsureCleanSession = true,
                    RequireWindowFocus = false //true
                };
                driver = new InternetExplorerDriver("C:\\webdriver\\");
                driver.Navigate().GoToUrl(QaURL);
                
            

                //To create report directory and add HTML report into it // _ddMMyyyy_hhmmss
                string name = TestContext.CurrentContext.Test.ClassName + DateTime.Now.ToString("_ddMMyyyy_hhmmss");
                _extent = new ExtentReports();
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                var htmlReporter = new ExtentV3HtmlReporter(dir + "\\Test_Execution_Reports\\" + name + ".html");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                _extent.AddSystemInfo("Environment", "QA");
                _extent.AddSystemInfo("User Name", "floresnes");
                _extent.AddSystemInfo("os", "Windows 11");
                _extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }

            try
            {

                //driver = new ChromeDriver();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }


        [SetUp]
        public void BeforeTest()
        {
            try
            {

                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        [TearDown]
        public void AfterTest()
        {
            try
            {

                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed: //DateTime.Now.ToString("_ddMMyyyy_hhmmss");
                        logstatus = Status.Fail;
                        string screenShotPath = Capture(driver,  DateTime.Now.ToString("_ddMMyyyy_hhmmss") + "_Fail");//TestContext.CurrentContext.Test.Name) // DateTime.Now.ToString("yyyyMMdd_hhmm_ss")
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        string screenShotPath2 = Capture(driver,  DateTime.Now.ToString("_ddMMyyyy_hhmmss") + "_Pass");
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath2));
                        break;
                }

            }
            catch (Exception e)
            {
                throw (e);
            }

        }


        [OneTimeTearDown]
        public void AfterClass()
        {
            try
            {

                _extent.Flush();

                if (driver != null)
                {
                    driver.Quit();

                }


            }
            catch (Exception e)
            {
                throw (e);
            }


        }

        private string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath;
            try
            {
                //Thread.Sleep(1000);
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Defect_Screenshots\\" + screenShotName + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }
    }
}