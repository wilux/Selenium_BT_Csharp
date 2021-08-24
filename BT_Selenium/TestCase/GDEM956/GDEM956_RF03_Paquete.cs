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


    [TestFixture, Description("Simula CA USD C/ paquete")]
    public class GDEM956_RF03_Paquete : BaseTest
    {
        [TestCase("27174708121")]
        [TestCase("23255760114")]
        public void Paquete(string documento)
        {
            string producto = "CTA.CORRIENTE $";
            string test = "Test2";
            string nroEntrevista = "";

            Entrevista.Iniciar(driver);
            Entrevista.IngresarDocumento(driver, documento);

            ////Pantalla Entrevista
            ////Completamos Datos Contacto
            Entrevista.Completar_DatosContacto(driver);
            Entrevista.SeleccionarCuentaCredito(driver);
            Entrevista.IngresosPF(driver);
            Entrevista.Confirmar(driver);
            Entrevista.Cerrar(driver);


            //Simular
            try
            {
                SimulacionProductos.PaqueteNombre(driver, producto);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
            WaitHandler.Wait(5000);
            Capturar.Pantalla(driver, test, documento);

            nroEntrevista = Entrevista.NroEntrevista(driver);

            
        }

       
    }

}
