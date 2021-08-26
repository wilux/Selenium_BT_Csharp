using OpenQA.Selenium;
using BT_Selenium.Tools;
using System;

namespace BT_Selenium.Actions
{
    public class Navegador
    {
        public static void Back(IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
                jsExecutor.ExecuteScript("history.back();");
            }
            catch { }
        }

        public static void Cerrar(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();

            }
        }

}
}
