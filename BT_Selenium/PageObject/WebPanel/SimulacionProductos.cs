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
    //Simulación - Venta de Productos


    public class SimulacionProductos : BasePage
    {
        Frame frame = new Frame();

        //MsgText
        public By MsgText = By.ClassName("MsgText");
        public By SelectPaquete = By.Name("_JBNYC5PQTE");
        public By SelectLineaPrestamo = By.Name("_LINEA");
        public By InputMonto = By.Name("_BNQFPC5MTO"); 
        public By InputPlazo = By.Name("_BNQFPC5PZO");
        public By SelectDestinoFondos = By.Name("_BNQFPC5DES");
        public By BTNOPSIMULAR = By.Id("BTNOPSIMULAR");
        public By BTNOPDESCARTAR = By.Id("BTNOPDESCARTAR");
        public By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public By BTN_SI = By.Id("BTNCONFIRMATION");
        public By BTN_NO = By.Id("BTNCANCELCONFIRMATION");
        //public By BTNCONFIRMATION = By.Id("BTNCONFIRMATION");
        public By ValorCuotaAprox = By.Name("_BNQFPC5CUO");
        public By ValorTna = By.Name("_BNQFPC5TNA");
        public By ValorTem = By.Name("_BNQFPC5TEM");
        public By ValorTea = By.Name("_BNQFPC5TEA");
        public By CheckCalificacion = By.Name("_BNQFPC5CBE");
        public By SelectCircuito = By.Name("_CICUITOS_CALIF_E");
        public By BTNOPADHESION_SERVICIOS = By.Name("BTNOPADHESION_SERVICIOS");
        public By BTNOPCERRAR = By.Id("BTNOPCERRAR");

        public void Confirmar(IWebDriver driver)
        {
            frame.BuscarFrame(driver, BTNOPCONFIRMAR);
            driver.FindElement(BTNOPCONFIRMAR).Click();
        }

        public void Si(IWebDriver driver)
        {
            frame.BuscarFrame(driver, BTN_SI);
            driver.FindElement(BTN_SI).Click();

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

        public void LineaPrestamo(IWebDriver driver)
        {
            IWebElement Linea = driver.FindElement(SelectLineaPrestamo);
            SelectElement SelectLinea = new SelectElement(Linea);
            SelectLinea.SelectByIndex(1);//Elijo la primera disponible.
            Linea.SendKeys(Keys.Return);
        }

        public void MontoPrestamo(IWebDriver driver, string monto)
        {
            frame.BuscarFrame(driver, InputMonto);
            driver.FindElement(InputMonto).Clear();
            driver.FindElement(InputMonto).Click();
            driver.FindElement(InputMonto).SendKeys(monto);
        }

        public void PlazoPrestamo(IWebDriver driver, string plazo)
        {
            driver.FindElement(InputPlazo).Clear();
            driver.FindElement(InputPlazo).SendKeys(plazo);
        }

        public void DesinoFondos(IWebDriver driver)
        {
            Entrevista entrevista = new Entrevista(driver);
            driver.FindElement(SelectDestinoFondos).Click();
            entrevista.SeleccionarByText(driver, SelectDestinoFondos, "Otros");
        }
    }



}
