using BT_Selenium.Actions;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;

namespace BT_Selenium.Task
{
    public class Menu
    {
        
        public static void Ejecutar(IWebDriver driver)
        {
            Click.Simple(driver, HomeUI.Ejecutar);

        }

        public static void Inicio(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles[1]);
            }
            catch
            {
                Login.In(driver);
                
            }
            try
            {
                WaitHandler.Elemento(driver, HomeUI.Logo);
            }
            catch
            {
                Kill.IE();
                Thread.CurrentThread.Abort();
            }
                driver.Manage().Window.Maximize();
                Click.Simple(driver, HomeUI.Inicio);
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
