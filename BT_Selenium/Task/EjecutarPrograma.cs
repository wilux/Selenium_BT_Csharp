using BT_Selenium.Actions;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;

namespace BT_Selenium.Task
{
    /*
     * Clase que lista todas las tareas para simular un prestamo persona 
     */
    public class EjecutarPrograma
    {

      public static void Ejecutar(IWebDriver driver, string programa)
        {

            Menu.Ejecutar(driver);
            //Pasamos al Frame principal/activo
            IWebElement iframe = driver.FindElement(By.Id("0"));
            driver.SwitchTo().Frame(iframe);
            driver.SwitchTo().Frame("step1");
            Enter.Text(driver, HomeUI._PROGRAMA, programa);
            Click.Simple(driver, HomeUI.BTNOPCONFIRMAR);
        }
    }
}
