using BT_Selenium.Actions;
using BT_Selenium.Tools;
using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    //Consulta WC - BridgerInsight
    public class ConsultaBridgerInsight
    {

        public static void BuscarBridger(IWebDriver driver)
        {
            Click.On(driver, ConsultaBridgerInsightUI.BTNOPBUSCARBRIDGER);
            WaitHandler.Wait(5000);

        }

        public static void Imprimir(IWebDriver driver)
        {
            Click.On(driver, ConsultaBridgerInsightUI.BTN_SinCoincidencia);
            WaitHandler.Wait(5000);

        }



        public static void Volver(IWebDriver driver)
        {
            
            Navegador.Back(driver);
            WaitHandler.Wait(5000);
            Navegador.Back(driver);
            WaitHandler.Wait(5000);

        }

        public static void Cerrar(IWebDriver driver)
        {
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("step2");
            Click.On(driver, ConsultaBridgerInsightUI.BTNOPCERRAR);
            WaitHandler.Wait(3000);

        }

    }
}
