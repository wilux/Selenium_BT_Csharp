using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
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
            try
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(e => e.FindElement(locator));
                return true;
            }
            catch
            {
                //Reporte.Logger(e.Message+" para: "+locator);
                Console.WriteLine("No se encontro el elemento: " + locator);
                return false;
            }
            
        }
        //Esperar un tiempo arbitrario
        public static void Wait(int miliseconds, int maxTimeOutSeconds = 60)
        {

            Thread.Sleep(miliseconds);
        }
    }


}
