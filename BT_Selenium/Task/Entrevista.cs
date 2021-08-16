using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using BT_Selenium.Task;

namespace BT_Selenium.Tasks
{
    public class Entrevista
    {

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, EntrevistaUI.BTNOPCONFIRMAR);
        }

        public void Cerrar(IWebDriver driver)
        {
            Click.On(driver, EntrevistaUI.BTNOPCERRAR);
        }



        public void irBandejaTareas(IWebDriver driver)
        {
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);
        }

        public void Iniciar(IWebDriver driver)
        {


            //Menu ir a...Inicio>WF>BandejaTarea
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);

            //WebPanel  hxwf900 - Bandeja de tareas
            //Iniciamos Nueva Tarea en Bandeja de tareas

            //Iniciar instancia
            Click.On(driver, BandejaTareasUI.BTNOPOINICIAR);

            //Elegimos Instancia
            Click.On(driver, NuevaInstanciaUI.Entrevista_Identificacion);
            Click.On(driver, NuevaInstanciaUI.BTNOPOINICIAR);
        }


        public void Completar_DatosPersonales(IWebDriver driver, string nombre = "John", string apellido = "Doe", 
            string fecha = "01/01/1981", string capacidadLegal ="1", string sexo="M", string nacionalidad="80",
            string provincia="15", string localidad = "326", string ciudadania = "80" )
        {
            
            if (Get.InputValue(driver, EntrevistaUI.inputNombre) == "")
            {
                Enter.Text(driver, EntrevistaUI.inputNombre, nombre);
                Enter.Text(driver, EntrevistaUI.inputApellido, apellido);
            }
            Enter.Text(driver, EntrevistaUI.inputFechaNac, fecha);
            Select.ByValue(driver, EntrevistaUI.SelectCapacidadLegal, capacidadLegal);// 1 Mayor edad

            
            if (Get.InputValue(driver, EntrevistaUI.SelectSexo) == "")
            {
                Select.ByValue(driver, EntrevistaUI.SelectSexo, sexo);//M Masculino
            }
            Select.ByValue(driver, EntrevistaUI.SelectNacionalidad, nacionalidad);//80 argentina
            Select.ByValue(driver, EntrevistaUI.SelectProvincia, provincia);//15 Neuquen
            Enter.Text(driver, EntrevistaUI.inputLocalidad, localidad);//326 Neuquen
            Select.ByValue(driver, EntrevistaUI.SelectPaisCiudadania, ciudadania);//80 argentina
        }

        public void Completar_Ocupacion(IWebDriver driver, string ocupacion = "1")
        {
            Select.ByValue(driver, EntrevistaUI.SelectOcupacion, ocupacion);//1 empleado x defecto
        }

        public void Completar_Domicilio(IWebDriver driver)
        {
            //Ver de agregar tiempos entre cada operacion
            Select.ByValue(driver, DetalleDireccionUI.SelectCalle, "1");
            Enter.Text(driver, DetalleDireccionUI.InputCalle, "Calle Falsa");
            Enter.Text(driver, DetalleDireccionUI.InputNumero, "123");
            Select.ByValue(driver, DetalleDireccionUI.SelectPais, "80");
            Select.ByValue(driver, DetalleDireccionUI.SelectLocalidad, "326");
            Enter.Text(driver, DetalleDireccionUI.InputCodigoPostal, "Q8300NQN");
            Click.On(driver, DetalleDireccionUI.BTNOPBTNCONFIRMAR);
        }

        public void Completar_DatosContacto(IWebDriver driver, string telefono = "Celular", 
            string cArea ="299", string numero="4721234", string telefono2 = "Seleccionar",
            string cArea2 = "Seleccionar", string numero2 = "")
        {

            //Verificamos si tiene domicilio
            
            if (Get.InputValue(driver, EntrevistaUI.CampoDomicilio) == "") // No tiene nada
            {
                Click.On(driver, EntrevistaUI.BTNOPDOMICILIOREAL);//abre pantalla para completar domuicilio
            }

            //Mail, sino tiene tildamos, de lo contrario dejamos como esta.
            if (Get.InputValue(driver, EntrevistaUI.InputMail) == "")
            {
                Click.On(driver, EntrevistaUI.NoMail);
            }


            //Campos Telefonico 1
            if (Get.InputValue(driver, EntrevistaUI.SelectCodigoArea) == "")
            {
                Select.ByText(driver, EntrevistaUI.SelectTelefono, telefono);
                Select.ByText(driver, EntrevistaUI.SelectCodigoArea, cArea);
                //Escribimos un numero telefonico 1 
                Click.On(driver, EntrevistaUI.InputTelefono);
                Enter.Text(driver, EntrevistaUI.InputTelefono, numero);
                PressKey.Return(driver, EntrevistaUI.InputTelefono);
            }
            //Campos Telefonico 2
            if (Get.InputValue(driver, EntrevistaUI.SelectCodigoArea2) == "")
                Select.ByText(driver, EntrevistaUI.SelectTelefono2, telefono2);
                Select.ByText(driver, EntrevistaUI.SelectCodigoArea2, cArea2);
                //Numero telefonico 2 (Lo dejo vacio)
                Click.On(driver, EntrevistaUI.InputTelefono);
                Enter.Text(driver, EntrevistaUI.InputTelefono, numero2);
                PressKey.Return(driver, EntrevistaUI.InputTelefono);
        }

        public void IngresosPF(IWebDriver driver, string sector= "Publico", string ingresos = "10000")
        {
            //Sector Empleador
            Select.ByText(driver, EntrevistaUI.SelectSectorEmpleador, sector);

            //Importe Ingresos en Depedencia
            Click.On(driver, EntrevistaUI.InputIngresosDepedencia);
            Enter.Text(driver, EntrevistaUI.InputIngresosDepedencia, ingresos);
            PressKey.Return(driver, EntrevistaUI.InputIngresosDepedencia);
        }

        public void SeleccionarCuentaCredito(IWebDriver driver)
        {
            Grid.SeleccionarFila(driver, EntrevistaUI.GridCtaDebito, EntrevistaUI.td);
            Click.On(driver, EntrevistaUI.BTNOPELEGIRCTA);
        }

        public void IngresarDocumento(IWebDriver driver, string documento)
        {

            if (documento.Substring(0, 1) == "3")
            {
                Select.ByText(driver, EntrevistaUI.SelectTipo, "C.U.I.T.");
            }
            else
            {
                Select.ByText(driver, EntrevistaUI.SelectTipo, "C.U.I.L.");
            }

            //Ingreso CUIL/CUIT del Cliente a entrevistar
            Enter.Text(driver, EntrevistaUI.InputDocumento, documento);
            Click.On(driver, EntrevistaUI.BTNOPVALIDAR);
        }
    }
}
