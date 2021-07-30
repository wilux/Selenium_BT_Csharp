using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject.WebPanel
{
    //Simulación - Venta de Productos

    public class SimulaPrestamo : BasePage
    {
        
        public By SelectPaquete = By.Name("_JBNYC5PQTE");
        public By SelectLineaPrestamo = By.Name("_LINEA");
        public By InputMonto = By.Name("_BNQFPC5MTO"); 
        public By InputPlazo = By.Name("_BNQFPC5PZO");
        public By SelectDestinoFondos = By.Name("_BNQFPC5DES");
        public By BTNOPSIMULAR = By.Id("BTNOPSIMULAR");
        public By BTNOPDESCARTAR = By.Id("BTNOPDESCARTAR");
        public By BTNCONFIRMATION = By.Id("BTNCONFIRMATION");
        public By ValorCuotaAprox = By.Name("_BNQFPC5CUO");
        public By ValorTna = By.Name("_BNQFPC5TNA");
        public By ValorTem = By.Name("_BNQFPC5TEM");
        public By ValorTea = By.Name("_BNQFPC5TEA");

    }
}
