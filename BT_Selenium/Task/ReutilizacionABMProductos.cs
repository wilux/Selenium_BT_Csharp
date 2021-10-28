using BT_Selenium.Actions;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;


namespace BT_Selenium.Task
{
    //Simulación - Venta de Productos

    public class ReutilizacionABMProductos
    {
        public static void SeleccionarSeguroVida(IWebDriver driver, int index = 1)
        {
            //Click.On(driver, ReutilizacionABMProductosUI.SelectSeguroVida);
            if (WaitHandler.IsVisible(driver, ReutilizacionABMProductosUI.SelectSeguroVida)) {
                Select.ByIndex(driver, ReutilizacionABMProductosUI.SelectSeguroVida, index);
                WaitHandler.Wait(5);
            }
        }


        public static void SeleccionarTarjeta(IWebDriver driver)
        {
            Grid.SeleccionarFila(driver, ReutilizacionABMProductosUI.GRID_TarjetasDebito, ReutilizacionABMProductosUI.PrimerTarjeta);
            Click.On(driver, ReutilizacionABMProductosUI.PrimerTarjeta);
        }


        public static void Aceptar(IWebDriver driver)
        {
            if (WaitHandler.ElementIsPresent(driver, ReutilizacionABMProductosUI.BTNOPACEPTARTDNUEVA))
            {
                Click.On(driver, ReutilizacionABMProductosUI.BTNOPACEPTARTDNUEVA);
                WaitHandler.Wait(5);
            }
            else
            {
                Click.On(driver, ReutilizacionABMProductosUI.BTNOPACEPTARTExistente);
                WaitHandler.Wait(5);
            }
        }

        public static void PerfilRiesgo(IWebDriver driver)
        {
            Click.On(driver, ReutilizacionABMProductosUI.BTNOPPERFILDERIESGO);
            WaitHandler.Wait(5);
        }



    }



}
