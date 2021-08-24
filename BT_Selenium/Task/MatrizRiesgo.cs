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

    public class MatrizRiesgo
    {

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, MatrizRiesgoUI.BTNOPCONFIRMAR);
            WaitHandler.Wait(2000);

        }

        public static void Cerrar(IWebDriver driver)
        {
            Click.On(driver, MatrizRiesgoUI.BTNOPCERRAR);

        }


    }



}
