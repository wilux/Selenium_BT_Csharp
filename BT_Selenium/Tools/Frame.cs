using BT_Selenium.Task;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace BT_Selenium.Tools
{
    public static class Frame
    {


        public static string FrameActual(IWebDriver driver)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string currentFrame = (string)jsExecutor.ExecuteScript("return self.name");

            return currentFrame;
        }



        public static int CantidadFrames(IWebDriver driver)
        {
            
           
            //By finding all the web elements using iframe tag
            // List<IWebElement> iframeElements = driver.FindElements(By.TagName("iframe"));

                IList<IWebElement> iframeElements = driver.FindElements(By.TagName("iframe"));
                int cantidad = iframeElements.Count();

            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            //string frames = jsExecutor.ExecuteScript("return window.length").ToString();
            //int cantidad = Convert.ToInt32(frames);

            if (cantidad == 0)
            {
                driver.SwitchTo().DefaultContent();
                IWebElement iframe = driver.FindElement(By.Id("0"));
                driver.SwitchTo().Frame(iframe);
                //frames = jsExecutor.ExecuteScript("return window.length").ToString();
                //cantidad = Convert.ToInt32(frames);
                IList<IWebElement> iframeElements2 = driver.FindElements(By.TagName("iframe"));
                cantidad = iframeElements2.Count();

            }

            return cantidad;

        }


        public static bool BuscarFrame(IWebDriver driver, By locator)
        {
            bool estado = false;

            if (FindElementIfExists(driver, locator) != null)
            {
                return true;
            }
            else
            {

                driver.SwitchTo().DefaultContent();
                //IWebElement iframe = driver.FindElement(By.Id("0"));
                //driver.SwitchTo().Frame(iframe);
                string frameI = FrameActual(driver);
                //driver.SwitchTo().DefaultContent();
                int sizeInicial = driver.FindElements(By.TagName("iframe")).Count();
                //int sizeInicial = CantidadFrames(driver);

                for (int i = 0; i < sizeInicial; i++)
                {

                    driver.SwitchTo().Frame(i);
                    int sizeNuevo = driver.FindElements(By.TagName("iframe")).Count();
                    //int sizeNuevo = CantidadFrames(driver);
                    if (sizeNuevo != 0)
                    {
                        for (int j = 0; j < sizeNuevo; j++)
                        {
                            driver.SwitchTo().Frame(j);
                            try
                            {
                                string frameJ = FrameActual(driver);
                                driver.FindElement(locator);
                                estado = true;
                                break;
                            }
                            catch
                            {
                                driver.SwitchTo().ParentFrame();
                                continue;
                            }
                        }
                        if (estado == true) { break; } else { driver.SwitchTo().DefaultContent(); }
                    }
                    else { driver.SwitchTo().DefaultContent(); }
                }
            }

            return estado;
        }

        //public static bool BuscarFrame(IWebDriver driver, By locator)
        //{

        //    if (FindElementIfExists(driver, locator) == null)
        //    {

        //        if (Buscar(driver, locator) == true)
        //        {
        //            return true;
        //        }

        //        else
        //        {
        //            if (BuscarB(driver, locator) == true)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    else
        //    {

        //        return true;
        //    }


        //}

        public static IWebElement FindElementIfExists(this IWebDriver driver, By by)
        {
            IWebElement element = null;
            var timer = new Stopwatch();
            timer.Start();
            TimeSpan timeTaken = timer.Elapsed;
            int segundosTranscurridos = (int)(timeTaken.TotalSeconds);

            do
            {
                timeTaken = timer.Elapsed;
                segundosTranscurridos = (int)(timeTaken.TotalSeconds);

                try
                {
                    IList<IWebElement> elements = driver.FindElements(by);
                    element = (elements.Count >= 1) ? elements.First() : null;
                    break;
                }
                catch { continue; }

            } while (segundosTranscurridos >= 60);

            return element;
        }



        //Metodo que cambia al frame que contiene el elemento buscado.
        //public static bool Buscar(IWebDriver driver, By locator)
        //{
        //    int cantidad = CantidadFrames(driver);

        //    for (int i = 0; i < cantidad + 50; i++)
        //    {
        //        // driver.SwitchTo().DefaultContent();

        //        try
        //        {
        //            driver.SwitchTo().DefaultContent();
        //            driver.SwitchTo().Frame(4);
        //            driver.SwitchTo().Frame("step" + i);
        //            if (FindElementIfExists(driver, locator) != null )//&& driver.FindElement(locator).Displayed)
        //            {
        //                //string frameActual = FrameActual(driver);
        //                return true;


        //            }

        //        }
        //        catch { continue; }
        //    }


        //    return false;

        //}//Fin 


        //public static bool BuscarB(IWebDriver driver, By locator)
        //{
        //    int cantidad = CantidadFrames(driver);
        //   // string frameActual = FrameActual(driver);
        //    for (int i = 0; i < cantidad + 1; i++)
        //    {
           
        //        try
        //        {
        //            driver.SwitchTo().DefaultContent();
        //            IWebElement iframe = driver.FindElement(By.Id("0"));
        //            driver.SwitchTo().Frame(iframe);
        //            driver.SwitchTo().Frame("step" + i);
        //            if (FindElementIfExists(driver, locator) != null)
        //            {
        //                //string frameActual = FrameActual(driver);
        //                return true;


        //            }
        //            else
        //            {

        //                driver.SwitchTo().ParentFrame();
        //                driver.SwitchTo().Frame("step" + i);
        //            }

        //        }
        //        catch { continue; }
        //    }


        //    return false;

        //}//Fin 

    }
}


