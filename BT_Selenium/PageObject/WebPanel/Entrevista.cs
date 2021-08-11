using BT_Selenium.Handler;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    //HBNQFCB8 Flujo de Entrevista
    public class Entrevista : BasePage
    {

        Frame frame = new Frame();
        public Entrevista(IWebDriver Driver)
        {
            driver = Driver;
        }


        public By SelectTipo = By.Name("_BNQFPA2TDO");
        public By InputDocumento = By.Id("_BNQFPA2NDO");
        public By BTNOPVALIDAR = By.Id("BTNOPVALIDAR");
        //HTMLTBLCAT245 tabla
        public By InputMail = By.Name("_BNQFPA2MAI");
        public By NoMail = By.Name("_NOTIENEEMAIL");
        public By SelectTelefono = By.Name("_BNQFPA2TT1");
        public By SelectTelefono2 = By.Name("_BNQFPA2TT2");
        public By SelectCodigoArea = By.Name("_CODIGODEAERAT1");
        public By SelectCodigoArea2 = By.Name("_CODIGODEAERAT2");
        public By InputTelefono = By.Name("_BNQFPA2TE1");
        public By InputTelefono2 = By.Name("_BNQFPA2TE2");
        public By GridCtaDebito = By.Id("GRIDACRED");
        public By BTNOPELEGIRCTA = By.Id("BTNOPELEGIRCTA");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTN_SI = By.Id("BTNCONFIRMATION");
        public By BTN_NO = By.Id("BTNCANCELCONFIRMATION");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");

        // Value S o N
        public By RCheckGrupo = By.Id("_BNQFB11PGE");
        public By RCheckSociedad = By.Id("_BNQFB11SHE");

        //MsgText
        public By MsgText = By.ClassName("MsgText");

        // table GRIDACRED (cuentas actuales)
        //input hidden _ACREDITAENBPN_0001 SI o NO 
        //span__ACREDITAENBPN_0001

        public By SelectSectorEmpleador = By.Name("_BNQFPA2ORD");
        public By InputIngresosDepedencia = By.Name("_BNQFPA2IRD");
        //input _BNQFPA2IRD importe relacion depedendencia

        public By TipoPersona = By.Id("_PETIPO");

        public void Confirmar(IWebDriver driver)
        {
            frame.BuscarFrame(driver, BTNOPCONFIRMAR);
            driver.FindElement(BTNOPCONFIRMAR).Click();
        }

        public void Cerrar(IWebDriver driver)
        {
            frame.BuscarFrame(driver, BTNOPCERRAR);
            driver.FindElement(BTNOPCERRAR).Click();
        }

        public void SeleccionarByText(IWebDriver driver, By select, string text)
        {
            webElement = driver.FindElement(select);
            selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }

        public void SeleccionarByValue(IWebDriver driver, By select, string value)
        {
            webElement = driver.FindElement(select);
            selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(value);
        }

        public void SeleccionarByIndex(IWebDriver driver, By select, int index)
        {
            webElement = driver.FindElement(select);
            selectElement = new SelectElement(webElement);
            selectElement.SelectByIndex(index);
        }

        public string InputValue(IWebDriver driver, By locator)
        {
            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            ////set the text
            //jsExecutor.ExecuteScript($"document.getElementById('{input}').value='{value}'");
            ////get the text
            //string text = (string)jsExecutor.ExecuteScript($"return document.getElementById('{input}').value");

            string text = driver.FindElement(locator).GetAttribute("value");
            return text;
            
        }

        public void Iniciar(IWebDriver driver)
        {

            PrincipalPage principalPage = new PrincipalPage(driver);
            BandejaTareas bandejaTareas = new BandejaTareas();
            NuevaInstancia nuevaInstancia = new NuevaInstancia();

          

            //Menu ir a...Inicio>WF>BandejaTarea
            principalPage.MenuInicio(driver);
            principalPage.MenuWorkFlow(driver);
            principalPage.MenuBandejaTareas(driver);

            //WebPanel  hxwf900 - Bandeja de tareas
            //Iniciamos Nueva Tarea en Bandeja de tareas

            //Elegimos iframe
            frame.BuscarFrame(driver, bandejaTareas.BTNOPOINICIAR);
            WaitHandler.ElementIsPresent(driver, bandejaTareas.BTNOPOINICIAR);

            //Iniciar instancia
            driver.FindElement(bandejaTareas.BTNOPOINICIAR).Click();

            //Elegimos iframe
            frame.BuscarFrame(driver, nuevaInstancia.Entrevista_Identificacion);

    
            //Elegimos Instancia
            driver.FindElement(nuevaInstancia.Entrevista_Identificacion).Click();
            driver.FindElement(nuevaInstancia.BTNOPOINICIAR).Click();

        }

        public void Completar_DatosContacto(IWebDriver driver)
        {

            //Pantalla Entrevista
            //Elegimos iframe
            frame.BuscarFrame(driver, InputMail);

            //Mail, sino tiene tildamos, de lo contrario dejamos como esta.
            String mail = driver.FindElement(InputMail).GetAttribute("value");
            if (mail == "")
            {
                driver.FindElement(NoMail).Click();
            }


            //Campos Telefonico 1

            //Elegimos iframe
            frame.BuscarFrame(driver, SelectTelefono);
            String codigoArea = driver.FindElement(SelectCodigoArea).GetAttribute("value");
            if (codigoArea == "")
            {
                SeleccionarByText(driver, SelectTelefono, "Celular");
                SeleccionarByText(driver, SelectCodigoArea, "299");
                //Escribimos un numero telefonico 1 
                driver.FindElement(InputTelefono).Click();
                driver.FindElement(InputTelefono).SendKeys("4721234");
                driver.FindElement(InputTelefono).SendKeys(Keys.Return);
            }
            //Campos Telefonico 2
            String codigoArea2 = driver.FindElement(SelectTelefono2).GetAttribute("value");
            if (codigoArea2 == "")
                SeleccionarByText(driver, SelectTelefono2, "Seleccionar");
            SeleccionarByText(driver, SelectCodigoArea2, "Seleccionar");
            //Escribimos un numero telefonico 2 (Lo dejo vacio)
            driver.FindElement(InputTelefono2).Clear();

        }

        public void IngresosPF(IWebDriver driver)
        {
            //Ingresos
            //Elegimos iframe
            frame.BuscarFrame(driver, SelectSectorEmpleador);

            //Sector Empleador
            SeleccionarByText(driver, SelectSectorEmpleador, "Publico");


            //Importe Ingresos en Depedencia
            driver.FindElement(InputIngresosDepedencia).Click();
            driver.FindElement(InputIngresosDepedencia).SendKeys("10000");
            driver.FindElement(InputIngresosDepedencia).SendKeys(Keys.Return);

        }

        public void SeleccionarCuentaCredito(IWebDriver driver)
        {
            IWebElement GRIDACRED = driver.FindElement(GridCtaDebito);
            GRIDACRED.FindElement(By.TagName("td")).Click();
            driver.FindElement(BTNOPELEGIRCTA).Click();
        }

        public void IngresarDocumento(IWebDriver driver, string documento)
        {
            Entrevista entrevista = new Entrevista(driver);
            //Elegimos iframe
            frame.BuscarFrame(driver, entrevista.SelectTipo);
            if (documento.Substring(0, 1)=="3")
            {
                SeleccionarByText(driver, SelectTipo, "C.U.I.T.");
            }
            else
            {
                SeleccionarByText(driver, SelectTipo, "C.U.I.L.");
            }

            //Ingreso CUIL/CUIT del Cliente a entrevistar
            driver.FindElement(InputDocumento).SendKeys(documento);
            driver.FindElement(BTNOPVALIDAR).Click();
    }

    }
}
