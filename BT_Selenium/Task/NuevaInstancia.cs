using BT_Selenium.Actions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.UI
{
    /*
     * Clase que representa el webpanel hxwf901 - Iniciar Instancia de Proceso
     */
    public class NuevaInstancia
    {
        public static void Entrevista(IWebDriver driver)
        {
            //Elegimos Instancia
            Click.On(driver, NuevaInstanciaUI.Entrevista_Identificacion);
            Click.On(driver, NuevaInstanciaUI.BTNOPOINICIAR);
        }

    }
}
