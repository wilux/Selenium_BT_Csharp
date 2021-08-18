using BT_Selenium.Actions;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.Task
{
    class IdentificacionClienteValidacion
    {
        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, IdentificacionClienteValidacionUI.BTNOPCONFIRMAR);
            WaitHandler.Wait(3000);
            Click.On(driver, IdentificacionClienteValidacionUI.BTN_SI);

        }


        public static void CheckGrupo(IWebDriver driver)
        {
            Click.On(driver, IdentificacionClienteValidacionUI.RCheckGrupo);
        }
        public static void CheckSociedad(IWebDriver driver)
        {
            Click.On(driver, IdentificacionClienteValidacionUI.RCheckGrupo);
        }
    }
}
