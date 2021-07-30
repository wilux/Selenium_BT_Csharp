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
    public class SimularPrestamoTask : BasePage
    {

        public SimularPrestamoTask(IWebDriver Driver)
        {
            driver = Driver;
        }
        //Frames
        Steps steps = new Steps();
        Frame frame = new Frame();

        // Objetos de la pagina principal de BT
        PrincipalPage principalPage = new PrincipalPage();

        // Objetos de hxwf900 Bandeja de tareas
        BandejaTareas bandejaTareas = new BandejaTareas();

        //Objetos de hxwf901 Nueva Instancia de Proceso
        NuevaInstancia iniciarInstancia = new NuevaInstancia();

        //Objetos de Entrevista
        Entrevista entrevista = new Entrevista();

        //Objetos de Hbnqfpb3 - Simular 
        SimulaPrestamo simulaPrestamo = new SimulaPrestamo();

      public void BI(String cuil, String ingresos, string telefono, String monto, String plazo)
        {
            //Pausa
            Thread.Sleep(6000);

            //WaitHandler.ElementIsPresent(driver, principalPage.Inicio);

            //Ingreso al menu hasta -> BandejaTareas
            driver.FindElement(principalPage.Inicio).Click();
            driver.FindElement(principalPage.WF).Click();
            driver.FindElement(principalPage.BandejaTareas).Click();
            Capturar.Pantalla(driver, "Bandejatareas", cuil);

            //WebPanel  hxwf900 - Bandeja de tareas
            //Iniciamos Nueva Tarea en Bandeja de tareas

            steps.PasarFrame_1_0(driver);
            //frame.FrameActual(driver);


            driver.FindElement(bandejaTareas.BTNOPOINICIAR).Click();


            //WebPanel  hxwf901
            //Elegimos nueva Entrevista / Identificacion
            steps.PasarFrame_0(driver);
            driver.FindElement(iniciarInstancia.Entrevista_Identificacion).Click();
            driver.FindElement(iniciarInstancia.BTNOPOINICIAR).Click();


            //WebPanel HBNQFCB8 Entrevista

            //Cargar CUIT/CUIL Cliente
            //Elegimos tipo 
            steps.PasarFrame_2_4(driver);
            //frame.FrameActual(driver);
            webElement = driver.FindElement(entrevista.SelectTipo);
            selectElement = new SelectElement(webElement);
            selectElement.SelectByText("C.U.I.L.");
            //Ingreso CUIL/CUIT del Cliente a entrevistar
            driver.FindElement(entrevista.InputDocumento).SendKeys(cuil);
            driver.FindElement(entrevista.BTNOPVALIDAR).Click();
            Capturar.Pantalla(driver, "CUIL", cuil);


            //Pantalla Entrevista
            steps.PasarFrame_3(driver);
            //frame.FrameActual(driver);

            //Mail, sino tiene tildamos, de lo contrario dejamos como esta.
            String mail = driver.FindElement(entrevista.InputMail).GetAttribute("value");
            if (mail == "")
            {
                driver.FindElement(entrevista.NoMail).Click();
            }


            //Elegimos campos Telefonico 1
            steps.PasarFrame_2(driver);
            //frame.FrameActual(driver);
            IWebElement TipoTelefono = driver.FindElement(entrevista.SelectTelefono);
            SelectElement SelectTipoTelefono = new SelectElement(TipoTelefono);
            SelectTipoTelefono.SelectByText("Celular");

            //Elegimos campos Telefonico 2
            IWebElement TipoTelefono2 = driver.FindElement(entrevista.SelectTelefono2);
            SelectElement SelectTipoTelefono2 = new SelectElement(TipoTelefono2);
            SelectTipoTelefono2.SelectByText("Seleccionar");

            //Elegimos codigo de area
            IWebElement CodigoArea = driver.FindElement(entrevista.SelectCodigoArea);
            SelectElement SelectCodigoArea = new SelectElement(CodigoArea);
            SelectCodigoArea.SelectByText("291");

            //Elegimos codigo de area 2
            IWebElement CodigoArea2 = driver.FindElement(entrevista.SelectCodigoArea2);
            SelectElement SelectCodigoArea2 = new SelectElement(CodigoArea2);
            SelectCodigoArea2.SelectByText("Seleccionar");


            //Escribimos un numero telefonico 1 
            driver.FindElement(entrevista.InputTelefono).Click();
            driver.FindElement(entrevista.InputTelefono).SendKeys(telefono);
            driver.FindElement(entrevista.InputTelefono).SendKeys(Keys.Return);

            //Escribimos un numero telefonico 2 
            driver.FindElement(entrevista.InputTelefono2).Clear();



            //Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
            IWebElement GRIDACRED = driver.FindElement(entrevista.GridCtaDebito);
            GRIDACRED.FindElement(By.TagName("td")).Click();
            driver.FindElement(entrevista.BTNOPELEGIRCTA).Click();

            //Ingresos
            steps.PasarFrame_3(driver);
            //frame.FrameActual(driver);
            Thread.Sleep(6000);
            //Sector Empleador
            IWebElement SectorEmpleador = driver.FindElement(entrevista.SelectSectorEmpleador);
            SelectElement SelectSectorEmpleador = new SelectElement(SectorEmpleador);
            SelectSectorEmpleador.SelectByText("Publico");
            //Importe Ingresos en Depedencia
            driver.FindElement(entrevista.InputIngresosDepedencia).Click();
            driver.FindElement(entrevista.InputIngresosDepedencia).SendKeys(ingresos);
            driver.FindElement(entrevista.InputIngresosDepedencia).SendKeys(Keys.Return);
            Capturar.Pantalla(driver, "Ingresos", cuil);

            //Confirmar Entrevista
            driver.FindElement(entrevista.BTNOPCONFIRMAR).Click();
            Capturar.Pantalla(driver, "Entrevista", cuil);

            //Cerrar para continuar siguiente pantalla
            steps.PasarFrame_2(driver);
            //frame.FrameActual(driver);
            driver.FindElement(entrevista.BTNOPCERRAR).Click();


            //Volvemos a hxwf900 - Bandeja de Entrada de Tareas
            steps.PasarFrame_3_4(driver);
            //frame.FrameActual(driver);
            //Elegir primer Tarea para Continuar Flujo // Siguiente
            IWebElement GRIDINBOX = driver.FindElement(bandejaTareas.Grilla_Tareas);
            GRIDINBOX.FindElement(bandejaTareas.PrimerTarea).Click();
            driver.FindElement(bandejaTareas.BTNOPOSIGUIENTE).Click();
            //Confirmar SI
            steps.PasarFrame_1(driver);
            //frame.FrameActual(driver);
            driver.FindElement(bandejaTareas.BTNCONFIRMATION).Click();
            //Ejecutar
            steps.PasarFrame_3(driver);
            //frame.FrameActual(driver);
            //Elegir primer Tarea para Continuar Flujo // Siguiente
            IWebElement GRIDINBOX2 = driver.FindElement(bandejaTareas.Grilla_Tareas);
            GRIDINBOX2.FindElement(bandejaTareas.PrimerTarea).Click();
            driver.FindElement(bandejaTareas.BTNOPOEJECUTAR).Click();
            Capturar.Pantalla(driver, "TramiteEnBandeja", cuil);

            //Elijo paquete (Trae por defecto el mas alto disponible)
            //Aqui deberia poner logica para elegir uno distinto
            //

            //WebPanel hBNQFPB3 - Simulación - Venta de Productos
            steps.PasarFrame_1(driver);
            //frame.FrameActual(driver);
            //Elijo Linea _LINEA
            IWebElement Linea = driver.FindElement(simulaPrestamo.SelectLineaPrestamo);
            SelectElement SelectLinea = new SelectElement(Linea);
            //SelectLinea.SelectByValue("309201003");
            SelectLinea.SelectByIndex(1);//Elijo la primera disponible.
            Linea.SendKeys(Keys.Return);



            //Pausa
            Thread.Sleep(9000);
            //WaitHandler.ElementIsPresent(driver, simulaPrestamo.InputMonto);

            //Monto _BNQFPC5MTO
            //frame.FrameActual(driver);
            steps.PasarFrame_4(driver);

            driver.FindElement(simulaPrestamo.InputMonto).Clear();
            driver.FindElement(simulaPrestamo.InputMonto).Click();
            driver.FindElement(simulaPrestamo.InputMonto).SendKeys(monto);



            //Cuotas _BNQFPC5PZO
            driver.FindElement(simulaPrestamo.InputPlazo).Clear();
            driver.FindElement(simulaPrestamo.InputPlazo).SendKeys(plazo);

            //Destino Fondos _BNQFPC5DES en step4
            driver.FindElement(simulaPrestamo.SelectDestinoFondos).Click();
            IWebElement SelectDestinoFondos = driver.FindElement(simulaPrestamo.SelectDestinoFondos);
            SelectElement destinoFondos = new SelectElement(SelectDestinoFondos);
            destinoFondos.SelectByText("Otros");

            //Boton Simular BTNOPSIMULAR en step4
            driver.FindElement(simulaPrestamo.BTNOPSIMULAR).Click();
            Capturar.Pantalla(driver, "Simulacion", cuil);

            //Pausa
            Thread.Sleep(3000);
        
            steps.PasarFrame_1(driver);
            //frame.FrameActual(driver);
            String valorCuota = driver.FindElement(simulaPrestamo.ValorCuotaAprox).GetAttribute("value");
            String TNA = driver.FindElement(simulaPrestamo.ValorTna).GetAttribute("value");
            String TEM = driver.FindElement(simulaPrestamo.ValorTem).GetAttribute("value");
            String TEA = driver.FindElement(simulaPrestamo.ValorTea).GetAttribute("value");


          

            Reporte.Logger("Cliente CUIL: "+cuil
                +
                ". Simulacion por un monto de de $"
                +monto
                +". el valor de la cuota aprox. es de: $"+valorCuota 
                + " con una TNA: %"+TNA
                + " en un plazo de "
                + plazo + " meses."
                );



        }

        public void Descartar()
        {
            //Pausa
            Thread.Sleep(6000);

            //Inicio proceso DESCARTE
            //Cambio al frame step4
            steps.PasarFrame_1(driver);
            //frame.FrameActual(driver);
            driver.FindElement(simulaPrestamo.BTNOPDESCARTAR).Click();

            //Pausa
            Thread.Sleep(5000);

            //Confirmar SI
            steps.PasarFrame_4(driver);
            //frame.FrameActual(driver);
            driver.FindElement(simulaPrestamo.BTNCONFIRMATION).Click();

            driver.Quit();
        }
    }
}
