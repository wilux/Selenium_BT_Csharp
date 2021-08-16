using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    //Identificacion Cliente - Validacion
    public class IdentificacionClienteValidacionUI
    {
        // Value S o N
        public static By RCheckGrupo = By.Id("_BNQFB11PGE");
        public static By RCheckSociedad = By.Id("_BNQFB11SHE");

        //MsgText  //Pendiente de confirmación de la Gcia. de Créditos
        public static By MsgText = By.ClassName("MsgText"); 
        public static By Estado = By.Id("_BNQFB11EST");
        public static By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public static By BTNOPCERRAR = By.Id("BTNOPCERRAR");
        public static By BTN_SI = By.Id("BTNCONFIRMATION");
        public static By BTN_NO = By.Id("BTNCANCELCONFIRMATION");

    }
}
