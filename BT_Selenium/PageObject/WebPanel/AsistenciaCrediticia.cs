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

    public class AsistenciaCrediticia : BasePage
    {
        //Datos de la actividad
        public By InputAnosExperiencia = By.Id("_BNQFB11ERU");//1
        public By InputCantidadEmp = By.Id("_BNQFB11CEM");//1

        //Datos Patrimoniales
        public By InputActivoTotal = By.Id("_BNQFB11ACT");// 200.000
        public By InputPasivoTotal = By.Id("_BNQFB11PAT");// 100.000
        public By InputPatrimonioNeto = By.Id("_BNQFB11PNT");//100.000
        public By InputResultadoAntesGcias = By.Id("_BNQFB11RPG");// 100.000

        public By InputVtasAnuales = By.Id("_VTASANUALES"); //100.000
        public By InputActivoCorriente = By.Id("_BNQFB11ACO"); //100.000
        public By InputPasivoCorriente = By.Id("_BNQFB11PAC"); //100.000
        public By InputResultadoEjerc = By.Id("_BNQFB11REJ");//100.000

        //Datos comerciales
        public By InputAntiguedadEmpresa = By.Id("_BNQFB11ANT");// 1
        public By InputVtasActual = By.Id("_BNQFB11VPP");// 100.000  //2021
        public By InputVtasAnterior1 = By.Id("_BNQFB11VA1");// 100.000  //2020
        public By InputVtasAnterior2 = By.Id("_BNQFB11VA2");// 100.000  //2019

        //Botonera inferior
        public By BTN_CalcularAsistencia = By.Id("BTNOPCALCULOASISTENCIA");
        public By BTN_PerfilRiesgo = By.Id("BTNOPPERFILDERIESGO");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");


        //Botones Si/NO
        public By BTN_SI = By.Id("BTNCONFIRMATION");
        public By BTN_NO = By.Id("BTNCANCELCONFIRMATION");
    }



}
