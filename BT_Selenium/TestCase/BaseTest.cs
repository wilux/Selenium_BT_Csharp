using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

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
            //Mata procesos de IE y Driver antes de empezar.
            Kill.IE();

            _ = new InternetExplorerOptions
            {
                EnsureCleanSession = true,
                RequireWindowFocus = true
            };
            driver = new InternetExplorerDriver("C:\\webdriver\\");

            driver.Navigate().GoToUrl(QaURL);
            driver.Manage().Window.Maximize();
            Login.In(driver);


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
