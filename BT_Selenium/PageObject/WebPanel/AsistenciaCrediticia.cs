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
        //_BNQFB11ACT input activo total // 200.000
        //_BNQFB11PAT input pasivo total // 100.000
        public By InputPatrimonioNeto = By.Id("_BNQFB11PNT");//100.000
        //_BNQFB11RPG input resultado Antes Impuesto gcias // 100.000

        public By InputVtasAnuales = By.Id("_VTASANUALES"); //100.000
        //_BNQFB11ACO input Activo Corrriente // 100.000
        //_BNQFB11PAC input Pasivo corriente / 100.000
        public By InputResultadoEjerc = By.Id("_BNQFB11REJ");//100.000

        //Datos comerciales
        //_BNQFB11ANT Antioguedad Empresa // 1
        //_BNQFB11VPP Vtas 2021 //100.000
        //_BNQFB11VA1 Vtas 2020 //100.000
        //_BNQFB11VA2 vtas 2019 // 100.000

        public By BTN_SI = By.Id("BTNCONFIRMATION");
        public By BTN_NO = By.Id("BTNCANCELCONFIRMATION");

        //BTNOPCALCULOASISTENCIA Calcular Asistencia 
        //Perfil riesgo BTNOPPERFILDERIESGO
        //Confirmar
        //Si
        //Cerrar

            //bandeja
            //Seleccionar, Siguiente, Si // FIN!

        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");
    }



}
