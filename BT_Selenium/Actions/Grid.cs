using BT_Selenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BT_Selenium.Actions
{
    public class Grid
    {
        public static void SeleccionarFila(IWebDriver driver, By locator, By fila)
        {
            Frame.BuscarFrame(driver, locator);
            IWebElement webElement = driver.FindElement(locator);
            webElement.FindElement(fila).Click();
        }

    }
}
