using BT_Selenium.Handler;
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
    public class DescartarTareaTask : BasePage
    {
        Frame frame = new Frame();

        public DescartarTareaTask(IWebDriver Driver)
        {
            driver = Driver;
        }

        public void Descartar()
        {
            Entrevista entrevista = new Entrevista(driver);
            PrincipalPage principalPage = new PrincipalPage(driver);
            BandejaTareas bandejaTareas = new BandejaTareas();
            NuevaInstancia nuevaInstancia = new NuevaInstancia();
            SimulacionProductos simulacionProductos = new SimulacionProductos();

            //Ventana Actual
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            //Pausa
            WaitHandler.ElementIsPresent(driver, principalPage.Inicio);

            //Ingreso al menu hasta -> BandejaTareas
            driver.FindElement(principalPage.Inicio).Click();
            driver.FindElement(principalPage.WF).Click();
            driver.FindElement(principalPage.BandejaTareas).Click();


            frame.BuscarFrame(driver, bandejaTareas.Grilla_Tareas);
            WaitHandler.ElementIsPresent(driver, bandejaTareas.Grilla_Tareas);

            IWebElement GRIDINBOX = driver.FindElement(bandejaTareas.Grilla_Tareas);
            String asunto = GRIDINBOX.FindElement(By.Id("span__ASUNTO_0001")).Text;

            while(asunto != "Venta de Productos" || asunto != "")
            {
                WaitHandler.ElementIsPresent(driver, bandejaTareas.PrimerTarea);

                if (asunto != "Venta de Productos")
                {
                    GRIDINBOX.FindElement(bandejaTareas.PrimerTarea).Click();
                }
                else
                {
                    GRIDINBOX.FindElement(bandejaTareas.PrimerTarea).Click();
                    driver.FindElement(bandejaTareas.BTNOPOEJECUTAR).Click();

                    //Elegimos iframe
                    frame.BuscarFrame(driver, entrevista.SelectTipo);
                    entrevista.SeleccionarByText(driver, entrevista.SelectTipo, "C.U.I.L.");

                    //Ingreso CUIL/CUIT del Cliente a entrevistar
                    driver.FindElement(entrevista.InputDocumento).SendKeys("20322717564");
                    driver.FindElement(entrevista.BTNOPVALIDAR).Click();

                    
                    frame.BuscarFrame(driver, bandejaTareas.BTNOPDESCARTAR);
                    WaitHandler.ElementIsPresent(driver, bandejaTareas.BTNOPDESCARTAR);
                    driver.FindElement(bandejaTareas.BTNOPDESCARTAR).Click();


                    frame.BuscarFrame(driver, bandejaTareas.BTNCONFIRMATION);
                    WaitHandler.ElementIsPresent(driver, bandejaTareas.BTNCONFIRMATION);
                    driver.FindElement(bandejaTareas.BTNCONFIRMATION).Click();
                }


                driver.FindElement(bandejaTareas.BTNOPOEJECUTAR).Click();
                frame.BuscarFrame(driver, bandejaTareas.BTNOPDESCARTAR);
                driver.FindElement(bandejaTareas.BTNOPDESCARTAR).Click();


                frame.BuscarFrame(driver, bandejaTareas.BTNCONFIRMATION);
                WaitHandler.ElementIsPresent(driver, bandejaTareas.BTNCONFIRMATION);
                driver.FindElement(bandejaTareas.BTNCONFIRMATION).Click();
            
                //Descartar hasta que no haya mas
            } 

        }
        }
       
}
