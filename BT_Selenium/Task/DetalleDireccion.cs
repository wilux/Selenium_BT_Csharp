using BT_Selenium.Actions;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace BT_Selenium.Task
{
    public class DetalleDireccion
    {

        public static void Completar(IWebDriver driver)
        {
           

            if (Frame.BuscarFrame(driver, DetalleDireccionUI.InputFechaDesde))
            {
   
                    Click.On(driver, DetalleDireccionUI.InputFechaDesde);
                    Enter.JSTextById(driver, "_SNGC13RDES", "01/01/1981");
               
            }

            if (Frame.BuscarFrame(driver, DetalleDireccionUI.SelectCalle))
            {
                if (Get.SelectValue(driver, DetalleDireccionUI.SelectCalle) == "0")
                {
                    Select.ByValue(driver, DetalleDireccionUI.SelectCalle, "1");
                    Thread.Sleep(2000);
                    Click.On(driver, DetalleDireccionUI.InputCalle);
                    Enter.Text(driver, DetalleDireccionUI.InputCalle, "Avenida Siempre Viva");
                    Select.ByValue(driver, DetalleDireccionUI.SelectNumero, "1");
                    Thread.Sleep(2000);
                    Click.On(driver, DetalleDireccionUI.InputNumero);
                    Enter.Text(driver, DetalleDireccionUI.InputNumero, "123");


                    Select.ByValue(driver, DetalleDireccionUI.SelectPais, "80");
                    Thread.Sleep(4000);
                    Select.ByValue(driver, DetalleDireccionUI.SelectProvincia, "15");
                    Thread.Sleep(5000);
                    Select.ByValue(driver, DetalleDireccionUI.SelectLocalidad, "326");
                    Thread.Sleep(5000);

                    Click.On(driver, DetalleDireccionUI.InputCodigoPostal);
                    Enter.JSTextById(driver, "_CODPOS", "Q8300NQN");
              
                    Click.On(driver, DetalleDireccionUI.BTNOPBTNCONFIRMAR);
                   // Click.On(driver, DetalleDireccionUI.BTNOPBTNFINALIZAR);
                    Thread.Sleep(200);
                    Click.On(driver, DetalleDireccionUI.BTNCONFIRMATION);
                    
                }
            }

        }

    }
 }

