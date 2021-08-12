using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    //Documentacion - Calificacion Empresas

    public class Documentacion : BasePage
    {
        //Pantalla Documentacion
        public By inputFecha = By.Id("_BNQFB11UCB"); //fecha value "dd/MM/YYYY" // Desde fecha bT actual para atras
        public By Grilla_Documentos= By.Id("GRIDARCHIVOS");
        public By PrimerFila = By.Id("span__DESCRIPCION_00");//+ 01 to 10
        public By BTNOPAGREGAR = By.Id("BTNOPAGREGARLD");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");


    }



}
