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
        //Mensajes
        public static By MsgTextArriba = By.ClassName("MsgText");
        public static By MsgTextMedio = By.ClassName("HTMLTXTTEXT1");
        public static By MsgTextAbajo = By.ClassName("HTMLTXTTEXT5");

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
        public static By CheckPrestamo = By.Name("_BNQFPC5PP");
        public static By CheckTarjeta = By.Name("_BNQFPC5TC");
        public static By CheckCtaCte = By.Name("_CTACTE");
        public static By CheckCaDolar = By.Name("_CA_DOLARES");
        public static By CheckTC1= By.Name("_TCSEL_0001");
        public static By CheckTC2 = By.Name("_TCSEL_0002");
        public static By BTNOPPAQUETIZAR = By.Id("BTNOPPAQUETIZAR");
        public static By SelectCircuito = By.Name("_CICUITOS_CALIF_E");
        public static By BTNOPADHESION_SERVICIOS = By.Name("BTNOPADHESION_SERVICIOS");
        public static By BTNOPCERRAR = By.Id("BTNOPCERRAR");

        //Categoria Acuerdo BI
        public static By tablaAcuerdo = By.Id("TBL118");
        public static By spanTituloAcc = By.Id("HTMLTXTTITLE395");
        public static By checkActualizarAcc = By.Id("_ACTUALIZAACC");
        public static By inputMontoActualAcc = By.Id("span__JBNYC5ACIM");
        public static By inputMontoNuevoAcc = By.Id("_JBNYC5ACIM_NUEVO");


    }

}
