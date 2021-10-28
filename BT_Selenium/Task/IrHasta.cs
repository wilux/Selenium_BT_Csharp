using BT_Selenium.Actions;
using BT_Selenium.Tasks;
using BT_Selenium.UI;
using OpenQA.Selenium;


namespace BT_Selenium.Task
{
   public class IrHasta
    {
        public static void SimularProducto(IWebDriver driver, string documento, string ingresos)
        {
            //Iniciar hasta CUIL/CUIT
            Entrevista.Iniciar(driver);
            Entrevista.IngresarDocumento(driver, documento);

            ////Pantalla Entrevista
            ///Completar Datos que falten
            Entrevista.DatosPersonales(driver);
            Entrevista.Ocupacion(driver);
            Entrevista.DatosContacto(driver);
            ////Seleccionar Cuenta
            Entrevista.BuscarCuenta(driver);
            ////Ingresos
            Entrevista.Ingresos(driver, ingresos);
            ////Confirmar Entrevista
            Entrevista.Confirmar(driver);
            string nroEntrevista = Entrevista.NroEntrevista(driver);
            //Cerrar
            Entrevista.Cerrar(driver);

            //Retomar
            BandejaTareas.Filtrar(driver, nroEntrevista);
            BandejaTareas.Siguiente(driver);
            BandejaTareas.Ejecutar(driver);
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

        public static void BandejaDeTareas(IWebDriver driver)
        {
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);
        }

    }
}
