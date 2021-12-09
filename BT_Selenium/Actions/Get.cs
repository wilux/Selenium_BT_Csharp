using BT_Selenium.Task;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BT_Selenium.Actions
{
    public class Get
    {
        public static string ImgSrc(IWebDriver driver, By locator)
        {
            WaitHandler.ElementIsPresent(driver, locator, 20);

            var element = driver.FindElement(By.XPath("//img[@id='_ZG1_IMGESTADOIMAGE_0001']"));
            string imageSrc = element.GetAttribute("src");

            return imageSrc;
         }

        public static string InputValue(IWebDriver driver, By locator)
        {
            try
            {
                if (WaitHandler.ElementIsPresent(driver, locator, 20) && driver.FindElement(locator).Displayed)
                {
                    IWebElement element = driver.FindElement(locator);
                    string value = element.GetAttribute("value");
                    return value;
                }
                else
                {
                    return null;
                }
            }catch { return null; }

        }

        public static string InputValue2(IWebDriver driver, By locator)
        {
            try
            {
                IWebElement element = driver.FindElement(locator);
                string value = element.GetAttribute("value");
                return value.Normalize();
            }
            catch { return null; }

        }

        public static string SpanText(IWebDriver driver, By locator)
        {
            WaitHandler.ElementIsPresent(driver, locator, 20);
            IWebElement l = driver.FindElement(locator);
            return l.Text;
        }

        public static string SelectValue(IWebDriver driver, By locator)
        {
            string valor ="";
            
            if (WaitHandler.ElementIsPresent(driver, locator, 20) && driver.FindElement(locator).Displayed)
            {
                while (true)
                {
                    try
                    {
                        valor = driver.FindElement(locator).GetAttribute("value");
                        break;
                    }
                    catch {
                        WaitHandler.ElementIsPresent(driver, locator, 20);
                        continue; 
                    }
                }
            }

            return valor;

        }

        public static string SelectValue2(IWebDriver driver, By locator)
        {
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


        public static string InputValue3(IWebDriver driver, By locator)
        {
            WaitHandler.ElementIsPresent(driver, locator, 20);
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string text = "";
            //By hiddenInputId = locator;
            if (locator == null)
                Assert.True(false, "Cannot find hiddenReportID");

            IWebElement hiddenInputIdElement = driver.FindElement(locator);
            string hiddenInputIdValue = string.Empty;
            int numberTest = 10;
            for (int i = 0; i < numberTest; i++)
            {
                hiddenInputIdElement = driver.FindElement(locator);
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
