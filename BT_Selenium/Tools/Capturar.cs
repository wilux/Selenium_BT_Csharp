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
            string fileName = @"C:\\Users\\floresnes\\Pictures\\" +cuil+"_"+ DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() +"_"+ pantalla + "_" +".jpg";

            ((ITakesScreenshot)driver)
                .GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
        }

    }
}
