using BT_Selenium.Tools;
using OpenQA.Selenium;


namespace BT_Selenium.Actions
{
    public class Get
    {
        
        public static string Text(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            IWebElement l = driver.FindElement(locator);
            return l.Text;
        }

        public static string InputValue(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            ////set the text
            //jsExecutor.ExecuteScript($"document.getElementById('{input}').value='{value}'");
            ////get the text
            //string text = (string)jsExecutor.ExecuteScript($"return document.getElementById('{input}').value");

            string text = driver.FindElement(locator).GetAttribute("value");
            return text;

        }

    }
}
