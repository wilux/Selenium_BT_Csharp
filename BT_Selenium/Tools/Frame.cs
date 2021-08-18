using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
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
     
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            object frames = jsExecutor.ExecuteScript("return window.length");
            int cantidad = Convert.ToInt32(frames);

            if (cantidad == 0)
            {
                driver.SwitchTo().DefaultContent();
                IWebElement iframe = driver.FindElement(By.Id("0"));
                driver.SwitchTo().Frame(iframe);
                frames = jsExecutor.ExecuteScript("return window.length");
                cantidad = Convert.ToInt32(frames);

            }

            return cantidad;

        }

        public static bool BuscarFrame(IWebDriver driver, By locator)
        {

           // BuscarA(driver, locator);

            if (BuscarA(driver, locator) == true)
            {
                return true;
            }
            //else if (BuscarB(driver, locator) == true)
            //{
            //    return true;
            //}
            //else if (BuscarC(driver, locator) == true)
            //{
            //    return true;

            //}
            else
            {
                return false;
            }


        }

        public static IWebElement FindElementIfExists(this IWebDriver driver, By by)
        {
            var elements = driver.FindElements(by);
            return (elements.Count >= 1) ? elements.First() : null;
        }



        //Metodo que cambia al frame que contiene el elemento buscado.
        public static bool BuscarA(IWebDriver driver, By locator)
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
                    if (FindElementIfExists(driver, locator) != null)
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

            for (int i = 0; i < cantidad; i++)
            {


                try
                {
                    driver.SwitchTo().ParentFrame();

                    driver.SwitchTo().Frame("step" + i);

                    if (driver.FindElement(locator).Displayed)
                    {
                        // string frameActual = FrameActual(driver);
                        return true;


                    }

                }
                catch { continue; }
            }

            return false;
        }//Fin 


        public static bool BuscarC(IWebDriver driver, By locator)
        {
            int cantidad = CantidadFrames(driver);

            for (int i = 0; i < cantidad; i++)
            {


                try
                {
                    driver.SwitchTo().DefaultContent();
                    IWebElement iframe = driver.FindElement(By.Id("0"));
                    driver.SwitchTo().Frame(iframe);

                    //Pasamos al Frame step1

                    driver.SwitchTo().Frame("step" + i);

                    //if (driver.FindElement(locator).Displayed)
                    if (driver.FindElement(locator).Displayed)
                    {
                        string frameActual = FrameActual(driver);
                        return true;


                    }

                }
                catch { continue; }
            }

            return false;
        }//Fin 



    }
}


