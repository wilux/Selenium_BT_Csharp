using BT_Selenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BT_Selenium.Actions
{
    public class Enter
    {
        public static void Text(IWebDriver driver, By locator, string text)
        {

           driver.FindElement(locator).SendKeys(text);
        }


        public static void JSTextById(IWebDriver driver, string locator, string text)
        {
  
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript($"document.getElementById('{locator}').value='{text}';");

        }


        public static void JSTextByName(IWebDriver driver, string locator, string text)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript($"document.getElementsByName('{locator}').value='{text}';");

        }

    }
}
