using BT_Selenium.Actions;
using BT_Selenium.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;
using WindowsInput;
using BT_Selenium.UI;

namespace BT_Selenium.Task
{
    //Simulación - Venta de Productos

    public class MatrizRiesgo
    {

        public static void Confirmar(IWebDriver driver)
        {
            if (WaitHandler.IsEnable(driver, MatrizRiesgoUI.BTNOPCONFIRMAR)) {
                //Ctrol + enter
                WaitHandler.Wait(2);
                InputSimulator sim = new InputSimulator();
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.RETURN);
                //Click.On(driver, MatrizRiesgoUI.BTNOPCONFIRMAR);
                WaitHandler.Wait(2);
            }

        }

        public static void Si(IWebDriver driver)
        {
            WaitHandler.Wait(2);
            Click.On(driver, MatrizRiesgoUI.Radio_Si);
            WaitHandler.Wait(2);

        }


        public static void Cerrar(IWebDriver driver)
        {
            //Ctrol + E
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_E);

            //Click.On(driver, MatrizRiesgoUI.BTNOPCERRAR);

        }


    }



}
