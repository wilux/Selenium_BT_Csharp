using OpenQA.Selenium;
using BT_Selenium.Task;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using BT_Selenium.Tools;

namespace Bot
{
    class Browser
    {

        //Selenium Driver
        public IWebDriver driver;
        public string QaURL = "http://btwebqa.ar.bpn/BTWeb/hlogin.aspx";

        public void login()
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

            Login.In(driver, false);
        }

        public void Simular(string cuil)
        {
            IrHasta.SimularProducto(driver, cuil, "500000");

        }

        public void Salir()
        {
            try
            {

                if (driver != null)
                {
                    driver.Quit();

                }


            }
            catch (Exception e)
            {
                throw (e);
            }

            Kill.IE();
            Environment.Exit(1);
        }

    }

}
