using OpenQA.Selenium;
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
            //    if (WaitHandler.ElementIsPresent(driver, locator, 10))
            //    {
            //        driver.FindElement(locator).Click();
            //    }
            //    else
            //    {
            //        Console.WriteLine("No se encontro: " + locator);
            //    }

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

            //if (Frame.BuscarFrame(driver, locator))
           if (WaitHandler.ElementIsPresent(driver, locator))
            {
                while (true)
                {
                   // Thread.Sleep(2000);
                    try
                    {
                        driver.FindElement(locator).Click();
                        break;

                    }
                    catch { continue; }
                }

            }
            else
            {
                Assert.Inconclusive("No se encontro frame para elemento: " + locator);
            }

        }

    }
}
