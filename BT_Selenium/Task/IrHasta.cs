using BT_Selenium.Actions;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.Task
{
   public class IrHasta
    {
        public static void SimularProducto(IWebDriver driver, string documento)
        {

            Entrevista.Iniciar(driver);

            ////Seleccionamos tipo CUIT/CUIL e ingresamos documento
            Entrevista.IngresarDocumento(driver, documento);


            ////Pantalla Entrevista

            //Completar Datos empresa si es PJ
            if (documento[0] == "3"[0])
            {
                Entrevista.Completar_DatosEmpresa(driver);
            }

            //Completar Datos del Negocio


            ////Completamos Datos Contacto
            Entrevista.Completar_DatosContacto(driver);

            if (documento[0] != "3"[0])
            {
                ////Seleccionar Cuenta (Falta logica para ver cual elegir) elijo por defecto la primera
                Entrevista.SeleccionarCuentaCredito(driver);

                ////Ingresos y Sector Empleador
                Entrevista.IngresosPF(driver);
            }





            ////Confirmar Entrevista
            Click.On(driver, EntrevistaUI.BTNOPCONFIRMAR);

            ////Cerrar para continuar siguiente pantalla
            Entrevista.Cerrar(driver);

            ////Volvemos a hxwf900 - Bandeja de Entrada de Tareas
            BandejaTareas.Siguiente(driver);

            ////Confirmar SI
            BandejaTareas.Si(driver);

            //Seleccionar
            //Ejecutar
            BandejaTareas.Ejecutar(driver);

            //Simular
        }

        //Busca el ultimo tramite por cuil/cuit ingresado para continuarlo.
        public static void RetomarTramiteBandeja(IWebDriver driver, string documento)
        {

            Entrevista.IraBandejaTareas(driver);
            Click.On(driver, BandejaTareasUI.InputBuscarAsunto);
            Enter.Text(driver, BandejaTareasUI.InputBuscarAsunto, documento);
            PressKey.Return(driver, BandejaTareasUI.InputBuscarAsunto);
           // BandejaTareas.Seleccionar(driver);
            //WaitHandler.Wait(5000);
            //BandejaTareas.Ejecutar(driver);

        }
    }
}
