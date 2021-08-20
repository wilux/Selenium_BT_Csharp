using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;

namespace BT_Selenium.Tasks
{
    public class SimulacionProductos
    {


        public static void LineaPrestamo(IWebDriver driver, int index = 1)
        {
            Select.ByIndex(driver, SimulacionProductosUI.SelectLineaPrestamo, index);//Elijo la primera disponible.
            PressKey.Return(driver, SimulacionProductosUI.SelectLineaPrestamo);
        }

        public static void MontoPrestamo(IWebDriver driver, string monto = "10000")
        {

            Frame.BuscarFrame(driver, SimulacionProductosUI.InputMonto);
            Clear.On(driver, SimulacionProductosUI.InputMonto);
            Click.On(driver, SimulacionProductosUI.InputMonto);
            Enter.Text(driver, SimulacionProductosUI.InputMonto, monto);
        }

        public static void PlazoPrestamo(IWebDriver driver, string plazo)
        {
            Clear.On(driver, SimulacionProductosUI.InputPlazo);
            Enter.Text(driver, SimulacionProductosUI.InputPlazo, plazo);
        }

        public static void DestinoFondos(IWebDriver driver, string destino = "Otros")
        {
            Click.On(driver, SimulacionProductosUI.SelectDestinoFondos);
            Select.ByText(driver, SimulacionProductosUI.SelectDestinoFondos, destino);
        }

        public static void CheckCalificacion(IWebDriver driver, string calificacion="BE")
        {
            Click.On(driver, SimulacionProductosUI.CheckCalificacion);
            WaitHandler.Wait(5000);
            Select.ByValue(driver, SimulacionProductosUI.SelectDestinoFondos, calificacion);

        }
        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, SimulacionProductosUI.BTNOPCONFIRMAR);
            WaitHandler.Wait(3000);
            Click.On(driver, SimulacionProductosUI.BTN_SI);

        }

        public static void Descartar(IWebDriver driver)
        {

            Click.On(driver, BandejaTareasUI.BTNOPDESCARTAR);
            WaitHandler.Wait(3000);
            Click.On(driver, BandejaTareasUI.BTNCONFIRMATION);
        }

    }
}
