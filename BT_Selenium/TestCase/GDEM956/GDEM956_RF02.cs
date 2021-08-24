using BT_Selenium.Actions;
using BT_Selenium.Task;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using NUnit.Framework;

namespace BT_Selenium.TestCase.GDEM956
{

    [TestFixture]
    public class GDEM956_RF02 : BaseTest
    {
        //[TestCase("27174708121")]
        //[TestCase("23255760114")]
        //[TestCase("20133286838")]
        //[TestCase("27141334277")]
        //[TestCase("20147413271")]
        //[TestCase("20075784598")]
        //[TestCase("20075703873")]
        //[TestCase("20075641983")]
        //[TestCase("20073994145")]
        //[TestCase("27146744147")]
        //[TestCase("20927805260")]
        //[TestCase("20075694378")]
        //[TestCase("20926944976")]
        //[TestCase("20075760478")]
        //[TestCase("20075782471")]
        //[TestCase("20073317739")]
        //[TestCase("20924403633")]
        //[TestCase("23226915044")]
        //[TestCase("27164327022")]
        //[TestCase("20068971080")]
        //[TestCase("27141985472")]
        //[TestCase("20055144479")]





        public void RF02(string documento)
        {

            string gdem = "GDEM956-RF02";

            //Iniciar hasta CUIL/CUIT


            Entrevista.Iniciar(driver);

            ////Seleccionamos tipo CUIT/CUIL e ingresamos documento
            Entrevista.IngresarDocumento(driver, documento);


            ////Pantalla Entrevista

            ///Datos personales
            Entrevista.Completar_DatosPersonales(driver);

            ////Completamos Datos Contacto
            Entrevista.Completar_DatosContacto(driver);

            //Completar Ocupacion
            Entrevista.Completar_Ocupacion(driver);

            ////Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
            Entrevista.SeleccionarCuentaCredito(driver);



            ////Ingresos y Sector Empleador
            Entrevista.IngresosPF(driver);


            ////Confirmar Entrevista
            Click.Simple(driver, EntrevistaUI.BTNOPCONFIRMAR);

            ////Borrar
            //Entrevista.IraBandejaTareas(driver);
            //BandejaTareas.Ejecutar(driver);
            ////Borar

            //Obtener numero de entrevista
            string nroEntrevista = Get.InputValue(driver, EntrevistaUI.inputTramite);

            //Consultar DB 
            string consulta = $"select * from bnqfpa2 where BNQFPA2Nro='{nroEntrevista}'";
            string estado = DB.ObtenerValorCampo(consulta, "BNQFPA2ACD");
            string mensaje = DB.ObtenerValorCampo(consulta, "BNQFPA2MCD");

            //WaitHandler.Wait(3000);
            Reporte.Logger(gdem+" - "+"CUIL: " +documento +" "+ "Entrevista Nro: "+ nroEntrevista + " - " + " Estado: "+estado +" Mensaje: "+ mensaje);
            //DescartarTarea.Descartar(driver);
            Assert.IsTrue(estado != " ");

            //Descartar tarea va antes del Asser
            

        }

    }
}
