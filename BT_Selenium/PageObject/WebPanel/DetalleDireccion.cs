using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    //Pantalla para agregar/modificar direccion

    public class DetalleDireccion : BasePage
    {
        public By InputFechaDesde = By.Id("_SNGC13RDES");
        public By SelectCalle = By.Id("_SNGC01ID");
        public By InputCalle = By.Id("_NOM1");
        public By InputNumero = By.Id("_NOM2");
        public By SelectNumero = By.Id("_SNGC02ID");
        public By SelectPais = By.Id("_PAISDOM");
        public By SelectProvincia = By.Id("_DODEPCODP");
        public By SelectLocalidad = By.Id("_XLOCCOD");
        public By InputCodigoPostal = By.Id("_CODPOS");
        public By BTNOPBTNCONFIRMAR = By.Id("BTNOPBTNCONFIRMAR");
        public By BTNOPBTNFINALIZAR = By.Id("BTNOPBTNFINALIZAR");


    }



}
