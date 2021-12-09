using OpenQA.Selenium;
using BT_Selenium.Tools;
using System.Threading;

namespace BT_Selenium.Actions
{
    public class Clear
    {
        public static void On(IWebDriver driver, By locator)
        {

            if (WaitHandler.ElementIsPresent(driver, locator, 20))
            {
                    try
                    {
                        driver.FindElement(locator).Clear();
                    }
                    catch {}
            }
        }

    }
}
