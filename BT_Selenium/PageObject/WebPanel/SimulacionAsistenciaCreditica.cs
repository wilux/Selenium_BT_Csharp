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

    public class SimulacionAsistenciaCreditica : BasePage
    {
        


        public By InputVtasAnuales = By.Id("_VTASANUALES"); //10000
        public By InputPatrimonioNeto = By.Id("_BNQFB11PNT");//10000
        public By InputResultadoEjerc = By.Id("_BNQFB11REJ");//10000
        public By InputAnosExperiencia = By.Id("_BNQFB11ERU");//1
        public By InputCantidadEmp = By.Id("_BNQFB11CEM");//1
        public By BTNOPSIMULACION = By.Id("BTNOPSIMULACION");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");
        public By BTN_SI = By.Id("BTNCONFIRMATION");
        public By BTN_NO = By.Id("BTNCANCELCONFIRMATION");

        


    }



}
