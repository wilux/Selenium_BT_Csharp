﻿using BT_Selenium.Handler;
using BT_Selenium.PageObject;
using BT_Selenium.PageObject.WebPanel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT_Selenium.Task
{
    /*
     * Clase que lista todas las tareas para simular un prestamo persona 
     */
    public class EjecutarProgramaTask : BasePage
    {

        public EjecutarProgramaTask(IWebDriver Driver)
        {
            driver = Driver;
        }

        //Frames
        Frame frame = new Frame();

        // Instancia de Objetos
        PrincipalPage principalPage = new PrincipalPage();
        BandejaTareas bandejaTareas = new BandejaTareas();
        NuevaInstancia nuevaInstancia = new NuevaInstancia();
        Entrevista entrevista = new Entrevista();
        SimulaPrestamo simulaPrestamo = new SimulaPrestamo();

      public void Ejecutar(IWebDriver driver, string programa)
        {
            principalPage.MenuEjecutar(driver);

            //Abrir programa (Iniciar Entrevista)
            driver.FindElement(By.Id("_PROGRAMA")).SendKeys(programa);
            driver.FindElement(By.Id("BTNOPCONFIRMAR")).Click();
        }
    }
}