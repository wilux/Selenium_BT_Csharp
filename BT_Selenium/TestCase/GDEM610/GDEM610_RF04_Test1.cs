using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using BT_Selenium.Task;

namespace BT_Selenium.TestCase.GDEM610
{
    // "Simula Prestamo y tiene Paquete 20/1 y 20/5 C/ACC. "
    // "No debe muestrar mensaje de 20/5 sin acuerdo"

    //Incidente 001

    [TestFixture, Description("No debe mostrar mensaje de 20/5 sin acuerdo")]
    public class GDEM610_RF04_Test1 : BaseTest_Reporte
    {

        protected string usuarioPlataforma = "dechands";
        protected string documento = "20209502209";
        //protected string producto = "CTA.CORRIENTE $";
        protected string test = "Incidente 001";
        protected string nroEntrevista = "";


       // [Test, Order(1)]
       // public void BBSEntrevista()
       // {
       //     Login.As(driver, usuarioPlataforma);
       //     Entrevista.Iniciar(driver);
       //     Entrevista.IngresarDocumento(driver, documento);

       //     ////Pantalla Entrevista
       //     Entrevista.Completar_DatosContacto(driver);
       //     Entrevista.SeleccionarCuentaCredito(driver);
       //     Entrevista.IngresosPF(driver);
       //     Entrevista.Confirmar(driver);


       //     WaitHandler.Wait(driver, 5);
       //     Entrevista.Cerrar(driver);
       //     WaitHandler.Wait(driver, 5);

       //}


       // [Test, Order(2)]
       // public void BSimularProducto()
       // {
       //     Login.As(driver, usuarioPlataforma);

       //     string mensajeEsperado = "";
       //     string mensajeObtenido = "";
       //     //bandeja tarjetas
       //     IrHasta.BandejaDeTareas(driver);
       //     BandejaTareas.Filtrar(driver, documento);
       //     BandejaTareas.Siguiente(driver);
       //     BandejaTareas.Ejecutar(driver);

       //     //Simular
       //     WaitHandler.Wait(driver, 5);
       //     Capturar.Pantalla(driver, test, documento);
       //     Reporte.Logger("Prueba: " + test + "Cliente CUIL: " + documento + "Mensaje obtenido: " + mensajeObtenido);
       //     mensajeObtenido = SimulacionProductos.GetMensaje(driver);
       //     Assert.That(mensajeObtenido, Is.EqualTo(mensajeEsperado));
       // }

    }

}
