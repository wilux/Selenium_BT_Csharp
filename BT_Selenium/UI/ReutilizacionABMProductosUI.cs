using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.UI
{
    //Simulación - Venta de Productos

    public class ReutilizacionABMProductosUI
    {
        public static By GRID_TarjetasDebito = By.Id("GRIDGRDTD");
        public static By PrimerTarjeta = By.Id("span__DESCTD_0001");
        public static By BTNOPACEPTARTDNUEVA = By.Id("BTNOPACEPTARTDNUEVA");
        public static By BTNOPACEPTARTExistente = By.Id("BTNOPACEPTARTDEXISTENTE");
        public static By BTNOPPERFILDERIESGO = By.Id("BTNOPPERFILDERIESGO");
        public static By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public static By BTNOPCERRAR = By.Id("BTNOPCERRAR");
        public static By SelectSeguroVida = By.Name("_BNQFPC5SCC");
    }



}
