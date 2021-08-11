using BT_Selenium.PageObject;
using BT_Selenium.Task;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT_Selenium.Handler;
using System.Data.SqlClient;
using System.Data;
using BT_Selenium.PageObject.WebPanel;
using System.Threading;

namespace BT_Selenium.TestCase
{
   //[TestFixture]
    public class CircuitoCalificacionTest : BaseTest
    {
        

        [TestCase("BE")]
        public void Calificar(string circuito)
        {
            Entrevista entrevista = new Entrevista(driver);
            CalificarTask calificarTask = new CalificarTask(driver);

            //Obtengo de DB
            //String cuit = DB.ObtenerCuit();
            //
            String documento = "30657249765";
            //String ingresos = "10000";
            //String telefono = "4725555";
            //String monto = "500000";
            //String plazo = "12";

            //Iniciar hasta CUIL/CUIT
            entrevista.Iniciar(driver);

            //Seleccionamos tipo CUIT/CUIL e ingresamos documento
            entrevista.IngresarDocumento(driver, documento);

            calificarTask.PJ(circuito);

            //Corregir validacion para tipo de persona

            //if (documento.Substring(0) == "3")
            //{
            //    //Llamo a Calificar para PJ
            //    calificarTask.PJ(circuito);

            //}
            //else
            //{
            //    //Llamo a Calificar para PF
            //    //calificarTask.PF();
            //    Console.WriteLine("PF");
            //}




        }

    }
}
