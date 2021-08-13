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

        //Tramite
        public By campoTramite = By.Id("span__BNQFPA2NRO");

        //Datos personales
        public By inputApellido = By.Id("_BNQFPA2APE");
        public By inputNombre = By.Id("_BNQFPA2NOM"); 
        public By inputFechaNac = By.Id("_BNQFPA2FNA");
        public By SelectCapacidadLegal = By.Id("_PFCAPL");
        public By SelectSexo = By.Id("_BNQFPA2SEX");
        public By SelectNacionalidad = By.Id("_PFPNAC");
        public By SelectPaisCiudadania = By.Id("_PAIS");
        public By SelectProvincia = By.Id("_SNGC11DPTO");
        public By inputLocalidad = By.Id("_SNGC11PROV");//326 Neuquen
        public By SelectOcupacion = By.Id("_SNGC60OCUP");
        public By BTNOPDOMICILIOREAL = By.Id("BTNOPDOMICILIOREAL");
        public By CampoDomicilio = By.Id("span__BNQFPA2DOM");
        public By SelectTipo = By.Name("_BNQFPA2TDO");
        public By InputDocumento = By.Id("_BNQFPA2NDO");
        public By BTNOPVALIDAR = By.Id("BTNOPVALIDAR");
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

        //MsgText
        public By MsgText = By.ClassName("MsgText");

        public By tabla_HTMLTBLCAT245 = By.Id("HTMLTBLCAT245");
        public By GRIDACRED = By.Id("GRIDACRED");
        public By CampoAcreditaBPN = By.Name("span__ACREDITAENBPN_0001");
        //input hidden _ACREDITAENBPN_0001 SI o NO 
        //span__ACREDITAENBPN_0001

        public By SelectSectorEmpleador = By.Name("_BNQFPA2ORD");
        public By InputIngresosDepedencia = By.Name("_BNQFPA2IRD");

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

        public string GetText(IWebDriver driver, By locator)
        {
            frame.BuscarFrame(driver, locator);
            IWebElement l = driver.FindElement(locator);
            String text = l.Text;
            return text;

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

        public void irBandejaTareas(IWebDriver driver)
        {
            PrincipalPage principalPage = new PrincipalPage(driver);
            principalPage.MenuInicio(driver);
            principalPage.MenuWorkFlow(driver);
            principalPage.MenuBandejaTareas(driver);
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


        public void Completar_DatosPersonales(IWebDriver driver, string nombre= "John", string apellido = "Doe", string fecha="01/01/1981")
        {
            //Elegimos iframe (step10)
            if (driver.FindElement(inputNombre).Text=="") {
                driver.FindElement(inputNombre).SendKeys(nombre);
                driver.FindElement(inputApellido).SendKeys("Doe");
            }
            frame.BuscarFrame(driver, inputFechaNac);
            driver.FindElement(inputFechaNac).SendKeys(fecha);
            SeleccionarByValue(driver, SelectCapacidadLegal, "1");//Mayor edad
            if (driver.FindElement(SelectSexo).Text == "")
            {
                SeleccionarByValue(driver, SelectSexo, "M");//M
            }
            SeleccionarByValue(driver, SelectNacionalidad, "80");//80 argentina
            SeleccionarByValue(driver, SelectProvincia, "15");//15 Neuquen
            driver.FindElement(inputLocalidad).SendKeys("326");//326 Neuquen
            SeleccionarByValue(driver, SelectPaisCiudadania, "80");//80 argentina
        }

        public void Completar_Ocupacion(IWebDriver driver, string ocupacion="1")
        {
            SeleccionarByValue(driver, SelectOcupacion, ocupacion);//1 empleado x defecto
        }

        public void Completar_Domicilio(IWebDriver driver)
        {
            //Ver de agregar tiempos entre cada operacion
            DetalleDireccion detalleDireccion = new DetalleDireccion();
            SeleccionarByValue(driver, detalleDireccion.SelectCalle, "1");
            driver.FindElement(detalleDireccion.InputCalle).SendKeys("Calle Falsa");
            driver.FindElement(detalleDireccion.InputNumero).SendKeys("123");
            SeleccionarByValue(driver, detalleDireccion.SelectPais, "80");
            SeleccionarByValue(driver, detalleDireccion.SelectLocalidad, "326");
            driver.FindElement(detalleDireccion.InputCodigoPostal).SendKeys("Q8300NQN");
            driver.FindElement(detalleDireccion.BTNOPBTNCONFIRMAR).Click();
        }

        public void Completar_DatosContacto(IWebDriver driver)
        {

            //Pantalla Entrevista
            //Elegimos iframe
            frame.BuscarFrame(driver, InputMail);

            //Verificamos si tiene domicilio
            if (driver.FindElement(CampoDomicilio).Text == "") // No tiene nada
            {
                driver.FindElement(BTNOPDOMICILIOREAL).Click();// abre pantalla para completar domuicilio

            }

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
