using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;


namespace BT_Selenium.Tools
{
    /*
     * Clase para manejar las esperas explicitas
     */
    public class WaitHandler
    {
        //Metodo para esperar por un elemento presente en la pagina web
        //Reotorna true si se encuentra el elemento en un maximo de 10 segundos, sino retorna false
        public static bool ElementIsPresent(IWebDriver driver, By locator)
        {
    
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                //  wait.Until(e => e.FindElement(locator));
          

                if (driver.FindElement(locator).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }

            
        }
        //Esperar un tiempo arbitrario
        public static void Wait(int miliseconds, int maxTimeOutSeconds = 60)
        {

            Thread.Sleep(miliseconds);
        }


    }


}
