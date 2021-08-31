using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    //Documentacion - Calificacion Empresas
    public class DocumentacionUI
    {
        //Pantalla Documentacion
        public static By inputFecha = By.Name("_BNQFB11UCB"); //fecha value "dd/MM/YYYY" // Desde fecha bT actual para atras
        public static By inputAnioCierre = By.Id("_BNQFB11CCA");
        public static By Grilla_Documentos= By.Id("GRIDARCHIVOS");
        public static By PrimerFila = By.Id("span__DESCRIPCION_00");//+ 01 to 10
        public static By BTNOPAGREGAR = By.Id("BTNOPAGREGARLD");
        public static By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public static By BTNOPCERRAR = By.Id("BTNOPCERRAR");

    }
}
