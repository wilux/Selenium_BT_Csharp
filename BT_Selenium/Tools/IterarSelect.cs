using BT_Selenium.Actions;
using BT_Selenium.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.Tools
{
    public class IterarSelect
    {
        public static void Todos(IWebDriver driver)
        {
            var element = driver.FindElement(SimulacionProductosUI.SelectPaquete);
            //create select element object 
            var selectElement = new SelectElement(element);
            var index = 0;
            int cantidad = 30;
            //string paquete = "";
            List<string> paquetes = new List<string>();

            //driver.FindElement(simulacionProductos.SelectPaquete).Click();

            foreach (var option in selectElement.Options)
            {
                if (index == 0)
                {
                    cantidad = selectElement.Options.Count;

                }

                index++;
                if (index == cantidad)
                {
                    break;
                }

                paquetes.Add(option.Text);

            }

            for (int i = 0; i < paquetes.Count; i++)
            {

                //frame.BuscarFrame(driver, simulacionProductos.SelectPaquete);
                Select.ByIndex(driver, SimulacionProductosUI.SelectPaquete, i);
                PressKey.ArrowDown(driver, SimulacionProductosUI.SelectPaquete);
                WaitHandler.Wait(driver, 6);
                //Reporte.Logger(gdem + " - " + documento + " - " + comentario + " - " + paquetes[i]);
                //Capturar.Pantalla(driver, paquetes[i], documento);
            }
        }
    }
}
