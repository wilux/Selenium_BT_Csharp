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
    public class NuevaInstanciaUI 
    {
        //hxwf901 - Iniciar Instancia de Proceso
        public static By Grilla_Instancia = By.Id("GRIDPROCESOSYTAREAS");
        public static By Entrevista_Identificacion = By.Id("span__DSCTAREA_0002");
        public static By BTNOPOINICIAR = By.Id("BTNOPOINICIAR");

    }
}
