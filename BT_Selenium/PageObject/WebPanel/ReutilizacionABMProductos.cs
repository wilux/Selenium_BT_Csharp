using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    //Simulación - Venta de Productos

    public class ReutilizacionABMProductos : BasePage
    {
        public By GRID_TarjetasDebito = By.Id("GRIDGRDTD");
        public By PrimerTarjeta = By.Id("span__DESCTD_0001");
        public By BTNOPACEPTARTDNUEVA = By.Id("BTNOPACEPTARTDNUEVA");
        public By BTNOPPERFILDERIESGO = By.Id("BTNOPPERFILDERIESGO");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");
    }



}
