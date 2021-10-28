using BT_Selenium.Actions;
using OpenQA.Selenium;


namespace BT_Selenium.UI
{
    /*
     * Clase para representar la pagina principal de BT
     */
    public class WebPanelGenericoUI
    {

        //Localizadores
        //HTMLTXTTITLE1
        //public static By Titulo = By.CssSelector(".MainTitle");
        public static By Titulo = By.Id("HTMLTXTTITLE1");
        public static By Mensaje = By.CssSelector(".MsgText");
        public static By Wait = By.XPath("//img[@src='http://btwebqa.ar.bpn/BTWeb/images/wait.gif']");
        //public static By Wait = By.Id("waitMessage");

    }
}
