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
    public class GDEM610_RF04_Test5_todo : BaseTest_Reporte
    {
        protected string usuarioPlataforma = "dechands";
        protected string usuarioGerentea = "liriac";
        protected string usuarioCreditos = "totij";
       // protected string documento = "27307925597 ";
        //protected string producto = "CTA.CORRIENTE $";
        //protected string producto = "CTA.CORRIENTE USF";
        protected string test = "Test5";
        protected string mensajeEsperado = "Ya tiene Cta.Cte con acuerdo Vigente. La 20-5 será creada sin acuerdo";
        protected string mensajeObtenido = "";

       // [TestCase("20133286838", "CTA.CORRIENTE USF")]
        public void RF04(string documento, string producto)
        {
            // 1.-Login
            Login.As(driver, usuarioPlataforma);

            //2.-Iniciar Entrevista y Completar
            Entrevista.Completar(driver);

            //3 .-Simular
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Siguiente(driver);
            BandejaTareas.Ejecutar(driver);
            SimulacionProductos.PaqueteNombre(driver, producto);
            WaitHandler.Wait(5);
            Capturar.Pantalla(driver, test, documento);
            mensajeObtenido = SimulacionProductos.GetMensaje(driver);
            SimulacionProductos.UnCheckPrestamo(driver);
            SimulacionProductos.Confirmar(driver);

            //Carga Avanzada
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Tomar(driver);
            BridgerInsight.Consultar(documento, usuarioPlataforma);
            CargaAvanzada.OrigenFondos(driver);
            CargaAvanzada.Aceptar(driver);

            //Pantalla Reutilizacion Productos
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Tomar(driver);
            ReutilizacionABMProductos.SeleccionarSeguroVida(driver);
            ReutilizacionABMProductos.SeleccionarTarjeta(driver);
            ReutilizacionABMProductos.Aceptar(driver);
            ReutilizacionABMProductos.PerfilRiesgo(driver);
            MatrizRiesgo.Confirmar(driver);
            MatrizRiesgo.Cerrar(driver);

            //Confirma Gerente
            //ConfirmarInstanciaSuperior.Gerente(driver, documento, usuarioGerentea);

            //Confirma Creditos
            ConfirmarInstanciaSuperior.Creditos(driver, documento, usuarioCreditos);

            ////Consultar la DB si el acuerdo modulo 49 esta dado de baja

        }
    }

}
