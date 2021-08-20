using BT_Selenium.Actions;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;

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


            if (WaitHandler.ElementIsPresent(driver, HomeUI.Inicio) == true)
            {

                Click.Simple(driver, HomeUI.Inicio);
            }
            else
            {
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                driver.Manage().Window.Maximize();
                WaitHandler.Wait(5000);
                Click.Simple(driver, HomeUI.Inicio);
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
