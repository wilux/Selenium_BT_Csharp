using BT_Selenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BT_Selenium.Actions
{
    public class Grid
    {
        public static void SeleccionarFila(IWebDriver driver, By locator, By fila)
        {
            WaitHandler.ElementIsPresent(driver, locator, 20);
            while (true)
            {
                try
                {
                    WaitHandler.ElementIsPresent(driver, locator, 20);
                    IWebElement webElement = driver.FindElement(locator);
                    webElement.FindElement(fila).Click();
                    break;
                }
                catch { continue; }
            }
        }

    }
}
