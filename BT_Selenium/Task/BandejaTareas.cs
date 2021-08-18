using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using BT_Selenium.Task;

namespace BT_Selenium.Tasks
{
    public class BandejaTareas
    {
        public static void BTNOPOINICIAR_Click(IWebDriver driver)
        {
            Click.On(driver, BandejaTareasUI.BTNOPOINICIAR);
        }

        public static void Seleccionar(IWebDriver driver)
        {
            Grid.SeleccionarFila(driver, BandejaTareasUI.Grilla_Tareas, BandejaTareasUI.PrimerTarea);
            Click.On(driver, BandejaTareasUI.PrimerTarea);
        }

        public static void Siguiente(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitHandler.Wait(2000);
            Click.On(driver, BandejaTareasUI.BTNOPOSIGUIENTE);
            Si(driver);
        }

        public static void Si(IWebDriver driver)
        {
            Frame.BuscarFrame(driver, BandejaTareasUI.BTNCONFIRMATION);
            Click.On(driver, BandejaTareasUI.BTNCONFIRMATION);
        }

        public static void Ejecutar(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitHandler.Wait(2000);
            Click.On(driver, BandejaTareasUI.BTNOPOEJECUTAR);
        }

        public static void Tomar(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitHandler.Wait(2000);
            Click.On(driver, BandejaTareasUI.BTNOPOTOMAR);
        }

    }
}
