using BT_Selenium.Actions;
using BT_Selenium.Tools;
using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    //Documentacion - Calificacion Empresas
    public class Documentacion
    {
        //Pantalla Documentacion
        //Seleccionar fila documentcion  (1 sola para IN)
        //Botn Agregar


        public static void SeleccionarFila(IWebDriver driver)
        {
            Click.On(driver, DocumentacionUI.PrimerFila);

        }

        public static void Agregar(IWebDriver driver)
        {
            Click.On(driver, DocumentacionUI.BTNOPAGREGAR);

        }

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, DocumentacionUI.BTNOPCONFIRMAR);

        }

    }
}
