using BT_Selenium.Task;


namespace BT_Selenium.TestCase
{
   //[TestFixture]
    public class CircuitoCalificacionTest : BaseTest
    {
        

       // [TestCase("BE")]
        public void Calificar(string circuito)
        {

            //Obtengo de DB
            //String cuit = DB.ObtenerCuit();
            //
            string documento = "30657249765";

            //Iniciar hasta CUIL/CUIT
            Entrevista.Iniciar(driver);

            //Quitar // Solo para no hacer todo desde cero
            //Menu ir a...Inicio>WF>BandejaTarea
            //entrevista.irBandejaTareas(driver);
            //Quitar

            //Seleccionamos tipo CUIT/CUIL e ingresamos documento
            Entrevista.IngresarDocumento(driver, documento);


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

            //Cuando es BE
            CalificarTask.PJ(driver, circuito);

        }

    }
}
