using BT_Selenium.Actions;
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

    public class SimulacionProductosUI
    { 
        //MsgText
        public static By MsgText = By.ClassName("MsgText");
        public static By SelectPaquete = By.Name("_JBNYC5PQTE");
        public static By SelectLineaPrestamo = By.Name("_LINEA");
        public static By InputMonto = By.Name("_BNQFPC5MTO"); 
        public static By InputPlazo = By.Name("_BNQFPC5PZO");
        public static By SelectDestinoFondos = By.Name("_BNQFPC5DES");
        public static By BTNOPSIMULAR = By.Id("BTNOPSIMULAR");
        public static By BTNOPDESCARTAR = By.Id("BTNOPDESCARTAR");
        public static By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public static By BTN_SI = By.Id("BTNCONFIRMATION");
        public static By BTN_NO = By.Id("BTNCANCELCONFIRMATION");
        //public static By BTNCONFIRMATION = By.Id("BTNCONFIRMATION");
        public static By ValorCuotaAprox = By.Name("_BNQFPC5CUO");
        public static By ValorTna = By.Name("_BNQFPC5TNA");
        public static By ValorTem = By.Name("_BNQFPC5TEM");
        public static By ValorTea = By.Name("_BNQFPC5TEA");
        public static By CheckCalificacion = By.Name("_BNQFPC5CBE");
        public static By SelectCircuito = By.Name("_CICUITOS_CALIF_E");
        public static By BTNOPADHESION_SERVICIOS = By.Name("BTNOPADHESION_SERVICIOS");
        public static By BTNOPCERRAR = By.Id("BTNOPCERRAR");

    }

}
