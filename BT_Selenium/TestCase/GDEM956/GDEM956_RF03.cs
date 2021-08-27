using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;

namespace BT_Selenium.TestCase.GDEM956
{
    // Modificar Simulacion segun valor guardado 

    // Solo para S muestra CA USD para agregar como monoproudcto o paquete
    // La prueba devuelve true solo si tiene S y muestra CAUSD
    // Si tiene X y muestra CAUSD la prueba falla. -> No debe mostrar CAUSD


    [TestFixture, Description("Simula CA USD Monoproducto")]
    public class GDEM956_RF03 : BaseTest
    {
        [TestCase("20133286838")]//X
        [TestCase("23255760114")]//S
        public void Monoproudcto(string documento)
        {
            string monoproducto = "CA. COMUN U$S";
            string paquete = "BPN SELECTO";

            Entrevista.Iniciar(driver);
            Entrevista.IngresarDocumento(driver, documento);

            ////Pantalla Entrevista
            ////Completamos Datos Contacto
            Entrevista.Completar_DatosContacto(driver);
            Entrevista.SeleccionarCuentaCredito(driver);
            Entrevista.IngresosPF(driver);
            Entrevista.Confirmar(driver);
            Entrevista.Cerrar(driver);


            BandejaTareas.Avanzar(driver);

            //Obtener numero de entrevista
            string nroEntrevista = Entrevista.NroEntrevista(driver);
            //Consultar DB 
            string consulta = $"select * from bnqfpa2 where BNQFPA2Nro='{nroEntrevista}'";
            string estado = DB.ObtenerValorCampo(consulta, "BNQFPA2ACD");

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

       
    }

}
