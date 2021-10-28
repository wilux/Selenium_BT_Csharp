using BT_Selenium.Actions;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;


namespace BT_Selenium.Task
{
    //Simulación - Venta de Productos

    public class RevisionProductos
    {

        public static void Confirmar(IWebDriver driver)
        {
            if (WaitHandler.IsEnable(driver, RevisionProductosUI.BTNOPCONFIRMAR)) {
                Click.On(driver, RevisionProductosUI.BTNOPCONFIRMAR);
                WaitHandler.Wait(3);
                Click.On(driver, RevisionProductosUI.BTN_SI);
                WaitHandler.Wait(3);
            }

        }

        public static void Rechazar(IWebDriver driver)
        {
            Click.On(driver, RevisionProductosUI.BTNOPRECHAZAR);

        }

        public static void PerfilRiesgo(IWebDriver driver)
        {
            Click.On(driver, RevisionProductosUI.BTNOPPERFILDERIESGO);

        }
        public static void Liquidar(IWebDriver driver)
        {
            Click.On(driver, RevisionProductosUI.BTNOPLIQUIDAR);

        }

        public static void CheckCAUSD(IWebDriver driver)
        {
            Get.InputValue(driver, RevisionProductosUI.Check_CAUSD);

        }

        public static void Observaciones(IWebDriver driver, string text="Test QA")

        {
            //4 tabs

            Click.On(driver, RevisionProductosUI.TextObservaciones);
            Enter.Text(driver, RevisionProductosUI.TextObservaciones, text);

        }

    }



}
