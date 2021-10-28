using NUnit.Framework;
using BT_Selenium.Task;


namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class EntrevistaTest : BaseTest
    {

        //Ante de empezar todas las pruebas
        [OneTimeSetUp]
        public void Before()
        {
            Login.In(driver);
        }

        //Prueba de Pantalla Entrevista
        //Tiempo que demora en completar datos

       //  [TestCase("23179516314")]
        //[TestCase("1010198")]
        public void Completar(string documento)
        {

            ////Iniciar hasta CUIL/CUIT
            //Entrevista.Iniciar(driver);
            //Entrevista.IngresarDocumento(driver, documento);

            //Pantalla Entrevista
            IrHasta.BandejaDeTareas(driver);
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Ejecutar(driver);
            Entrevista.DatosPersonales(driver);
            Entrevista.Ocupacion(driver);
            Entrevista.DatosContacto(driver);

            //Seleccionar Cuenta
            Entrevista.BuscarCuenta(driver);

            //Ingresos
            Entrevista.Ingresos(driver);


            ////Confirmar Entrevista
            Entrevista.Confirmar(driver);

        }

        [OneTimeTearDown]
        public void After()
        {
            try
            {

            }
            catch { }
        }

    }
}
