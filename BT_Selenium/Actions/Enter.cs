using BT_Selenium.Tools;
using OpenQA.Selenium;

namespace BT_Selenium.Actions
{
    public class Enter
    {
        public static void Text(IWebDriver driver, By locator, string text)
        {
            // Frame.BuscarFrame(driver, locator);
            //driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }
    }
}
