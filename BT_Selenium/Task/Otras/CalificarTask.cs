using BT_Selenium.Actions;
using BT_Selenium.Tasks;
using BT_Selenium.UI;
using OpenQA.Selenium;


namespace BT_Selenium.Task
{
    /*
     * Clase que lista todas las tareas para simular un prestamo persona 
     */
    public class CalificarTask
    {
        
        public static void PJ(IWebDriver driver, string circuito)
        {

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
            BandejaTareas.Ejecutar(driver);

            //Pantalla Simulacion          
            Select.ByIndex(driver, SimulacionProductosUI.SelectPaquete, 0); //Sin paquete -- 0
            PressKey.Return(driver, SimulacionProductosUI.SelectPaquete);

            //Chequear Calificacion
            Click.On(driver, SimulacionProductosUI.CheckCalificacion);

            //Elegir Circuito // fallo
            Select.ByValue(driver, SimulacionProductosUI.SelectCircuito, circuito);

            //Confirmar 
            Click.On(driver, SimulacionProductosUI.BTNOPCONFIRMAR);

            //Si
            Click.On(driver, SimulacionProductosUI.BTN_SI);

            //Tomar
            BandejaTareas.Tomar(driver);

            // if circuito == "BE"
            CircuitoBETask.IniciarCircuito();

        }


        public static void PF()
        {

        }
    }
}
