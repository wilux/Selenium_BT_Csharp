﻿using BT_Selenium.Handler;
using BT_Selenium.PageObject.WebPanel;
using BT_Selenium.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject
{
    /*
     * Clase para representar la pagina principal de BT
     */
    public class PrincipalPage : BasePage
    {

        //Localizadores
     

        //Menu General
        public By Menu = By.Id("menuBase");
        //Acceso
        public By Accesos = By.XPath("//a[@init='m0_1']");
        //Acceso -> Ejecutar
        public By Ejecutar = By.XPath("//a[@class='leafCompementWithShortcut']");
        //Inicio
        public By Inicio = By.XPath("//a[@init='m0_0']");
        //Inicio -> WorkFlow
        public By WF = By.XPath("//a[@init='m1_0']");
        //Inicio -> WorkFlow -> BANDEJA DE TAREAS
        public By BandejaTareas = By.XPath("//a[.='BANDEJA DE TAREAS']");

        public void MenuEjecutar(IWebDriver Driver)
        {
            driver = Driver;
            driver.FindElement(Ejecutar).Click();

        }

        public void MenuInicio(IWebDriver Driver)
        {
            driver = Driver;

            if (WaitHandler.ElementIsPresent(driver, Menu) == true)
            {
                driver.FindElement(Inicio).Click();
            }
            else
            {
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                driver.Manage().Window.Maximize();
                WaitHandler.Wait(driver, 5000);
                driver.FindElement(Inicio).Click();
            }

        }

        public void MenuWorkFlow(IWebDriver Driver)
        {
            driver = Driver;
            driver.FindElement(WF).Click();

        }

        public void MenuBandejaTareas(IWebDriver Driver)
        {
            driver = Driver;
            driver.FindElement(BandejaTareas).Click();
        
        }

        public PrincipalPage(IWebDriver Driver)
        {
          driver = Driver;

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Manage().Window.Maximize();


        }

      
        public PrincipalPage()
        {

        }





}
}
