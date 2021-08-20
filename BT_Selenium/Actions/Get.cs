﻿using BT_Selenium.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace BT_Selenium.Actions
{
    public class Get
    {
        
        public static string SpanText(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            IWebElement l = driver.FindElement(locator);
            return l.Text;
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
