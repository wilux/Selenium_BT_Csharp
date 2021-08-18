using OpenQA.Selenium;
using BT_Selenium.Tools;


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
            //Frame.BuscarFrame(driver, locator);
            if(Frame.BuscarFrame(driver, locator))
            {
                driver.FindElement(locator).Click();
            }
            else
            {
                if (driver != null)
                {
                    driver.Quit();
                    //Console.WriteLine("FIN");
                }
            }

        }

    }
}
