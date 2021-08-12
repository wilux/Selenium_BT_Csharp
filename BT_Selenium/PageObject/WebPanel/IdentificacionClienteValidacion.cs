using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    //Identificacion Cliente - Validacion

    public class IdentificacionClienteValidacion : BasePage
    {

        // Value S o N
        public By RCheckGrupo = By.Id("_BNQFB11PGE");
        public By RCheckSociedad = By.Id("_BNQFB11SHE");

        //MsgText  //Pendiente de confirmación de la Gcia. de Créditos
        public By MsgText = By.ClassName("MsgText"); 
        
        public By Estado = By.Id("_BNQFB11EST");

        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");

        public By BTN_SI = By.Id("BTNCONFIRMATION");
        public By BTN_NO = By.Id("BTNCANCELCONFIRMATION");


    }



}
