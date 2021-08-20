using BT_Selenium.Actions;
using OpenQA.Selenium;
using System;

namespace BT_Selenium.UI
{
    //Pantalla Agregar Documento - 
    public class AgregarDocumento
    {
        //Pantalla agregar documento
        //fecha vigencia -> 01012020
        //examinar archivo
        //confirmar

        public static void FechaVigencia(IWebDriver driver, string fecha="01012020")
        {
            Enter.Text(driver, AgregarDocumentoUI.inputFecha, fecha);

        }

        public static void ElegirArchivo(IWebDriver driver)
        {
            //The first step gets the base directory and the file
            string file = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Doc1_Test.pdf";
            //string file = @"C:\Users\floresnes\Documents\Doc1_Test.pdf";
            Enter.Text(driver, AgregarDocumentoUI.inputBuscarArchivo, file);

        }

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, AgregarDocumentoUI.BTNOPCONFIRMAR);

        }

    }
}
