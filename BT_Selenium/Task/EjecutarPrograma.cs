using BT_Selenium.Actions;
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
            //Abrir programa (Iniciar Entrevista)
            Enter.Text(driver, HomeUI._PROGRAMA, programa);
            Click.On(driver, HomeUI.BTNOPCONFIRMAR);
        }
    }
}
