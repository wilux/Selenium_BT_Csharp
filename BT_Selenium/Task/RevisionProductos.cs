using BT_Selenium.Actions;
using BT_Selenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.UI
{
    //Simulación - Venta de Productos

    public class RevisionProductos
    {

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, RevisionProductosUI.BTNOPCONFIRMAR);
            WaitHandler.Wait(2000);

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

        public static void Observaciones(IWebDriver driver, string text="Test QA")
        {
            Enter.Text(driver, RevisionProductosUI.TextObservaciones, text);

        }


    }



}
