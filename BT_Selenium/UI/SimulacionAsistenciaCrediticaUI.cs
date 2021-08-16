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

    public class SimulacionAsistenciaCrediticaUI
    {
        


        public static By InputVtasAnuales = By.Id("_VTASANUALES"); //10000
        public static By InputPatrimonioNeto = By.Id("_BNQFB11PNT");//10000
        public static By InputResultadoEjerc = By.Id("_BNQFB11REJ");//10000
        public static By InputAnosExperiencia = By.Id("_BNQFB11ERU");//1
        public static By InputCantidadEmp = By.Id("_BNQFB11CEM");//1
        public static By BTNOPSIMULACION = By.Id("BTNOPSIMULACION");
        public static By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public static By BTNOPCERRAR = By.Id("BTNOPCERRAR");
        public static By BTN_SI = By.Id("BTNCONFIRMATION");
        public static By BTN_NO = By.Id("BTNCANCELCONFIRMATION");

        


    }



}
