using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    //Pantalla ABM domicilio
    public class DetalleDireccionUI
    {
        public static By InputFechaDesde = By.Id("_SNGC13RDES");
        public static By SelectCalle = By.Id("_SNGC01ID");
        public static By InputCalle = By.Id("_NOM1");
        public static By InputNumero = By.Id("_NOM2");
        public static By SelectNumero = By.Id("_SNGC02ID");
        public static By SelectPais = By.Id("_PAISDOM");
        public static By SelectProvincia = By.Id("_DODEPCODP");
        public static By SelectLocalidad = By.Id("_XLOCCOD");
        public static By InputCodigoPostal = By.Id("_CODPOS");
        public static By BTNOPBTNCONFIRMAR = By.Id("BTNOPBTNCONFIRMAR");
        public static By BTNOPBTNFINALIZAR = By.Id("BTNOPBTNFINALIZAR");
    }
}
