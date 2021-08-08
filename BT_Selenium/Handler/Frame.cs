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
        //Metodo que cambia al frame que contiene el elemento buscado.
        public void BuscarFrame(IWebDriver driver, By locator)
        {

            for (int i = 0; i < 6; i++)
            {
                driver.SwitchTo().DefaultContent();

                try
                {
                    driver.SwitchTo().Frame(4);
                    driver.SwitchTo().Frame("step" + i);
                    if (driver.FindElement(locator).Displayed)
                    {
                        break;
                    }

                }
                catch { }
            }



        }//Fin 

    }
}


