using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using BT_Selenium.Task;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class Calificar : BaseTest
    {

      //  [Test]
        public void CircuitoIN()
        {
            //string gdem = "GDEMXXX-RFXX";
            string documento = "30657249765";

            IrHasta.SimularProducto(driver, documento);
            ////Cerrar para continuar siguiente pantalla
            Entrevista.Cerrar(driver);

            //Solo para Retomar en pruebas
            //IrHasta.RetomarTramiteBandeja(driver, documento);

            //Cerrar
            //Seleccionar
            //Siguiente
            //Si
            //ejecutar



            ////Volvemos a hxwf900 - Bandeja de Entrada de Tareas
            BandejaTareas.Siguiente(driver);

            //Seleccionar
            //Ejecutar
            BandejaTareas.Ejecutar(driver);

            //Pantalla Simulacion - Venta de Producto
            //Tildar check CaLIFICACION
            //Esperar
            // Elegir calificacion // value IN
            SimulacionProductos.CheckCalificacion(driver, "IN");

            //Confirmo // Si
            Confirmar.Si(driver);
            //Espero
            //Tomo
            BandejaTareas.Tomar(driver);

            //Pantalla Identificacion Cliente Validacion (Filtro)
            //Marco No posee
            // No posee
            IdentificacionClienteValidacion.CheckGrupo(driver);
            IdentificacionClienteValidacion.CheckSociedad(driver);
            // Confirmar // Si
            Confirmar.Si(driver);


            //Bandeja otra vez
            //Siguiente // Si
            //Tomar
            BandejaTareas.Siguiente(driver);
            BandejaTareas.Tomar(driver);
            //

            //Pantalla Asistencia Crediticia - IN
            // Seleccionar Modulo // value 303 soo firma
            // Seleccionar Tipo Operacion // value 20 comercio
            AsistenciaCrediticia.SeleccionarModulo(driver, "303");
            AsistenciaCrediticia.SeleccionarTipoOP(driver, "20");
            //Confirmar // SI
            Confirmar.Si(driver);

            //Bandeja otr vez
            //Siguiente // Si
            //Tomar
            BandejaTareas.Siguiente(driver);
            BandejaTareas.Tomar(driver);

            //Pantalla Documentacion
            //Seleccionar fila documentcion  (1 sola para IN)
            //Botn Agregar
            Documentacion.SeleccionarFila(driver);
            //Documentacion.Agregar(driver);

            //Pantalla agregar documento
            //fecha vigencia -> 01012020
            //examinar archivo
            //confirmar
            AgregarDocumento.FechaVigencia(driver);
            AgregarDocumento.ElegirArchivo(driver);
            AgregarDocumento.Confirmar(driver);


            //vuelta pantalla Docuentacion
            //Confirmar
            Documentacion.Confirmar(driver);

            //Bandeja otra vez
            //Siguiente // Si

            // ---> Fin tramite parte Operador



        }

    }
}
