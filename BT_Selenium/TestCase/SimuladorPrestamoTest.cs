using BT_Selenium.Handler;
using BT_Selenium.PageObject;
using BT_Selenium.Task;
using BT_Selenium.TestCase;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.TestCase
{
    [TestFixture]
    public class SimularPrestamoTest : BaseTest
    {
        //10000 = 100,000 cien mil 
        [TestCase("20303879618", "10000","4725555","50,000.00","36")]
        //[TestCase("20322717564", "15000", "4721111", "30,000.00", "24")]
        //[TestCase("20179364973", "19000", "4722222", "60,000.00", "18")]
        public void Simulador(String cuil, String ingresos, string telefono, String monto, String plazo)
        {
            //Login
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Ingresar();
            //Tareas
            SimularPrestamoTask simularPrestamoTask = new SimularPrestamoTask(driver);


            try
            {
                //Metodo simula prestamo BI
                simularPrestamoTask.BI(cuil, ingresos, telefono, monto, plazo);
                Console.WriteLine("Fin");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
                Capturar.Pantalla(driver, "Error", cuil);
              
                Reporte.Logger(e.Message);
                
                //Cierra todo
                driver.Quit();
                //Si hay error, iniciar descarte.
                //simularPrestamoTask.Descartar();
            }



        }

    }
}
