using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using BT_Selenium.Task;
using System.Diagnostics;
using System.Collections;
using WindowsInput;
using WindowsInput.Native;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class HtestCausd : BaseTest_Reporte
    {
        //Prueba de Pantalla Entrevista
        //Tiempo que demora en completar datos

       // [TestCase("20133286838")]
       // [Test (ExpectedResult = true), Repeat(2)]
        public bool RFXX()
        {
            Stopwatch stopw = new Stopwatch();
            Login.In(driver);
            EjecutarPrograma.Ejecutar(driver, "htestcausd");
            string sql = "SELECT top 1 Ctnro, count(*) FROM FSR008 GROUP BY Ctnro HAVING COUNT(*)>3 ORDER BY NEWID()";
            string cuenta =   DB.ObtenerValorCampo(sql, "Ctnro");


            //input cuenta _CTNRO
            //btn BTNOPPPRD900
            //input resultado _PUEDEOPERAR
            By InputCuenta = By.Id("_CTNRO"); //step0
            Click.On(driver, InputCuenta);
            Enter.Text(driver, InputCuenta, cuenta);

            WaitHandler.Wait(2);
            By btnConsultar = By.Id("BTNOPPPRD900");
            Click.On(driver, btnConsultar);

            //InputSimulator sim = new InputSimulator();
            //sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_R);


            stopw.Stop();
            TestContext.Write(" Time elapsed: {0} ", stopw.Elapsed);

            WaitHandler.Wait(2);
            By InputResultado = By.Name("_PUEDEOPERAR"); //step2
            Click.On(driver, InputResultado);

            string resultado = Get.InputValue(driver, InputResultado);
            Reporte.Logger("Cuenta: " + cuenta + " Resultado: " + resultado);

            if (resultado != "" ){
                return true;
            }
            else
            {
                return false;
            }

           
            
        }

    }
}
