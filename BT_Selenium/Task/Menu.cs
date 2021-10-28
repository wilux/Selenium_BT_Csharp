using BT_Selenium.Actions;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace BT_Selenium.Task
{
    public class Menu
    {
        
        public static void Ejecutar(IWebDriver driver)
        {
            if (WaitHandler.SwichToWindowsUrl(driver))
            {
                Click.Simple(driver, HomeUI.Accesos);
                WaitHandler.Wait(1);
                Click.Simple(driver, HomeUI.Ejecutar);
            }
            else
            {
                Console.WriteLine(driver.Url);
            }


        }

        public static void Inicio(IWebDriver driver)
        {
             while (true)
             {
                     try
                  {
                      Click.Simple(driver, HomeUI.Inicio);
                         break;
                       }
                      catch
                      {
                       driver.SwitchTo().Window(driver.WindowHandles[0]);
                      driver.Manage().Window.Maximize();
                    continue;
                      }
                }
        }

        public static void WorkFlow(IWebDriver driver)
        {
            Click.Simple(driver, HomeUI.WF);
        }

        public static void BandejaTareas(IWebDriver driver)
        {
            Click.Simple(driver, HomeUI.BandejaTareas);
        }
    }
}
