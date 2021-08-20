using OpenQA.Selenium;
using BT_Selenium.Tools;


namespace BT_Selenium.Actions
{
    public class Clear
    {
        public static void On(IWebDriver driver, By locator)
        {
            //Frame.BuscarFrame(driver, locator);
            driver.FindElement(locator).Clear();
        }

    }
}
