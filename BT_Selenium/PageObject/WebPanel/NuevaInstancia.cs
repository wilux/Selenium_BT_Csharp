using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    /*
     * Clase que representa el webpanel hxwf901 - Iniciar Instancia de Proceso
     */
    public class NuevaInstancia  : BasePage
    {
        //hxwf901 - Iniciar Instancia de Proceso
        public By Grilla_Instancia = By.Id("GRIDPROCESOSYTAREAS");
        public By Entrevista_Identificacion = By.Id("span__DSCTAREA_0002");
        public By BTNOPOINICIAR = By.Id("BTNOPOINICIAR");


        public void Fila_EntrevistaIdentificacion(IWebDriver driver)
        {
            driver.FindElement(Entrevista_Identificacion).Click();
        }

        public void BTNOPOINICIAR_Click(IWebDriver driver)
        {
            driver.FindElement(BTNOPOINICIAR).Click();
        }

    }
}
