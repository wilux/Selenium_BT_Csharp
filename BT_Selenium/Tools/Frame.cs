using BT_Selenium.Task;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            if (FindElementIfExists(driver, locator) == null)
            {

                if (Buscar(driver, locator) == true)
                {
                    return true;
                }

                else
                {
                    if (BuscarB(driver, locator) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
               
                return true;
            }


        }

        public static IWebElement FindElementIfExists(this IWebDriver driver, By by)
        {
            IWebElement element;
            while (true)
            {
                try
                {
                    IList<IWebElement> elements = driver.FindElements(by);
                    element = (elements.Count >= 1) ? elements.First() : null;
                    break;
                }
                catch { continue; }
            }

            return element;
        }



        //Metodo que cambia al frame que contiene el elemento buscado.
        public static bool Buscar(IWebDriver driver, By locator)
        {
            int cantidad = CantidadFrames(driver);

            for (int i = 0; i < cantidad + 1; i++)
            {
                // driver.SwitchTo().DefaultContent();

                try
                {
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame(4);
                    driver.SwitchTo().Frame("step" + i);
                    if (FindElementIfExists(driver, locator) != null && driver.FindElement(locator).Displayed)
                    {
                        //string frameActual = FrameActual(driver);
                        return true;


                    }

                }
                catch { continue; }
            }


            return false;

        }//Fin 


        public static bool BuscarB(IWebDriver driver, By locator)
        {
            int cantidad = CantidadFrames(driver);
           // string frameActual = FrameActual(driver);
            for (int i = 0; i < cantidad + 1; i++)
            {
           
                try
                {
                    driver.SwitchTo().DefaultContent();
                    IWebElement iframe = driver.FindElement(By.Id("0"));
                    driver.SwitchTo().Frame(iframe);
                    driver.SwitchTo().Frame("step" + i);
                    if (FindElementIfExists(driver, locator) != null)
                    {
                        //string frameActual = FrameActual(driver);
                        return true;


                    }
                    else
                    {

                        driver.SwitchTo().ParentFrame();
                        driver.SwitchTo().Frame("step" + i);
                    }

                }
                catch { continue; }
            }


            return false;

        }//Fin 

    }
}


