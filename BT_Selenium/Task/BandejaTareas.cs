using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using BT_Selenium.Task;

namespace BT_Selenium.Tasks
{
    public class BandejaTareas
    {
        public void BTNOPOINICIAR_Click(IWebDriver driver)
        {
            Click.On(driver, BandejaTareasUI.BTNOPOINICIAR);
        }

        public void Seleccionar(IWebDriver driver)
        {
            Grid.SeleccionarFila(driver, BandejaTareasUI.Grilla_Tareas, BandejaTareasUI.PrimerTarea);
            Click.On(driver, BandejaTareasUI.PrimerTarea);
        }

        public void Siguiente(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitActions.Wait(driver, 2000);
            Click.On(driver, BandejaTareasUI.BTNOPOSIGUIENTE);
        }

        public void Si(IWebDriver driver)
        {
            Frame.BuscarFrame(driver, BandejaTareasUI.BTNCONFIRMATION);
            Click.On(driver, BandejaTareasUI.BTNCONFIRMATION);
        }

        public void Ejecutar(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitActions.Wait(driver, 2000);
            driver.FindElement(BTNOPOEJECUTAR).Click();
        }

        public void Tomar(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitActions.Wait(driver, 2000);
            driver.FindElement(BTNOPOTOMAR).Click();
        }

    }
}
