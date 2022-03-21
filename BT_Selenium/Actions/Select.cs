using BT_Selenium.Task;
using BT_Selenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BT_Selenium.Actions
{
    public class Select
    {
        public static void ByText(IWebDriver driver, By select, string text)
        {

            if (WaitHandler.ElementIsPresent(driver, select, 20))
            {

                while (true)
                {
                    try
                    {
                        IWebElement webElement = driver.FindElement(select);
                        SelectElement selectElement = new SelectElement(webElement);
                        selectElement.SelectByText(text);
                        break;
                    }
                    catch { continue; }
                }
            }
            
        }

        public static void ByValue(IWebDriver driver, By select, string value)
        {


            if (WaitHandler.ElementIsPresent(driver, select, 20))
            {

                while (true)
                {
                    try
                    {

                        IWebElement webElement = driver.FindElement(select);
                        SelectElement selectElement = new SelectElement(webElement);
                        selectElement.SelectByValue(value);
                        break;
                    }
                    catch { break; }
                }
            }

        }


        public static void ByValue2(IWebDriver driver, By select, string value)
        {


                    try
                    {

                        IWebElement webElement = driver.FindElement(select);
                        SelectElement selectElement = new SelectElement(webElement);
                        selectElement.SelectByValue(value);
                   
                    }
                    catch { }

        }

        public static int Cantidad(IWebDriver driver, By locator)
        {
            IList<IWebElement> selectElements = driver.FindElements(locator);
            return selectElements.Count();
        }

        public static void ByIndex(IWebDriver driver, By select, int index)
        {

            if (WaitHandler.ElementIsPresent(driver, select, 20))
            {

                while (true)
                {
                    try
                    {
                        WaitHandler.ElementIsPresent(driver, select, 20);
                        IWebElement webElement = driver.FindElement(select);
                        SelectElement selectElement = new SelectElement(webElement);
                        selectElement.SelectByIndex(index);
                        break;
                    }
                    catch { continue; }
                }
            }

        }

    }
}
