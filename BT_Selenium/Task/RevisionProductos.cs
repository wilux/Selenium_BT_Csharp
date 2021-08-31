using BT_Selenium.Actions;
using BT_Selenium.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT_Selenium.UI
{
    //Simulación - Venta de Productos

    public class RevisionProductos
    {

        public static void Confirmar(IWebDriver driver)
        {
            if (WaitHandler.IsEnable(driver, RevisionProductosUI.BTNOPCONFIRMAR)) {
                Click.On(driver, RevisionProductosUI.BTNOPCONFIRMAR);
                WaitHandler.Wait(driver, 3);
                Click.On(driver, RevisionProductosUI.BTN_SI);
                WaitHandler.Wait(driver, 3);
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
