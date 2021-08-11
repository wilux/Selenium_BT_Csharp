using BT_Selenium.PageObject;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace BT_Selenium.Handler
{
    public class Frame
    {

        //Metodo que devuelve el frame actual en el que estoy
        public String FrameActual(IWebDriver driver)
        {



            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            String currentFrame = (String)jsExecutor.ExecuteScript("return self.name");

            return currentFrame;

        }

        public bool BuscarFrame(IWebDriver driver, By locator)
        {


            if (BuscarA(driver, locator) == true)
            {
                return true;
            }
            else if (BuscarB(driver, locator) == true)
            {
                return true;
            }
            else if (BuscarC(driver, locator) == true)
            {
                return true;

            }
            else
            {
                return false;
            }


        }



        //Metodo que cambia al frame que contiene el elemento buscado.
        private bool BuscarA(IWebDriver driver, By locator)
        {

            for (int i = 0; i < 6; i++)
            {
               // driver.SwitchTo().DefaultContent();

                try
                {
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame(4);
                    driver.SwitchTo().Frame("step" + i);
                     if (WaitHandler.ElementIsPresent(driver, locator))
                    {
                        string frameActual = FrameActual(driver);
                        return true;
                        
                        
                    }

                }
                catch{ continue; }
            }


            return false;

        }//Fin 



        private bool BuscarB(IWebDriver driver, By locator)
        {


            for (int i = 0; i < 6; i++)
            {
                

                try
                {
                    driver.SwitchTo().ParentFrame();

                    driver.SwitchTo().Frame("step"+i);

                    if (WaitHandler.ElementIsPresent(driver, locator))
                    {
                       // string frameActual = FrameActual(driver);
                        return true;
                       

                    }

                }
                catch { continue; }
            }

            return false;
        }//Fin 


        private bool BuscarC(IWebDriver driver, By locator)
        {


            for (int i = 0; i < 10; i++)
            {


                try
                {
                    driver.SwitchTo().DefaultContent();
                    IWebElement iframe = driver.FindElement(By.Id("0"));
                    driver.SwitchTo().Frame(iframe);

                    //Pasamos al Frame step1

                    driver.SwitchTo().Frame("step"+i);

                    //if (driver.FindElement(locator).Displayed)
                    if (WaitHandler.ElementIsPresent(driver, locator))
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


