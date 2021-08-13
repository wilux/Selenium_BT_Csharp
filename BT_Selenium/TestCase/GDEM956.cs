using BT_Selenium.Handler;
using BT_Selenium.PageObject;
using BT_Selenium.PageObject.WebPanel;
using BT_Selenium.Task;
using BT_Selenium.TestCase;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class GDEM956 : BaseTest
    {
       [TestCase("27174708121")]
       [TestCase("23255760114")]
       [TestCase("20133286838")]
       [TestCase("27141334277")]

        public void RF02(string documento)
        {
            Frame frame = new Frame();
            Entrevista entrevista = new Entrevista(driver);
            BandejaTareas bandejaTareas = new BandejaTareas();
            SimulacionProductos simulacionProductos = new SimulacionProductos();

            //entrevista.irBandejaTareas(driver);//despues Borrar solo prueba
            //Iniciar hasta CUIL/CUIT


            entrevista.Iniciar(driver);

            ////Seleccionamos tipo CUIT/CUIL e ingresamos documento
            entrevista.IngresarDocumento(driver, documento);


            ////Pantalla Entrevista

            ////Completamos Datos Contacto
            entrevista.Completar_DatosContacto(driver);

            ////Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
            entrevista.SeleccionarCuentaCredito(driver);



            ////Ingresos y Sector Empleador
            entrevista.IngresosPF(driver);


            ////Confirmar Entrevista
            driver.FindElement(entrevista.BTNOPCONFIRMAR).Click();

            ////Borrar
            //entrevista.irBandejaTareas(driver);
            //bandejaTareas.Ejecutar(driver);
            ////Borar

            //Obtener numero de entrevista
            string nroEntrevista = entrevista.GetText(driver, entrevista.campoTramite);

            //Consultar DB 
            string consulta = $"select * from bnqfpa2 where BNQFPA2Nro='{nroEntrevista}'";
            string estado = DB.ObtenerValorCampo(consulta, "BNQFPA2ACD");
            string mensaje = DB.ObtenerValorCampo(consulta, "BNQFPA2MCD");

            WaitHandler.Wait(driver, 3000);
            Reporte.Logger(documento + "Entrevista nro "+ nroEntrevista + " - " + " Estado: "+estado +" Mensaje: "+ mensaje);




        }

    }
}
