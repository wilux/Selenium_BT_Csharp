using BT_Selenium.Actions;
using BT_Selenium.Task;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using NUnit.Framework;

namespace BT_Selenium.TestCase.GDEM956
{
    // GDEM - 956 
    // RF 02 - Guardar resultado en nuevo campo BNQFPA2ACD
    // Consultar webservice de Bantotal según número de cuenta y guardar el valor devuelto.
    // Posible valores:
    // El servicio puede devolver "X" o "N" Cuando no es apto y "S" cuando lo es.
    // El servicio busca por cuenta y devuelve X o S
    // N solo cuando la consulta es por cuil, pero en la entrevista busca por cuenta.

    [TestFixture]
    public class GDEM956_RF02 : BaseTest
    {
        [TestCase("20133286838", ExpectedResult = "X")]
        [TestCase("23255760114", ExpectedResult = "S")]
        [TestCase("20209502209", ExpectedResult = "S")]
        [TestCase("27925159900", ExpectedResult = "X")]
        public string RF02(string documento)
        {

            string gdem = "GDEM956-RF02";

            //Iniciar hasta CUIL/CUIT
            Entrevista.Iniciar(driver);
            Entrevista.IngresarDocumento(driver, documento);

            ////Pantalla Entrevista

            ///Completar Datos que falten
            Entrevista.Completar_DatosPersonales(driver);
            Entrevista.Completar_DatosContacto(driver);
            Entrevista.Completar_Ocupacion(driver);

            ////Seleccionar Cuenta
            Entrevista.SeleccionarCuentaCredito(driver);

            ////Ingresos
            Entrevista.IngresosPF(driver);

            ////Confirmar Entrevista
            Entrevista.Confirmar(driver);

            //Obtener numero de entrevista
            string nroEntrevista = Entrevista.NroEntrevista(driver);

            //Consultar DB 
            string consulta = $"select * from bnqfpa2 where BNQFPA2Nro='{nroEntrevista}'";
            string estado = DB.ObtenerValorCampo(consulta, "BNQFPA2ACD");
            string mensaje = DB.ObtenerValorCampo(consulta, "BNQFPA2MCD");

            //Reporte
            Reporte.Logger(gdem+" - "+"CUIL: " +documento +" "+ "Entrevista Nro: "+ nroEntrevista + " - " + " Estado: "+estado +" Mensaje: "+ mensaje);

            //Assert.IsTrue(estado != " ");

            Navegador.Cerrar(driver);
            TestContext.Write("Cuil: "+documento + " Obtuvo: "+ estado);

            //Devuelvo resultado para comparar con si el resultado es el esperado o no.
            return estado;

        }

    }
}
