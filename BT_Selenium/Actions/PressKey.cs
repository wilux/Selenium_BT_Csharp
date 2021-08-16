using BT_Selenium.Tools;
using OpenQA.Selenium;

namespace BT_Selenium.Actions
{
    public class PressKey
    {
        public static void Return(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            driver.FindElement(locator).SendKeys(Keys.Return);
        }
    }
}
