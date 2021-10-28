using BT_Selenium.Actions;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;
using System;

namespace BT_Selenium.Task
{
    /*
     * Clase que lista todas las tareas para simular un prestamo persona 
     */
    public class SimularPrestamoTask
    {


      public static void BI(IWebDriver driver, String documento,String monto, String plazo)
        {
            
           
            //Iniciar hasta CUIL/CUIT
            Entrevista.Iniciar(driver);

            //Seleccionamos tipo CUIT/CUIL e ingresamos documento
            Entrevista.IngresarDocumento(driver, documento);


            //Pantalla Entrevista

            //Completamos Datos Contacto
            Entrevista.DatosContacto(driver);

            //Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
            Entrevista.BuscarCuenta(driver);


            //Ingresos y Sector Empleador
            Entrevista.Ingresos(driver);

            //Confirmar Entrevista
            Entrevista.Confirmar(driver);

            //Cerrar para continuar siguiente pantalla
            Entrevista.Cerrar(driver);

            //Volvemos a hxwf900 - Bandeja de Entrada de Tareas
            BandejaTareas.Siguiente(driver);

            //Confirmar SI
            BandejaTareas.Si(driver);

            //Seleccionar
            //Ejecutar
            BandejaTareas.Ejecutar(driver);

            //Simular

            //Elijo paquete (Trae por defecto el mas alto disponible)
            //Aqui deberia poner logica para elegir uno distinto


            //WebPanel hBNQFPB3 - Simulación - Venta de Productos
            //Elegimos iframe

            //Elijo Linea _LINEA
            SimulacionProductos.LineaPrestamo(driver);

            //Pause
            WaitHandler.Wait(5);

            //Monto _BNQFPC5MTO
            SimulacionProductos.MontoPrestamo(driver, monto);

            //Cuotas _BNQFPC5PZO
            SimulacionProductos.PlazoPrestamo(driver, plazo);

            //Destino Fondos _BNQFPC5DES en step4
            SimulacionProductos.DestinoFondos(driver);

            //Boton Simular BTNOPSIMULAR en step4
            Click.On(driver, SimulacionProductosUI.BTNOPSIMULAR);

            //Variables con datos para el reporte
            string valorCuota = Get.InputValue(driver, SimulacionProductosUI.ValorCuotaAprox);
            string TNA = Get.InputValue(driver, SimulacionProductosUI.ValorTna);
            //string TEM = Get.InputValue(driver, SimulacionProductosUI.ValorTem);
            //string TEA = Get.InputValue(driver, SimulacionProductosUI.ValorTea);


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
