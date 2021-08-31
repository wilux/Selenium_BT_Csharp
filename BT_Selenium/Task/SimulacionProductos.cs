using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;

namespace BT_Selenium.Tasks
{
    public class SimulacionProductos
    {

        public static string GetMensaje(IWebDriver driver)
        {
            try
            {
                Frame.BuscarFrame(driver, SimulacionProductosUI.MsgTextAbajo);
                return Get.SpanText(driver, SimulacionProductosUI.MsgTextAbajo);
            }
            catch
            {
                return "";
            }
        }
        public static bool ValidarProducto(IWebDriver driver, string producto)
        {

            return Get.SelectElementContainsItemText(driver, SimulacionProductosUI.SelectPaquete, producto);
        }

        public static void LineaPrestamo(IWebDriver driver, int index = 1)
        {
            Select.ByIndex(driver, SimulacionProductosUI.SelectLineaPrestamo, index);//Elijo la primera disponible.
            PressKey.Return(driver, SimulacionProductosUI.SelectLineaPrestamo);
            WaitHandler.Wait(driver, 8);
        }

        public static void Paquete(IWebDriver driver, int index = 1)
        {
            Select.ByIndex(driver, SimulacionProductosUI.SelectPaquete, index);//Elijo el mas alto x defecto
            PressKey.Return(driver, SimulacionProductosUI.SelectPaquete);
        }

        public static void PaqueteNombre(IWebDriver driver, string nombre)
        {
            Select.ByText(driver, SimulacionProductosUI.SelectPaquete, nombre);
            PressKey.Return(driver, SimulacionProductosUI.SelectPaquete);
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
            CheckBox.Check(driver, SimulacionProductosUI.CheckCalificacion);
            //Click.On(driver, SimulacionProductosUI.CheckCalificacion);
            WaitHandler.Wait(driver, 5);
            Select.ByValue(driver, SimulacionProductosUI.SelectDestinoFondos, calificacion);

        }

        public static void CheckPrestamo(IWebDriver driver)
        {

            CheckBox.Check(driver, SimulacionProductosUI.CheckPrestamo);
            WaitHandler.Wait(driver, 8);

        }

        public static void UnCheckPrestamo(IWebDriver driver)
        {
            CheckBox.UnCheck(driver, SimulacionProductosUI.CheckPrestamo);
            WaitHandler.Wait(driver, 8);

        }

        public static void Paquetizar(IWebDriver driver)
        {
            Click.On(driver, SimulacionProductosUI.BTNOPPAQUETIZAR);
            WaitHandler.Wait(driver, 5);

        }

        public static void UnCheckTarjetas(IWebDriver driver)
        {
            CheckBox.UnCheck(driver, SimulacionProductosUI.CheckTC1);
            CheckBox.UnCheck(driver, SimulacionProductosUI.CheckTC2);
        }

        public static void CheckTarjetas(IWebDriver driver)
        {
            CheckBox.Check(driver, SimulacionProductosUI.CheckTC1);
            CheckBox.Check(driver, SimulacionProductosUI.CheckTC2);

        }
        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, SimulacionProductosUI.BTNOPCONFIRMAR);
            WaitHandler.Wait(driver, 3);
            Click.On(driver, SimulacionProductosUI.BTN_SI);

        }

        public static void Descartar(IWebDriver driver)
        {

            Click.On(driver, BandejaTareasUI.BTNOPDESCARTAR);
            WaitHandler.Wait(driver, 3);
            Click.On(driver, BandejaTareasUI.BTNCONFIRMATION);
        }

    }
}
