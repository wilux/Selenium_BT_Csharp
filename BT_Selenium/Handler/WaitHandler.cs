using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT_Selenium.Handler
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
            catch (Exception e)
            {
                Reporte.Logger(e.Message+" para: "+locator);
                Console.WriteLine("No se encontro el elemento: " + locator);
            }
            return false;
        }
        //Esperar un tiempo arbitrario
        public static void Wait(IWebDriver driver, int miliseconds, int maxTimeOutSeconds = 60)
        {

            Thread.Sleep(miliseconds);
        }
    }


}
