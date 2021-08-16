using BT_Selenium.UI;
using OpenQA.Selenium;


namespace BT_Selenium.Task
{
    /*
     * Clase que lista todas las tareas para simular un prestamo persona 
     */
    public class CalificarTask
    {
        
        public static void PJ(string circuito)
        {
            Frame frame = new Frame();
            EntrevistaUI entrevista = new Entrevista(driver);
            PrincipalPage principalPage = new PrincipalPage(driver);
            BandejaTareasUI bandejaTareas = new BandejaTareasUI();
            NuevaInstanciaUI nuevaInstancia = new NuevaInstanciaUI();
            SimulacionProductosUI simulacionProductos = new SimulacionProductosUI();
            CircuitoBETask circuitoBETask = new CircuitoBETask(driver);

            ////Pantalla Entrevista

            ////Pausa
            //WaitActions.ElementIsPresent(driver, By.Id("HTMLTXTTITLE1"));

            ////Completar Datos de contacto
            //entrevista.Completar_DatosContacto(driver);

            // //Confirmar
            // entrevista.Confirmar(driver);

            // //Cerrar para continuar siguiente pantalla
            // entrevista.Cerrar(driver);


            ////Elegir Tarea, Siguiente y Si.
            //bandejaTareas.Siguiente(driver);
            //bandejaTareas.Si(driver);

            //Elegir Tarea, Ejecutar
            bandejaTareas.Ejecutar(driver);

            //Pantalla Simulacion

            frame.BuscarFrame(driver, simulacionProductos.SelectPaquete);
            //Sin paquete -- 0
            simulacionProductos.SeleccionarByIndex(driver, simulacionProductos.SelectPaquete, 0);
            driver.FindElement(simulacionProductos.SelectPaquete).SendKeys(Keys.Return);

            //Chequear Calificacion
            driver.FindElement(simulacionProductos.CheckCalificacion).Click();

            //Elegir Circuito // fallo
            frame.BuscarFrame(driver, simulacionProductos.SelectCircuito);
            simulacionProductos.SeleccionarByValue(driver, simulacionProductos.SelectCircuito, circuito);

            //Confirmar 
            simulacionProductos.Confirmar(driver);
            //Si
            simulacionProductos.Si(driver);

            //Tomar
            bandejaTareas.Tomar(driver);

            // if circuito == "BE"
            circuitoBETask.IniciarCircuito();

        }


        public void PF()
        {

        }
    }
}
