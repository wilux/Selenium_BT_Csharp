using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BT_Selenium.Actions
{
    public class Grid
    {
        public static void SeleccionarFila(IWebDriver driver, By locator, By fila)
        {
            IWebElement webElement = driver.FindElement(locator);
            webElement.FindElement(fila).Click();
        }

    }
}
