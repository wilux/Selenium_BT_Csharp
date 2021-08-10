using BT_Selenium.Handler;
using BT_Selenium.PageObject;
using BT_Selenium.PageObject.WebPanel;
using BT_Selenium.Task;
using BT_Selenium.TestCase;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class SimularPrestamoTest : BaseTest
    {
        //10000 = 100,000 cien mil 
        [TestCase("20303879618", "10000", "4725555", "50,000.00", "36")]
        //[TestCase("20322717564", "15000", "4721111", "30,000.00", "24")]
        //[TestCase("20179364973", "19000", "4722222", "60,000.00", "18")]
        //[TestCase("40303879618", "10000", "4725555", "50,000.00", "36")]// Con falla (cuil invalido)
        public void Simulador(String cuil, String ingresos, string telefono, String monto, String plazo)
        {

            //Frames
            Frame frame = new Frame();

            // Instancia de Objetos
            PrincipalPage principalPage = new PrincipalPage();
            BandejaTareas bandejaTareas = new BandejaTareas();
            NuevaInstancia nuevaInstancia = new NuevaInstancia();
            Entrevista entrevista = new Entrevista();
            SimulaPrestamo simulaPrestamo = new SimulaPrestamo();


            //Ventana Actual
            driver.SwitchTo().Window(driver.WindowHandles[1]);


            //Tareas

            //Pausa
            WaitHandler.ElementIsPresent(driver, principalPage.Menu);

            //Menu ir a...Inicio>WF>BandejaTarea
            principalPage.MenuInicio(driver);
            principalPage.MenuWorkFlow(driver);
            principalPage.MenuBandejaTareas(driver);

            //WebPanel  hxwf900 - Bandeja de tareas
            //Iniciamos Nueva Tarea en Bandeja de tareas

            //Elegimos iframe
            frame.BuscarFrame(driver, bandejaTareas.BTNOPOINICIAR);
            //Esperamos elemento


            //Iniciar instancia

            driver.FindElement(bandejaTareas.BTNOPOINICIAR).Click();

            //WebPanel  hxwf901
            //Elegimos nueva Entrevista / Identificacion

            //Elegimos iframe
            frame.BuscarFrame(driver, nuevaInstancia.Entrevista_Identificacion);
            //Esperamos elemento
            WaitHandler.ElementIsPresent(driver, nuevaInstancia.Entrevista_Identificacion);
            //Ejecutamos acciones
            driver.FindElement(nuevaInstancia.Entrevista_Identificacion).Click();
            driver.FindElement(nuevaInstancia.BTNOPOINICIAR).Click();

            //WebPanel HBNQFCB8 Entrevista
            //Cargar CUIT/CUIL Cliente

            //Seleccionamos tipo CUIT/CUIL

            //Elegimos iframe
            frame.BuscarFrame(driver, entrevista.SelectTipo);
            entrevista.Seleccionar(driver, entrevista.SelectTipo, "C.U.I.L.");

            //Ingreso CUIL/CUIT del Cliente a entrevistar
            driver.FindElement(entrevista.InputDocumento).SendKeys(cuil);
            driver.FindElement(entrevista.BTNOPVALIDAR).Click();


            //Pantalla Entrevista
            //Elegimos iframe
            frame.BuscarFrame(driver, entrevista.InputMail);

            //Mail, sino tiene tildamos, de lo contrario dejamos como esta.
            String mail = driver.FindElement(entrevista.InputMail).GetAttribute("value");
            if (mail == "")
            {
                driver.FindElement(entrevista.NoMail).Click();
            }


            //Campos Telefonico 1

            //Elegimos iframe
            frame.BuscarFrame(driver, entrevista.SelectTelefono);
            entrevista.Seleccionar(driver, entrevista.SelectTelefono, "Celular");
            entrevista.Seleccionar(driver, entrevista.SelectCodigoArea, "299");
            //Escribimos un numero telefonico 1 
            driver.FindElement(entrevista.InputTelefono).Click();
            driver.FindElement(entrevista.InputTelefono).SendKeys(telefono);
            driver.FindElement(entrevista.InputTelefono).SendKeys(Keys.Return);

            //Campos Telefonico 1

            entrevista.Seleccionar(driver, entrevista.SelectTelefono2, "Seleccionar");
            entrevista.Seleccionar(driver, entrevista.SelectCodigoArea2, "Seleccionar");
            //Escribimos un numero telefonico 2 (Lo dejo vacio)
            driver.FindElement(entrevista.InputTelefono2).Clear();

            //Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
            IWebElement GRIDACRED = driver.FindElement(entrevista.GridCtaDebito);
            GRIDACRED.FindElement(By.TagName("td")).Click();
            driver.FindElement(entrevista.BTNOPELEGIRCTA).Click();



            //Ingresos
            //Elegimos iframe
            frame.BuscarFrame(driver, entrevista.SelectSectorEmpleador);

            //Sector Empleador
            entrevista.Seleccionar(driver, entrevista.SelectSectorEmpleador, "Publico");


            //Importe Ingresos en Depedencia
            driver.FindElement(entrevista.InputIngresosDepedencia).Click();
            driver.FindElement(entrevista.InputIngresosDepedencia).SendKeys(ingresos);
            driver.FindElement(entrevista.InputIngresosDepedencia).SendKeys(Keys.Return);
            Capturar.Pantalla(driver, "Ingresos", cuil);

            //Confirmar Entrevista
            driver.FindElement(entrevista.BTNOPCONFIRMAR).Click();
            Capturar.Pantalla(driver, "Entrevista", cuil);

            //Cerrar para continuar siguiente pantalla
            //Elegimos iframe
            frame.BuscarFrame(driver, entrevista.BTNOPCERRAR);
            driver.FindElement(entrevista.BTNOPCERRAR).Click();


            //Volvemos a hxwf900 - Bandeja de Entrada de Tareas
            //Elegimos iframe
            frame.BuscarFrame(driver, bandejaTareas.Grilla_Tareas);

            //Elegir primer Tarea para Continuar Flujo // Siguiente
            IWebElement GRIDINBOX = driver.FindElement(bandejaTareas.Grilla_Tareas);
            GRIDINBOX.FindElement(bandejaTareas.PrimerTarea).Click();
            driver.FindElement(bandejaTareas.BTNOPOSIGUIENTE).Click();

            //Confirmar SI
            //Elegimos iframe
            frame.BuscarFrame(driver, bandejaTareas.BTNCONFIRMATION);
            driver.FindElement(bandejaTareas.BTNCONFIRMATION).Click();
            //Ejecutar

            //Elegimos iframe
            frame.BuscarFrame(driver, bandejaTareas.Grilla_Tareas);
            //Elegir primer Tarea para Continuar Flujo // Ejecutar

            IWebElement GRIDINBOX2 = driver.FindElement(bandejaTareas.Grilla_Tareas);
            GRIDINBOX2.FindElement(bandejaTareas.PrimerTarea).Click();
            driver.FindElement(bandejaTareas.BTNOPOEJECUTAR).Click();
            Capturar.Pantalla(driver, "TramiteEnBandeja", cuil);

            //Elijo paquete (Trae por defecto el mas alto disponible)
            //Aqui deberia poner logica para elegir uno distinto
            

            //WebPanel hBNQFPB3 - Simulación - Venta de Productos
            //Elegimos iframe
            frame.BuscarFrame(driver, simulaPrestamo.SelectLineaPrestamo);

            //Elijo Linea _LINEA
            IWebElement Linea = driver.FindElement(simulaPrestamo.SelectLineaPrestamo);
            SelectElement SelectLinea = new SelectElement(Linea);
            SelectLinea.SelectByIndex(1);//Elijo la primera disponible.
            Linea.SendKeys(Keys.Return);

            //Pausa
            WaitHandler.ElementIsPresent(driver, simulaPrestamo.InputMonto);

            //Monto _BNQFPC5MTO
            //Elegimos iframe
            frame.BuscarFrame(driver, simulaPrestamo.InputMonto);
            driver.FindElement(simulaPrestamo.InputMonto).Clear();
            driver.FindElement(simulaPrestamo.InputMonto).Click();
            driver.FindElement(simulaPrestamo.InputMonto).SendKeys(monto);

            //Cuotas _BNQFPC5PZO
            driver.FindElement(simulaPrestamo.InputPlazo).Clear();
            driver.FindElement(simulaPrestamo.InputPlazo).SendKeys(plazo);

            //Destino Fondos _BNQFPC5DES en step4
            driver.FindElement(simulaPrestamo.SelectDestinoFondos).Click();
            entrevista.Seleccionar(driver, simulaPrestamo.SelectDestinoFondos, "Otros");

            //Boton Simular BTNOPSIMULAR en step4
            driver.FindElement(simulaPrestamo.BTNOPSIMULAR).Click();
            Capturar.Pantalla(driver, "Simulacion", cuil);

            //Elegimos iframe
            frame.BuscarFrame(driver, simulaPrestamo.ValorCuotaAprox);

            //Variables con datos para el reporte
            String valorCuota = driver.FindElement(simulaPrestamo.ValorCuotaAprox).GetAttribute("value");
            String TNA = driver.FindElement(simulaPrestamo.ValorTna).GetAttribute("value");
            String TEM = driver.FindElement(simulaPrestamo.ValorTem).GetAttribute("value");
            String TEA = driver.FindElement(simulaPrestamo.ValorTea).GetAttribute("value");


            //Escribo Reporte
            Reporte.Logger("Cliente CUIL: " + cuil
                +
                ". Simulacion por un monto de de $"
                + monto
                + ". el valor de la cuota aprox. es de: $" + valorCuota
                + " con una TNA: %" + TNA
                + " en un plazo de "
                + plazo + " meses."
                );




        }


    }
}
