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
    // Alta de 20/5 para cliente con 20/1

    // En SimulacionProducto debe salir mensaje: "Ya tiene Cta.Cte con acuerdo Vigente. La 20-5 será creada sin acuerdo"



    [TestFixture, Description("Alta de 20/1 con 20/5")]
    public class GDEM610_RF04_Test5 : BaseTest
    {
        protected string usuarioPlataforma = "dechands";
        protected string usuarioGerentea = "liriac";
        protected string usuarioCreditos = "totij";
        protected string documento = "27307925597 ";
        //protected string producto = "CTA.CORRIENTE $";
        protected string producto = "CTA.CORRIENTE USF";
        protected string test = "Test5";


        [Test, Order(1)]
        public void ALogin()
        {
            Login.As(driver, usuarioPlataforma);


            //WaitHandler.Wait(5000);
            //Entrevista.Cerrar(driver);

        }
        [Test, Order(2)]
        public void BBSEntrevista()
        {
            Login.As(driver, usuarioPlataforma);
            Entrevista.Iniciar(driver);
            Entrevista.IngresarDocumento(driver, documento);

            ////Pantalla Entrevista
            Entrevista.Completar_DatosContacto(driver);
            Entrevista.SeleccionarCuentaCredito(driver);
            Entrevista.IngresosPF(driver);
            Entrevista.Confirmar(driver);
            WaitHandler.Wait(driver, 5);
            Entrevista.Cerrar(driver);
            

        }

            [Test, Order(3)]
        public void BSimularProducto()
        {
            Login.As(driver, usuarioPlataforma);

            string mensajeEsperado = "Ya tiene Cta.Cte con acuerdo Vigente. La 20-5 será creada sin acuerdo";
            string mensajeObtenido = "";
            //bandeja tarjetas
            IrHasta.BandejaDeTareas(driver);
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Avanzar(driver);

            //Simular
            SimulacionProductos.PaqueteNombre(driver, producto);
            WaitHandler.Wait(driver, 5);
            Capturar.Pantalla(driver, test, documento);
            mensajeObtenido = SimulacionProductos.GetMensaje(driver);
            SimulacionProductos.UnCheckPrestamo(driver);
            SimulacionProductos.Confirmar(driver);
            Assert.That(mensajeObtenido, Is.EqualTo(mensajeEsperado));
        }

        [Test, Order(4)]
        public void Carga_Avanzada()
        {
            Login.As(driver, usuarioPlataforma);
            IrHasta.BandejaDeTareas(driver);
            BandejaTareas.Filtrar(driver, documento);

            //Bandeja Tareas
            BandejaTareas.Tomar(driver);

            //Pantalla Carga Avanzada
            //Setea consulta Bridger Insight
            BridgerInsight.Consultar(documento, usuarioPlataforma);
            CargaAvanzada.OrigenFondos(driver);
            CargaAvanzada.Aceptar(driver);
        }

        [Test, Order(5)]
        public void DReutilizacionProducto()
        {
            Login.As(driver, usuarioPlataforma);
            IrHasta.BandejaDeTareas(driver);
            BandejaTareas.Filtrar(driver, documento);

            //Bandeja Tareas
            BandejaTareas.Tomar(driver);

            //Pantalla Reutilizacion Productos
            ReutilizacionABMProductos.SeleccionarSeguroVida(driver);
            ReutilizacionABMProductos.SeleccionarTarjeta(driver);
            ReutilizacionABMProductos.Aceptar(driver);
            ReutilizacionABMProductos.PerfilRiesgo(driver);
            MatrizRiesgo.Confirmar(driver);
            MatrizRiesgo.Cerrar(driver);
        }


        [Test, Order(6)]
        public void EConfirmacionGerente()
        {
           
            //ConfirmarInstanciaSuperior.Gerente(driver, documento, usuarioGerentea);
        }

        [Test, Order(7)]
        public void FConfirmacionCreditos()
        {
            ConfirmarInstanciaSuperior.Creditos(driver, documento, usuarioCreditos);
        }

      //  [Test, Order(9)]
        public void ComprobarAcuerdo()
        {
           
            //Consultar la DB si el acuerdo modulo 49 esta dado de baja

        }


        
    }

}
