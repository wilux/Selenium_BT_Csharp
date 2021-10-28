using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    //Pantalla ABM domicilio
    public class DetalleDireccionUI
    {
        public static By InputFechaDesde = By.Id("_SNGC13RDES");
        public static By SelectCalle = By.Name("_SNGC01ID");
        public static By InputCalle = By.Id("_NOM1");
        public static By InputNumero = By.Id("_NOM2");
        public static By SelectNumero = By.Name("_SNGC02ID");
        public static By SelectPais = By.Name("_PAISDOM");
        public static By SelectProvincia = By.Name("_DODEPCODP");
        public static By SelectLocalidad = By.Name("_XLOCCOD");
        public static By InputCodigoPostal = By.Id("_CODPOS");
        public static By BTNOPBTNCONFIRMAR = By.Id("BTNOPBTNCONFIRMAR");
        public static By BTNCONFIRMATION = By.Id("BTNCONFIRMATION");
        public static By BTNOPBTNFINALIZAR = By.Id("BTNOPBTNFINALIZAR");
    }
}
