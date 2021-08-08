using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    //HBNQFCB8 Flujo de Entrevista
    public class Entrevista : BasePage
    {
        public By SelectTipo = By.Name("_BNQFPA2TDO");
        public By InputDocumento = By.Id("_BNQFPA2NDO");
        public By BTNOPVALIDAR = By.Id("BTNOPVALIDAR");
        //HTMLTBLCAT245 tabla
        public By InputMail = By.Name("_BNQFPA2MAI");
        public By NoMail = By.Name("_NOTIENEEMAIL");
        public By SelectTelefono = By.Name("_BNQFPA2TT1");
        public By SelectTelefono2 = By.Name("_BNQFPA2TT2");
        public By SelectCodigoArea = By.Name("_CODIGODEAERAT1");
        public By SelectCodigoArea2 = By.Name("_CODIGODEAERAT2");
        public By InputTelefono = By.Name("_BNQFPA2TE1");
        public By InputTelefono2 = By.Name("_BNQFPA2TE2");
        public By GridCtaDebito = By.Id("GRIDACRED");
        public By BTNOPELEGIRCTA = By.Id("BTNOPELEGIRCTA");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");

        // table GRIDACRED (cuentas actuales)
        //input hidden _ACREDITAENBPN_0001 SI o NO 
        //span__ACREDITAENBPN_0001

        public By SelectSectorEmpleador = By.Name("_BNQFPA2ORD");
        public By InputIngresosDepedencia = By.Name("_BNQFPA2IRD");
        //input _BNQFPA2IRD importe relacion depedendencia

        public By TipoPersona = By.Name("_PETIPO");

        public void Seleccionar(IWebDriver driver, By select, String text)
        {
            webElement = driver.FindElement(select);
            selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }

    }
}
