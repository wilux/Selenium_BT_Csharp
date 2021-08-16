using BT_Selenium.Actions;
using OpenQA.Selenium;


namespace BT_Selenium.UI
{
    /*
     * Clase para representar la pagina principal de BT
     */
    public class HomeUI
    {

        //Localizadores


        //Menu General
        public static By Menu = By.Id("menuBase");
        //Acceso
        public static By Accesos = By.XPath("//a[@init='m0_1']");
        //Acceso -> Ejecutar
        public static By Ejecutar = By.XPath("//a[@class='leafCompementWithShortcut']");
        //Inicio
        public static By Inicio = By.XPath("//a[@init='m0_0']");
        //Inicio -> WorkFlow
        public static By WF = By.XPath("//a[@init='m1_0']");
        //Inicio -> WorkFlow -> BANDEJA DE TAREAS
        public static By BandejaTareas = By.XPath("//a[.='BANDEJA DE TAREAS']");


    }
}
