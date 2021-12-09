
using NUnit.Framework;
using BT_Selenium.Task;


namespace BT_Selenium.TestCase.GDEM956
{
    // Modificar Simulacion segun valor guardado 

    // Solo para S muestra CA USD para agregar como monoproudcto o paquete
    // La prueba devuelve true solo si tiene S y muestra CAUSD
    // Si tiene X y muestra CAUSD la prueba falla. -> No debe mostrar CAUSD


    //[TestFixture, Description("Simula CA USD Monoproducto")]
    public class GDEM956_RF03 : BaseTest_Reporte
    {

        //Ante de empezar todas las pruebas
        [OneTimeSetUp]
        public void Before()
        {
            Login.As(driver, "dechands");

        }




        //[TestCase("20351785846", TestName = "Test1", Category = "Datos Validos")]
        //[TestCase("20351785846")]//Conjunta todos S
        //[TestCase("20351785846")]//Conjunta Alguno N
        public void Simulacion(string documento)
        {
            string monoproducto = "CA. COMUN U$S"; //value 12
            string paquete = "BPN CLASICO"; // value 1

            Entrevista.Iniciar(driver);
            Entrevista.IngresarDocumento(driver, documento);


            ////Pantalla Entrevista
            ////Completamos Datos Contacto
            Entrevista.DatosContacto(driver);
            Entrevista.BuscarCuenta(driver);
            Entrevista.Ingresos(driver);
            Entrevista.Confirmar(driver);
            Entrevista.Cerrar(driver);

            //Borrar//
            //Entrevista.IraBandejaTareas(driver);

            BandejaTareas.Avanzar(driver);

            //Obtener numero de entrevista
            string nroEntrevista = Entrevista.NroEntrevista(driver);
            //Consultar DB 
            string consulta = $"select * from bnqfpa2 where BNQFPA2Nro='{nroEntrevista}'";
            //string estado = DB.ObtenerValorCampo(consulta, "BNQFPA2ACD");

            //Borrar
            string estado = "S";

            if (estado == "X")
            {

              Assert.IsFalse (SimulacionProductos.ValidarProducto(driver, monoproducto) ||
                  SimulacionProductos.ValidarProducto(driver, paquete));
            }
            else
            {
                Assert.IsTrue(SimulacionProductos.ValidarProducto(driver, monoproducto) ||
                  SimulacionProductos.ValidarProducto(driver, paquete));
            }  
            
        }

        //Al finalizar una prueba individual
        //[TearDown]
        //public void AfterTest()
        //{

        //}

        //Al finalizar todas las pruebas
        //[OneTimeTearDown]
        //public void After()
        //{
        //    try
        //    {
 
        //    }
        //    catch { }
        //}


    }

}
