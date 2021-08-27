using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using BT_Selenium.Task;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class EntrevistaTest : BaseTest
    {
        //Prueba de Pantalla Entrevista

       // [TestCase("20133286838")]
        [TestCase("20209502209")]
        public void RFXX(string documento)
        {
         
            ////Iniciar hasta CUIL/CUIT
            //Entrevista.Iniciar(driver);
            //Entrevista.IngresarDocumento(driver, documento);

            ////Pantalla Entrevista
            IrHasta.BandejaDeTareas(driver);
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Avanzar(driver);
            ///Completar Datos que falten
            Entrevista.Completar_DatosPersonales(driver);
            Entrevista.Completar_DatosContacto(driver);
            Entrevista.Completar_Ocupacion(driver);

            ////Seleccionar Cuenta
            Entrevista.SeleccionarCuentaCredito(driver);

            ////Ingresos
            Entrevista.IngresosPF(driver);

            ////Confirmar Entrevista
            //Entrevista.Confirmar(driver);

        }

    }
}
