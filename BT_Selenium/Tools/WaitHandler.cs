using BT_Selenium.Task;
using BT_Selenium.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;


namespace BT_Selenium.Tools
{
    /*
     * Clase para manejar las esperas explicitas
     */
    public class WaitHandler
    {

        public static void Cartel(IWebDriver driver)
        {

            //Cargando...
            driver.SwitchTo().DefaultContent();
            IWebElement iframe = driver.FindElement(By.Id("0"));
            driver.SwitchTo().Frame(iframe);
            bool frameCartel = driver.FindElement(WebPanelGenericoUI.Cargando).Displayed;

            while (frameCartel)
            {
                continue;
            }
        }

        //Metodo para esperar por un elemento presente en la pagina web
        //Reotorna true si se encuentra el elemento en un maximo de 10 segundos, sino retorna false
        public static bool ElementIsPresent(IWebDriver driver, By locator, int tiempo = 20)
        {
            // Cartel(driver);

            var timer = new Stopwatch();
            timer.Start();

            bool estado;
            while (true)
            {

                TimeSpan timeTaken = timer.Elapsed;
                int segundosTranscurridos = (int)(timeTaken.TotalSeconds);

                if (segundosTranscurridos >= tiempo)
                {
                    timer.Stop();
                    estado = false;
                    break;
                }

                try
                {

                    var elements = driver.FindElements(locator);
                    if (elements.Count >= 1)
                    //if (Frame.BuscarFrame(driver, locator))
                    {
                        timer.Stop();
                        estado = true;
                        break;
                    }
                    else
                    {
                        if (Frame.BuscarFrame(driver, locator))
                        {
                            timer.Stop();
                            estado = true;
                            break;
                        }

                    }
                }
                catch { continue; }
            }

            return   estado;

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


        public  static bool SwichToWindowsUrl(IWebDriver driver, String url= "http://btwebqa.ar.bpn/BTWeb/realIndex.html")
        {
            String currentURL = "";
            int sizeWindows = driver.WindowHandles.Count;

            for (int i = 0; i <= sizeWindows; i++)
            {
                currentURL = driver.Url;
                if (currentURL == url)
                {
                    return true;
                }
                else
                {
                    try
                    {
                        driver.SwitchTo().Window(driver.WindowHandles[i]);
                    }
                    catch { continue; }
                    
                }
                
            }
            return false;
        }


    }


}
