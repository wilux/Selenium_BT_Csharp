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
    public class CalificarTask : BasePage
    {
        
        public CalificarTask(IWebDriver Driver)
        {
            driver = Driver;
        }

        public void PJ(string circuito)
        {
            Entrevista entrevista = new Entrevista(driver);

            PrincipalPage principalPage = new PrincipalPage(driver);
            BandejaTareas bandejaTareas = new BandejaTareas();
            NuevaInstancia nuevaInstancia = new NuevaInstancia();
            SimulacionProductos simulacionProductos = new SimulacionProductos();

            //Pantalla Entrevista

            //Pausa
            WaitHandler.ElementIsPresent(driver, By.Id("HTMLTXTTITLE1"));

            //Completar Datos de contacto
            entrevista.Completar_DatosContacto(driver);

             //Confirmar
             entrevista.Confirmar(driver);

             //Cerrar para continuar siguiente pantalla
             entrevista.Cerrar(driver);


            //Elegir Tarrea, Siguiente y Si.
            bandejaTareas.Seleccionar(driver);
            bandejaTareas.Siguiente(driver);
            bandejaTareas.Si(driver);

            //Ejecutar
            bandejaTareas.Ejecutar(driver);

            //Pantalla Simulacion
            //Sin paquete -- 0
            simulacionProductos.SeleccionarByIndex(driver, simulacionProductos.SelectPaquete, 0);
            driver.FindElement(simulacionProductos.SelectPaquete).SendKeys(Keys.Return);

            //Chequear Calificacion
            driver.FindElement(simulacionProductos.CheckCalificacion).Click();

            //Elegir Circuito
            simulacionProductos.SeleccionarByValue(driver, simulacionProductos.SelectCircuito, circuito);

            //Confirmar
            simulacionProductos.Confirmar(driver);
            //Si
            simulacionProductos.Si(driver);

            //Tomar
            bandejaTareas.Tomar(driver);

            //Marcar NO NO

            //Confirmar

            //SI

            //Capturar Mensae

            //Cerrar

            //Bandeja

            //Siguiente
            //Si

            //Tomar

            //Pantalla Simulacion Asistencia Creditica

            //Completar Valores
            //public By InputVtasAnuales = By.Id("_VTASANUALES"); //10000
            //public By InputPatrimonioNeto = By.Id("_BNQFB11PNT");//10000
            //public By InputResultadoEjerc = By.Id("_BNQFB11REJ");//10000
            //public By InputAnosExperiencia = By.Id("_BNQFB11ERU");//1
            //public By InputCantidadEmp = By.Id("_BNQFB11CEM");//1

            //Simular
            //            public By BTNOPSIMULACION = By.Id("BTNOPSIMULACION");
            //Confirmar
            //public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");

            //Si

            //Cerrar

            //Bandeja
            //Seleccionar
            //Siguiente
            //si
            //Tomar

            //Pantalla Documentacion
            //_BNQFB11UCB fecha value "dd/MM/YYYY"
            //Iterar 10, seleccionar fila span__BNQFB19NOM_0001 hasta 10
            //BTNOPAGREGARLD agregar
            //
            //htmlInputFileUpload3 input ruta archivo
            //value = C:\fakepath\Doc1_Test.pdf
            //BTNOPCONFIRMAR
            //fin iterar
            //confirmar
            //cerrar

            //Bandeja
            //Siguiente
            //Si
            //Tomar

            //Pantalla Asistencia  Crditiacia

        }


        public void PF()
        {

        }
    }
}
