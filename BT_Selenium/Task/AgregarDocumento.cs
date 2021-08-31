using BT_Selenium.Actions;
using BT_Selenium.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace BT_Selenium.UI
{
    //Pantalla Agregar Documento - 
    public class AgregarDocumento
    {
        //Pantalla agregar documento
        //fecha vigencia -> 01012020
        //examinar archivo
        //confirmar
        //public static bool Auto(IWebDriver driver)
        //{
        //    var texto_buscado = "Incompleto";
        //    IWebElement elemento = driver.FindElement(By.XPath("//span[contains(text(),\"" + texto_buscado + "\")]"));
        //    while (true)
        //    {
        //        if (elemento.Displayed)
        //        {
        //            IList<IWebElement> incompletos = new List<IWebElement>();
                    
        //           incompletos.Add(driver.FindElement(By.XPath("//span[contains(text(),\"" + texto_buscado + "\")]")));
        //            foreach (var e in incompletos)
        //            {

        //                e.Click();
        //                return true;
        //            }
        //            break;

        //        }
        //        else
        //        {
        //            return false;
        //        }
                
        //    }
        //    return true;
        //}
        public static void Auto(IWebDriver driver, string circuito = "BE")
        {
  
            int cantidad = 11;

            if (circuito != "BE")
            {
                cantidad = 1;
            }

            for (var i = 1; i < cantidad; i++)
            {
                
                if (i < 10)
                {
                    WaitHandler.Wait(driver, 2);
                    Documentacion.SeleccionarFila(driver, "0" + i.ToString());
                    Documentacion.Agregar(driver);
                }
                else
                {
                    Documentacion.SeleccionarFila(driver, i.ToString());
                   // WaitHandler.Wait(2000);
                    Documentacion.Agregar(driver);
                }
                AgregarDocumento.ElegirArchivo(driver);
                AgregarDocumento.FechaVigencia(driver);
                AgregarDocumento.Confirmar(driver);
                //WaitHandler.Wait(5000);
            }

        }
        public static void FechaVigencia(IWebDriver driver, string fecha="01012020")
        {
            WaitHandler.Wait(driver, 3);
            Frame.BuscarFrame(driver, AgregarDocumentoUI.inputFecha);
            Enter.Text(driver, AgregarDocumentoUI.inputFecha, fecha);

        }

        public static void ElegirArchivo(IWebDriver driver)
        {
            //The first step gets the base directory and the file
            //string file = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Doc1_Test.pdf";
            Credenciales credenciales = new Credenciales();

            string file = $"C:\\Users\\{credenciales.usuario}\\Documents\\Doc1_Test.pdf";
                Frame.BuscarFrame(driver, AgregarDocumentoUI.inputBuscarArchivo);
                Enter.Text(driver, AgregarDocumentoUI.inputBuscarArchivo, file);

        }

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, AgregarDocumentoUI.BTNOPCONFIRMAR);

        }

    }
}
