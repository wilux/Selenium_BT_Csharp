using BT_Selenium.Actions;
using BT_Selenium.PageObject;
using BT_Selenium.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT_Selenium.Task
{
    /*
     * Clase que lista todas las tareas para simular un prestamo persona 
     */
    public class SimularPrestamoTask
    {
        Frame frame = new Frame();

        public SimularPrestamoTask(IWebDriver Driver)
        {
            driver = Driver;
        }


      public void BI(String documento,String monto, String plazo)
        {
            EntrevistaUI entrevista = new Entrevista(driver);
            BandejaTareasUI bandejaTareas = new BandejaTareasUI();
            SimulacionProductosUI simulacionProductos = new SimulacionProductosUI();

            

            //Iniciar hasta CUIL/CUIT
            entrevista.Iniciar(driver);

            //Seleccionamos tipo CUIT/CUIL e ingresamos documento
            entrevista.IngresarDocumento(driver, documento);


            //Pantalla Entrevista

            //Completamos Datos Contacto
            entrevista.Completar_DatosContacto(driver);

            //Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
            entrevista.SeleccionarCuentaCredito(driver);



            //Ingresos y Sector Empleador
            entrevista.IngresosPF(driver);


            //Confirmar Entrevista
            driver.FindElement(entrevista.BTNOPCONFIRMAR).Click();


            //Cerrar para continuar siguiente pantalla
            entrevista.Cerrar(driver);

            //Volvemos a hxwf900 - Bandeja de Entrada de Tareas
            bandejaTareas.Siguiente(driver);

            //Confirmar SI
            bandejaTareas.Si(driver);

            //Seleccionar
            //Ejecutar
            bandejaTareas.Ejecutar(driver);

            //Simular

            //Elijo paquete (Trae por defecto el mas alto disponible)
            //Aqui deberia poner logica para elegir uno distinto


            //WebPanel hBNQFPB3 - Simulación - Venta de Productos
            //Elegimos iframe
            frame.BuscarFrame(driver, simulacionProductos.SelectLineaPrestamo);

            //Elijo Linea _LINEA
            simulacionProductos.LineaPrestamo(driver);

            //Pause
            WaitActions.Wait(driver, 5000);

            //Monto _BNQFPC5MTO
            simulacionProductos.MontoPrestamo(driver, monto);

            //Cuotas _BNQFPC5PZO
            simulacionProductos.PlazoPrestamo(driver, plazo);

            //Destino Fondos _BNQFPC5DES en step4
            simulacionProductos.DesinoFondos(driver);

            //Boton Simular BTNOPSIMULAR en step4
            driver.FindElement(simulacionProductos.BTNOPSIMULAR).Click();


            //Elegimos iframe
            frame.BuscarFrame(driver, simulacionProductos.ValorCuotaAprox);

            //Variables con datos para el reporte
            String valorCuota = driver.FindElement(simulacionProductos.ValorCuotaAprox).GetAttribute("value");
            String TNA = driver.FindElement(simulacionProductos.ValorTna).GetAttribute("value");
            String TEM = driver.FindElement(simulacionProductos.ValorTem).GetAttribute("value");
            String TEA = driver.FindElement(simulacionProductos.ValorTea).GetAttribute("value");


            //Escribo Reporte
            Reporte.Logger("Cliente CUIL: " + documento
                +
                ". Simulacion por un monto de de $"
                + monto
                + ". el valor de la cuota aprox. es de: $" + valorCuota
                + " con una TNA: %" + TNA
                + " en un plazo de "
                + plazo + " meses."
                );


        }
    }
}
