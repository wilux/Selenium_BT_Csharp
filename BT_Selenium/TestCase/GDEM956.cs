using BT_Selenium.Actions;
using BT_Selenium.Task;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using NUnit.Framework;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class GDEM956 : BaseTest
    {
       //[TestCase("27174708121")]
       [TestCase("23255760114")]
       //[TestCase("20133286838")]
       //[TestCase("27141334277")]

        public void RF02(string documento)
        {


            //Iniciar hasta CUIL/CUIT


            //Entrevista.Iniciar(driver);

            //////Seleccionamos tipo CUIT/CUIL e ingresamos documento
            //Entrevista.IngresarDocumento(driver, documento);


            //////Pantalla Entrevista

            //////Completamos Datos Contacto
            //Entrevista.Completar_DatosContacto(driver);

            //////Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
            //Entrevista.SeleccionarCuentaCredito(driver);



            //////Ingresos y Sector Empleador
            //Entrevista.IngresosPF(driver);


            //////Confirmar Entrevista
            //Click.Simple(driver, EntrevistaUI.BTNOPCONFIRMAR);

            //Borrar
            Entrevista.IraBandejaTareas(driver);
            BandejaTareas.Ejecutar(driver);
            //Borar

            //Obtener numero de entrevista
            string nroEntrevista = Get.InputValue(driver, EntrevistaUI.inputTramite);

            //Consultar DB 
            string consulta = $"select * from bnqfpa2 where BNQFPA2Nro='{nroEntrevista}'";
            string estado = DB.ObtenerValorCampo(consulta, "BNQFPA2ACD");
            string mensaje = DB.ObtenerValorCampo(consulta, "BNQFPA2MCD");

            //WaitHandler.Wait(3000);
            Reporte.Logger(documento + "Entrevista nro "+ nroEntrevista + " - " + " Estado: "+estado +" Mensaje: "+ mensaje);

            Assert.IsTrue(estado != " ");

            //Descartar tarea va antes del Asser
            //DescartarTarea.Descartar(driver);

        }

    }
}
