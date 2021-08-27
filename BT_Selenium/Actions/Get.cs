using BT_Selenium.Tools;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace BT_Selenium.Actions
{
    public class Get
    {
        public static string ImgSrc(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);

            var element = driver.FindElement(By.XPath("//img[@id='_ZG1_IMGESTADOIMAGE_0001']"));
            string imageSrc = element.GetAttribute("src");

            return imageSrc;
         }

        public static string SpanText(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            IWebElement l = driver.FindElement(locator);
            return l.Text;
        }

        public static string SelectValue(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            return driver.FindElement(locator).GetAttribute("value");
        }

        public static bool SelectElementContainsItemText(IWebDriver driver, By locator, string itemText)
        {
            IWebElement Options = driver.FindElement(locator);
            SelectElement selElem = new SelectElement(Options);

            bool found = false;

            for (int i = 0; i < selElem.Options.Count; i++)
            {
                var blah = selElem.Options[i].Text;
                if (selElem.Options[i].Text.Equals(itemText))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }


        public static string InputValue(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string text = "";
            By hiddenInputId = locator;
            if (hiddenInputId == null)
                Assert.True(false, "Cannot find hiddenReportID");

            IWebElement hiddenInputIdElement = driver.FindElement(hiddenInputId);
            string hiddenInputIdValue = string.Empty;
            int numberTest = 10;
            for (int i = 0; i < numberTest; i++)
            {
                hiddenInputIdElement = driver.FindElement(hiddenInputId);
                hiddenInputIdValue = hiddenInputIdElement.GetAttribute("value");
                text = (string)jsExecutor.ExecuteScript("return arguments[0].value", hiddenInputIdElement);
                if (string.IsNullOrEmpty(hiddenInputIdValue))
                    Thread.Sleep(200);
                else
                    break;
            }

            return text;

        }

    }
}
