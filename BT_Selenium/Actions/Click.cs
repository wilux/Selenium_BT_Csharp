using OpenQA.Selenium;
using BT_Selenium.Tools;
using System;

namespace BT_Selenium.Actions
{
    public class Click
    {
        public static void Simple(IWebDriver driver, By locator)
        {
            WaitHandler.ElementIsPresent(driver, locator);
            driver.FindElement(locator).Click();
        }


        public static void On(IWebDriver driver, By locator)
        {
            try
            {
                if (Frame.BuscarFrame(driver, locator))
                {
                    driver.FindElement(locator).Click();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }

    }
}
