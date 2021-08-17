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

    }
}
