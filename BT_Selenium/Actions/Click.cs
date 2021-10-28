﻿using OpenQA.Selenium;
using BT_Selenium.Tools;
using System;
using NUnit.Framework;
using System.Threading;
using BT_Selenium.Task;

namespace BT_Selenium.Actions
{
    public class Click
    {
        public static void Simple(IWebDriver driver, By locator)
        {

         driver.FindElement(locator).Click();

        }


        public static void On(IWebDriver driver, By locator)
        {

            //try
            //{
            //    if (Frame.BuscarFrame(driver, locator))
            //    {
            //        if (WaitHandler.ElementIsPresent(driver, locator))
            //        {
            //            driver.FindElement(locator).Click();
            //        }
            //        else
            //        {
            //            Assert.Inconclusive("No se encotrno elemento: " + locator);
            //        }
            //    }

            //}
            //catch (Exception e)
            //{
            //    TestContext.Write(e);
            //    Thread.CurrentThread.Abort();
            //}

            if (Frame.BuscarFrame(driver, locator))
            {


                while (true)
                {
                    try
                    {
                        driver.FindElement(locator).Click();
                        break;
                    }
                    catch {
                        if (Frame.BuscarFrame(driver, locator))
                        {

                            continue;

                        }
                        else { break; }
                        }
                        
                }

            }

        }

    }
}
