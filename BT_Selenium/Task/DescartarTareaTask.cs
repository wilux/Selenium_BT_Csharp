using BT_Selenium.PageObject;
using BT_Selenium.PageObject.WebPanel;
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
    public class DescartarTareaTask : BasePage
    {

        public DescartarTareaTask(IWebDriver Driver)
        {
            driver = Driver;
        }
        //Frames
        Steps steps = new Steps();

        //Hbnqfpb3 - Simular 
        SimulaPrestamo simulaPrestamo = new SimulaPrestamo();

        PrincipalPage principalPage = new PrincipalPage();


        public void Descartar()
        {



            //Pausa
            Thread.Sleep(8000);

            //Ingreso al menu hasta -> BandejaTareas
            driver.FindElement(principalPage.Inicio).Click();
            driver.FindElement(principalPage.WF).Click();
            driver.FindElement(principalPage.BandejaTareas).Click();

            Thread.Sleep(2000);
            //Hay que cambiar de frame
            //Pasamos al Frame principal/activo
            IWebElement iframe = driver.FindElement(By.Id("0"));
            driver.SwitchTo().Frame(iframe);
            

            // Descarta 10 tareas, hay que mejorar para que descarte X cantidad de tareas 
            for (int row = 1; row < 5; row++)
            {

                String a = "";
                String b = "";
                String c = "";

                if ((row % 2) == 0)
                    //par
                {
                    a = "step0";
                    b = "step3";
                    c = "step1";

                }//impar
                else
                {
                    a = "step1";
                    b = "step2";
                    c = "step0";
                }

                //Pausa
                Thread.Sleep(2000);

                if (row == 1)
                {
                    
                    driver.SwitchTo().Frame(a);
                }
                else
                {
                    IWebElement iframe2 = driver.FindElement(By.Id("0"));
                    driver.SwitchTo().Frame(iframe2);
                    driver.SwitchTo().Frame(a);
                }

                //Arranca en step1
                IWebElement GRIDINBOX = driver.FindElement(By.Id("GRIDINBOX"));
                GRIDINBOX.FindElement(By.Id("span__IDINSTANCIA_0001")).Click();


                //Pausa
                Thread.Sleep(2000);
                driver.FindElement(By.Id("BTNOPOEJECUTAR")).Click();

                //Pausa
                Thread.Sleep(2000);
                //En Nuevo Panel Descartar
                driver.SwitchTo().ParentFrame();
                driver.SwitchTo().Frame(c);//step0
                driver.FindElement(By.Id("BTNOPDESCARTAR")).Click();

                //Pausa
                Thread.Sleep(2000);
                //Confirmar SI
                driver.SwitchTo().ParentFrame();
                driver.SwitchTo().Frame(b);//step2
                driver.FindElement(By.Id("BTNCONFIRMATION")).Click();



            }
        }
       }
}
