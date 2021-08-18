using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    //Simulación - Venta de Productos
    public class AsistenciaCrediticiaUI
    {
        //Datos de la actividad
        public static By InputAnosExperiencia = By.Id("_BNQFB11ERU");//1
        public static By InputCantidadEmp = By.Id("_BNQFB11CEM");//1

        //Datos Patrimoniales
        public static By InputActivoTotal = By.Id("_BNQFB11ACT");// 200.000
        public static By InputPasivoTotal = By.Id("_BNQFB11PAT");// 100.000
        public static By InputPatrimonioNeto = By.Id("_BNQFB11PNT");//100.000
        public static By InputResultadoAntesGcias = By.Id("_BNQFB11RPG");// 100.000
        public static By InputVtasAnuales = By.Id("_VTASANUALES"); //100.000
        public static By InputActivoCorriente = By.Id("_BNQFB11ACO"); //100.000
        public static By InputPasivoCorriente = By.Id("_BNQFB11PAC"); //100.000
        public static By InputResultadoEjerc = By.Id("_BNQFB11REJ");//100.000

        //Datos comerciales
        public static By InputAntiguedadEmpresa = By.Id("_BNQFB11ANT");// 1
        public static By InputVtasActual = By.Id("_BNQFB11VPP");// 100.000  //2021
        public static By InputVtasAnterior1 = By.Id("_BNQFB11VA1");// 100.000  //2020
        public static By InputVtasAnterior2 = By.Id("_BNQFB11VA2");// 100.000  //2019

        //Solicitud Asistencia
        public static By SelectModulo = By.Id("_MODLINESP_P");// 303
        public static By SelectLinea = By.Id("TIPOPLINESP");// 20
        public static By InputMonto = By.Id("_BNQFB15MTO");// 100000
        public static By BTNOPAGREGAR = By.Id("BTNOPAGREGAR");
        
        //Botonera inferior
        public static By BTN_CalcularAsistencia = By.Id("BTNOPCALCULOASISTENCIA");
        public static By BTN_PerfilRiesgo = By.Id("BTNOPPERFILDERIESGO");
        public static By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public static By BTNOPCERRAR = By.Id("BTNOPCERRAR");



        //Botones Si/NO
        public static By BTN_SI = By.Id("BTNCONFIRMATION");
        public static By BTN_NO = By.Id("BTNCANCELCONFIRMATION");
    }



}
