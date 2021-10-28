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

        public static void Backspace(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).SendKeys(Keys.Backspace);
        }

        public static void Detelete(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).SendKeys(Keys.Delete);
        }

        public static void F5(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//body")).SendKeys(Keys.F5);
        }

        public static void Tab(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            driver.FindElement(locator).SendKeys(Keys.Tab);
        }

        public static void ArrowDown(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            driver.FindElement(locator).SendKeys(Keys.ArrowDown);
        }
    }
}
