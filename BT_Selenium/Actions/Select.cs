using BT_Selenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BT_Selenium.Actions
{
    public class Select
    {
        public static void ByText(IWebDriver driver, By select, string text)
        {
            Frame.BuscarFrame(driver, select);
            IWebElement webElement = driver.FindElement(select);
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }

        public static void ByValue(IWebDriver driver, By select, string value)
        {
            Frame.BuscarFrame(driver, select);
            IWebElement webElement = driver.FindElement(select);
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(value);
        }

        public static void ByIndex(IWebDriver driver, By select, int index)
        {
            Frame.BuscarFrame(driver, select);
            IWebElement webElement = driver.FindElement(select);
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByIndex(index);
        }

    }
}
