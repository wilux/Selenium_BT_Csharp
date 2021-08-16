using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BT_Selenium.Tools;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class GDEM610 : BaseTest
    {
        [TestCase("20303879618", "C/ 20/1, S/paquete, S/deuda.")]
        //[TestCase("20108200090", "C/ 20/1, C/ 20/5,  C/paquete S/deuda.")]
        //[TestCase("23161636479", "C/ 20/1, Conjunta, S/paquete S/Acuerdo.")]
        //[TestCase("27363826550", "C/ 20/5, S/20/1 C/paquete Empleado C/Acuerdo.")]
        //[TestCase("27174708121", "C/ 20/5, S/20/1 C/paquete C/DEUDA, C/Acuerdo")]
        //[TestCase("23255760114", "C/ 20/1, S/20/5 S/paquete C/DEUDA S/Acuerdo")]
        
        public void RF04(string documento, string comentario)
        {
            Frame frame = new Frame();
            EntrevistaUI entrevista = new EntrevistaUI();
            BandejaTareasUI bandejaTareas = new BandejaTareasUI();
            SimulacionProductosUI simulacionProductos = new SimulacionProductosUI();

            //entrevista.irBandejaTareas(driver);//despues Borrar solo prueba
            //Iniciar hasta CUIL/CUIT

           
            entrevista.Iniciar(driver);

            ////Seleccionamos tipo CUIT/CUIL e ingresamos documento
            entrevista.IngresarDocumento(driver, documento);


            ////Pantalla Entrevista

            ////Completamos Datos Contacto
            entrevista.Completar_DatosContacto(driver);

            ////Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
            entrevista.SeleccionarCuentaCredito(driver);



            ////Ingresos y Sector Empleador
            entrevista.IngresosPF(driver);


            ////Confirmar Entrevista
            Click.On(driver, EntrevistaUI.BTNOPCONFIRMAR);

            ////Cerrar para continuar siguiente pantalla
            entrevista.Cerrar(driver);

            ////Volvemos a hxwf900 - Bandeja de Entrada de Tareas
            bandejaTareas.Siguiente(driver);

            ////Confirmar SI
            bandejaTareas.Si(driver);

            //Seleccionar
            //Ejecutar
            bandejaTareas.Ejecutar(driver);

            //Simular

            //Elijo paquete (Trae por defecto el mas alto disponible)
            //Aqui deberia poner logica para elegir uno distinto


            //WebPanel hBNQFPB3 - Simulación - Venta de Productos
            //Elegimos iframe
            frame.BuscarFrame(driver, simulacionProductos.SelectPaquete);

            // select the drop down list
            var element = driver.FindElement(simulacionProductos.SelectPaquete);
            //create select element object 
            var selectElement = new SelectElement(element);
            var index = 0;
            int cantidad = 30;
            //string paquete = "";
            List<string> paquetes = new List<string>();

            //driver.FindElement(simulacionProductos.SelectPaquete).Click();

            foreach (var option in selectElement.Options)
            {
                if (index == 0)
                {
                    cantidad = selectElement.Options.Count;

                }

                index++;
                if (index == cantidad)
                {
                    break;
                }

                paquetes.Add( option.Text);

            }

            for (int i = 0; i < paquetes.Count; i++)
            {
                
                frame.BuscarFrame(driver, simulacionProductos.SelectPaquete);
                simulacionProductos.SeleccionarByIndex(driver, simulacionProductos.SelectPaquete, i);
                driver.FindElement(simulacionProductos.SelectPaquete).SendKeys(Keys.ArrowDown);
                WaitActions.Wait(driver, 6000);
                Reporte.Logger(documento + " - " + comentario + " - " + paquetes[i]);
                Capturar.Pantalla(driver, paquetes[i], documento);
            }


        }

    }
}
