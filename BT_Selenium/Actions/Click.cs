using OpenQA.Selenium;
using BT_Selenium.Tools;
using System;
using NUnit.Framework;
using System.Threading;
using BT_Selenium.Task;
using System.Diagnostics;

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
            try { driver.FindElement(locator).Click(); }
            catch
            {

                if (WaitHandler.ElementIsPresent(driver, locator))
                {
                    var timer = new Stopwatch();
                    int tiempo = 10;
                    timer.Start();
                    TimeSpan timeTaken = timer.Elapsed;
                    int segundosTranscurridos = (int)(timeTaken.TotalSeconds);

                    while (segundosTranscurridos <= tiempo)
                    {


                        try
                        {
                            driver.FindElement(locator).Click();
                            timer.Stop();
                            break;

                        }
                        catch { continue; }
                    }

                }
                else


                {

                    Console.WriteLine("No se encontro elemento: " + locator);

                }



            }

        }
    }
}
