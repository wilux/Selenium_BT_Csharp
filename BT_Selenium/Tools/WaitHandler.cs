using BT_Selenium.Task;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
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

            //WebPanel.Wait(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));


            try
            {


                wait.Until(e => e.FindElement(locator));

                ReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);


                if (elements.Count >= 1)
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
        public static void Wait(int segundos)
        {
            Thread.Sleep(segundos * 1000);

        }

        public static void Elemento(IWebDriver driver, By locator, int segundos=20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(segundos));
            IWebElement firstResult = wait.Until(e => e.FindElement(locator));
        }

        //Elemento esta visible
        public static bool IsVisible(IWebDriver driver, By locator)
        {
            if (Frame.BuscarFrame(driver, locator))
            {
                try
                {
                    return driver.FindElement(locator).Displayed;
                }
                catch { return false; }
                
            }
            else
            {
                return false;
            }
        }

        //Elemento esta habilitado
        public static bool IsEnable(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            return driver.FindElement(locator).Enabled;
        }


    }


}
