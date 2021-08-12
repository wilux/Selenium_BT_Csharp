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

    public class ConsultaBridgerInsight : BasePage
    {
        public By BTNOPBUSCARBRIDGER = By.Id("BTNOPBUSCARBRIDGER");
        public By BTN_SinCoincidencia = By.Id("BTNOPIMPRSCOINCIDENCIA");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");
        public By Volver_CargaAvanzada = By.LinkText("CARGA AVANZADA");

    }



}
