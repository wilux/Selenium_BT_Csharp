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

    public class AgregarDocumento : BasePage
    {
        public By inputFecha = By.Id("_FECHAVALOR");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");
        public By inputBuscarArchivo = By.Id("htmlInputFileUpload3");

    }



}
