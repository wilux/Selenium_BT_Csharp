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
            Click.On(driver, HomeUI.Ejecutar);

        }

        public static void Inicio(IWebDriver driver)
        {

            if (WaitActions.ElementIsPresent(driver, HomeUI.Menu) == true)
            {
                Click.On(driver, HomeUI.Inicio);
            }
            else
            {
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                driver.Manage().Window.Maximize();
                WaitActions.Wait(driver, 5000);
                Click.On(driver, HomeUI.Inicio);
            }

        }

        public static void WorkFlow(IWebDriver driver)
        {
            Click.On(driver, HomeUI.WF);
        }

        public static void BandejaTareas(IWebDriver driver)
        {
            Click.On(driver, HomeUI.BandejaTareas);
        }
    }
}
