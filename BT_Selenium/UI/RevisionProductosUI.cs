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

    public class RevisionProductosUI
    {

        public static By TextObservaciones = By.Name("_BNQFPC5OBS");
        public static By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public static By BTNOPRECHAZAR = By.Id("BTNOPRECHAZAR");
        public static By BTNOPPERFILDERIESGO = By.Id("BTNOPPERFILDERIESGO");
        public static By BTNOPLIQUIDAR = By.Id("BTNOPLIQUIDAR");
        public static By BTN_SI = By.Id("BTNCONFIRMATION");
        public static By BTN_NO = By.Id("BTNCANCELCONFIRMATION");

    }



}
