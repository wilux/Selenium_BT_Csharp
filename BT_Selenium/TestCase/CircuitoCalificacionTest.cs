using BT_Selenium.PageObject;
using BT_Selenium.Task;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT_Selenium.Handler;
using System.Data.SqlClient;
using System.Data;
using BT_Selenium.PageObject.WebPanel;
using System.Threading;

namespace BT_Selenium.TestCase
{
    [TestFixture]
    public class CircuitoCalificacionTest : BaseTest
    {



        // Instancia de Objetos
        PrincipalPage principalPage = new PrincipalPage();
        Frame frame = new Frame();
        BandejaTareas bandejaTareas = new BandejaTareas();
        NuevaInstancia nuevaInstancia = new NuevaInstancia();
        Entrevista entrevista = new Entrevista();
        SimulaPrestamo simulaPrestamo = new SimulaPrestamo();

        [Test]
        public void Calificar()
        {
            //Obtengo de DB
            String cuit = DB.ObtenerCuit();
            //
            String documento = cuit; //"20322717564";
            //String ingresos = "10000";
            //String telefono = "4725555";
            //String monto = "500000";
            //String plazo = "12";


            //Tareas
            CalificarTask calificarTask = new CalificarTask(driver);


            driver.SwitchTo().Window(driver.WindowHandles[1]);
            //Pause
            WaitHandler.ElementIsPresent(driver, principalPage.Menu);

            //Menu ir a...Inicio>WF>BandejaTarea
            principalPage.MenuInicio(driver);
            principalPage.MenuWorkFlow(driver);
            principalPage.MenuBandejaTareas(driver);

            //WebPanel  hxwf900 - Bandeja de tareas
            //Iniciamos Nueva Tarea en Bandeja de tareas

            //Elegimos iframe
            frame.BuscarFrame(driver, bandejaTareas.BTNOPOINICIAR);
            WaitHandler.ElementIsPresent(driver, bandejaTareas.BTNOPOINICIAR);

            //Iniciar instancia
            driver.FindElement(bandejaTareas.BTNOPOINICIAR).Click();

            //Elegimos iframe
            frame.BuscarFrame(driver, nuevaInstancia.Entrevista_Identificacion);

            //Elegimos Instancia
            driver.FindElement(nuevaInstancia.Entrevista_Identificacion).Click();
            driver.FindElement(nuevaInstancia.BTNOPOINICIAR).Click();


            //WebPanel HBNQFCB8 Entrevista

            //Cargar CUIT/CUIL Cliente

            //Elegimos iframe
            frame.BuscarFrame(driver, entrevista.SelectTipo);

            WaitHandler.ElementIsPresent(driver, entrevista.SelectTipo);
            entrevista.Seleccionar(driver, entrevista.SelectTipo, "C.U.I.T.");

            //Seleccionar tipo CUIL o CUIT 


            //Ingreso CUIL/CUIT del Cliente a entrevistar
            driver.FindElement(entrevista.InputDocumento).SendKeys(documento);
            driver.FindElement(entrevista.BTNOPVALIDAR).Click();

            //Elegimos iframe
            frame.BuscarFrame(driver, By.Id("HTMLTXTTITLE8"));
            WaitHandler.ElementIsPresent(driver, By.Id("HTMLTXTTITLE8"));


            string TipoPersona =  driver.FindElement(By.Id("HTMLTXTTITLE8")).Text;

            //Decidir segun tipo de persona 

            if (TipoPersona == "Datos Personales")
            {
                //Llamo a Calificar para PJ
                calificarTask.PJ();

            }
            else
            {
                //Llamo a Calificar para PF
                calificarTask.PF();
            }




        }

    }
}
