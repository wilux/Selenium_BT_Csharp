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

    public class CargaAvanzada : BasePage
    {
        public By Select_NivelEduc = By.Id("_COMBONIVELEDUC");
        public By inputApellidoPadre = By.Id("_APEPADRE");
        public By inputApellidoMadre = By.Id("_APEMADRE");
        public By inputNombrePadre = By.Id("_NOMPADRE");
        public By inputNombreMadre = By.Id("_NOMMADRE");
        public By BTNOPDOMICILIOREAL = By.Id("BTNOPDOMICILIOREAL");
        public By BTNOPBUSCARWC = By.Id("BTNOPBUSCARWC");
        public By BinputOrigenFondos = By.Id("_ORIGENFONDOS");
        public By BTNOPACEPTAR = By.Id("BTNOPACEPTAR");
        public By BTNOPBTNCONFIRMAR = By.Id("BTNOPBTNCONFIRMAR");
        public By BTNOPBTNFINALIZAR = By.Id("BTNOPBTNFINALIZAR");
        public By BTN_SI = By.Id("BTNCONFIRMATION");
        public By BTN_NO = By.Id("BTNCANCELCONFIRMATION");


    }



}
