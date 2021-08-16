using BT_Selenium.Actions;
using BT_Selenium.PageObject;
using BT_Selenium.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT_Selenium.Task
{
    /*
     * Clase que lista todas las tareas para simular un prestamo persona 
     */
    public class EjecutarProgramaTask
    {

        public EjecutarProgramaTask(IWebDriver Driver)
        {
            driver = Driver;
        }


      public void Ejecutar(IWebDriver driver, string programa)
        {
          
            PrincipalPage principalPage = new PrincipalPage(driver);
            principalPage.MenuEjecutar(driver);

            //Abrir programa (Iniciar Entrevista)
            driver.FindElement(By.Id("_PROGRAMA")).SendKeys(programa);
            driver.FindElement(By.Id("BTNOPCONFIRMAR")).Click();
        }
    }
}
