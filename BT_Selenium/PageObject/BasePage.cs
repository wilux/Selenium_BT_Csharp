using BT_Selenium.Handler;
using BT_Selenium.PageObject.WebPanel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject
{
    /*
    * Clase base para todas las page
    */
    public class BasePage
    {

        //Selenium Driver
        protected IWebDriver driver;
        protected IWebElement webElement;
        protected SelectElement selectElement;



    }
}
