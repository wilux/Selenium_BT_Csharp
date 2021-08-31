using OpenQA.Selenium;
using System;

namespace BT_Selenium.Tools
{
    /*
     * Clase para manejar las esperas explicitas
     */
    public class Capturar
    {

        //Capture
        //capture screenshot along file name

        public static void Pantalla(IWebDriver driver, string pantalla, string cuil) 
        { 
       Credenciales credenciales = new Credenciales();

            
            string fileName = $"C:\\Users\\{credenciales.usuario}\\Pictures\\" + cuil+"_"+ DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() +"_"+ pantalla + "_" +".jpg";

            ((ITakesScreenshot)driver)
                .GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
        }

    }
}
