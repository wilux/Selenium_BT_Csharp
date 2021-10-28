using BT_Selenium.Task;
using NUnit.Framework;
using System;

namespace BT_Selenium.TestCase.Otras
{

    [TestFixture]
    public class SimularPrestamoTest : BaseTest
    {
       

        //10000 = 100,000 cien mil 
        //[TestCase("20303879618", "50,000.00", "36")]
        //[TestCase("20322717564", "30,000.00", "24")]
        //[TestCase("20179364973", "60,000.00", "18")]
        //[TestCase("40303879618", "50,000.00", "36")]// Con falla (cuil invalido)
        public void Simulador(String documento, String monto, String plazo)
        {

            //Tareas
            SimularPrestamoTask.BI(driver, documento, monto, plazo);


        }

    }
}
