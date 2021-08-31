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



        public static void Fecha(IWebDriver driver, string fecha="01/01/2020")
        {
            Click.On(driver, DocumentacionUI.inputFecha);
            Enter.JSTextById(driver, "_BNQFB11UCB", fecha);
        }

        public static void AnioCierre(IWebDriver driver, string fecha = "2020")
        {
            Click.On(driver, DocumentacionUI.inputAnioCierre);
            Enter.Text(driver, DocumentacionUI.inputAnioCierre, fecha);
        }

        public static void SeleccionarFila(IWebDriver driver, string numero = "01")
        {
            string locator = "span__DESCRIPCION_00" + numero;
            By fila = By.Id(locator);
            Grid.SeleccionarFila(driver, DocumentacionUI.Grilla_Documentos, fila);
            Click.On(driver, DocumentacionUI.PrimerFila);
        }
        //public static void SeleccionarFila(IWebDriver driver, string numero="01")
        //{
            
        //    string fila = "span__DESCRIPCION_00"+numero;
        //    WaitHandler.Wait(3000);
        //    Click.On(driver, )

        //}

        public static void Agregar(IWebDriver driver)
        {
            WaitHandler.Wait(driver, 3);
            Click.On(driver, DocumentacionUI.BTNOPAGREGAR);

        }

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, DocumentacionUI.BTNOPCONFIRMAR);

        }

    }
}
