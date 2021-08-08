using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    /*
     * Clase que representa el webpanel hxwf900 - Bandeja de Entrada de Tareas
     */
    public class BandejaTareas  : BasePage 
    {
        public By Grilla_Tareas = By.Id("GRIDINBOX");
        public By PrimerTarea = By.Id("span__IDINSTANCIA_0001");
        public By SegundaTarea = By.Id("span__IDINSTANCIA_0002");
        public By PrimerAsunto = By.Id("span__ASUNTO_0001");
        public By BTNOPOSIGUIENTE = By.Id("BTNOPOSIGUIENTE");
        public By BTNCONFIRMATION = By.Id("BTNCONFIRMATION");
        public By BTNOPOEJECUTAR = By.Id("BTNOPOEJECUTAR");
        public By BTNOPDESCARTAR = By.Id("BTNOPDESCARTAR");
        public By BTNOPOINICIAR = By.Id("BTNOPOINICIAR");
        public By BTNOPOTOMAR = By.Id("BTNOPOTOMAR");

        // driver.FindElement(bandejaTareas.BTNOPOINICIAR).Click();
        public void BTNOPOINICIAR_Click(IWebDriver driver)
        {
            driver.FindElement(BTNOPOINICIAR).Click();
        }
    }
}
