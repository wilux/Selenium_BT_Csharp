using BT_Selenium.Actions;
using BT_Selenium.PageObject;
using BT_Selenium.UI;
using BT_Selenium.Task;
using BT_Selenium.TestCase;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
       // [TestCase("20303879618", "50,000.00", "36")]
        //[TestCase("20322717564", "30,000.00", "24")]
        //[TestCase("20179364973", "60,000.00", "18")]
        //[TestCase("40303879618", "50,000.00", "36")]// Con falla (cuil invalido)
        public void Simulador(String documento, String monto, String plazo)
        {
            //Instancias
            SimularPrestamoTask simularPrestamoTask = new SimularPrestamoTask(driver);

            //Tareas
            simularPrestamoTask.BI(documento, monto, plazo);


        }

    }
}
