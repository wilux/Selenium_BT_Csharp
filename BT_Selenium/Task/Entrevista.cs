using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using BT_Selenium.Task;
using System.Linq;

namespace BT_Selenium.Tasks
{
    public class Entrevista
    {
        public  Entrevista (IWebDriver driver)
        {
            Frame.BuscarFrame(driver, EntrevistaUI.BTNOPCONFIRMAR);
        }

        public static void Confirmar(IWebDriver driver)
        {
            Click.On(driver, EntrevistaUI.BTNOPCONFIRMAR);
        }

        public static void Cerrar(IWebDriver driver)
        {
            Click.On(driver, EntrevistaUI.BTNOPCERRAR);
        }



        public static void IraBandejaTareas(IWebDriver driver)
        {
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);
        }

        public static void Iniciar(IWebDriver driver)
        {
            WaitHandler.Wait(7000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Manage().Window.Maximize();


            //Menu ir a...Inicio>WF>BandejaTarea
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);

            //WebPanel  hxwf900 - Bandeja de tareas
            //Iniciamos Nueva Tarea en Bandeja de tareas

            //Iniciar instancia
            BandejaTareas.Iniciar(driver);
            
            NuevaInstancia.Entrevista(driver);


        }


        public static void Completar_DatosPersonales(IWebDriver driver, string nombre = "John", string apellido = "Doe",
            string fecha = "01/01/1981", string capacidadLegal = "1", string sexo = "M", string nacionalidad = "80",
            string provincia = "15", string localidad = "326", string ciudadania = "80")
        {

            if (Get.InputValue(driver, EntrevistaUI.inputNombre) == "")
            {
                Enter.Text(driver, EntrevistaUI.inputNombre, nombre);
                Enter.Text(driver, EntrevistaUI.inputApellido, apellido);
            }

            if (Get.InputValue(driver, EntrevistaUI.inputFechaNac) == "") 
            { 
                Enter.Text(driver, EntrevistaUI.inputFechaNac, fecha);
            }

            if (Get.InputValue(driver, EntrevistaUI.inputFechaNac) == "")
            {
                Enter.Text(driver, EntrevistaUI.inputFechaNac, fecha);
            }


            if (WaitHandler.IsVisible(driver, EntrevistaUI.SelectCapacidadLegal))
            {
                Select.ByValue(driver, EntrevistaUI.SelectCapacidadLegal, capacidadLegal);// 1 Mayor edad
            }
            if (WaitHandler.IsVisible(driver, EntrevistaUI.SelectSexo))
            {
                Select.ByValue(driver, EntrevistaUI.SelectSexo, sexo);//M Masculino
            }
            if (WaitHandler.IsVisible(driver, EntrevistaUI.SelectNacionalidad))
            {
                Select.ByValue(driver, EntrevistaUI.SelectNacionalidad, nacionalidad);//80 argentina
            }
            if (WaitHandler.IsVisible(driver, EntrevistaUI.SelectProvincia))
            {
                Select.ByValue(driver, EntrevistaUI.SelectProvincia, provincia);//15 Neuquen
            }

            if (WaitHandler.IsVisible(driver, EntrevistaUI.inputLocalidad))
                //&& Get.InputValue(driver, EntrevistaUI.inputLocalidad) == "")
            {
                Clear.On(driver, EntrevistaUI.inputLocalidad);
                Enter.Text(driver, EntrevistaUI.inputLocalidad, localidad);//326 Neuquen
            }
            if (WaitHandler.IsVisible(driver, EntrevistaUI.SelectPaisCiudadania))
            {
                Select.ByValue(driver, EntrevistaUI.SelectPaisCiudadania, ciudadania);//80 argentina
            }

        }

        public static void Completar_Ocupacion(IWebDriver driver, string ocupacion = "1")
        {
            if (WaitHandler.IsVisible(driver, EntrevistaUI.InputFechaNegocio) 
                && Get.InputValue(driver, EntrevistaUI.InputFechaNegocio) == "")
            {
                Click.On(driver, EntrevistaUI.InputFechaNegocio);
                Enter.Text(driver, EntrevistaUI.InputFechaNegocio, "01/01/1981");
            }
            if (WaitHandler.IsVisible(driver, EntrevistaUI.InputNombreEmpresa)
                && Get.InputValue(driver, EntrevistaUI.InputNombreEmpresa) == "")
            {
                Enter.Text(driver, EntrevistaUI.InputNombreEmpresa, "Test QA S.A");

            }
            if (WaitHandler.IsVisible(driver, EntrevistaUI.SelectOcupacion))
            {
                Select.ByValue(driver, EntrevistaUI.SelectOcupacion, ocupacion);//1 empleado x defecto
            }

 
        }

        public static void Completar_DatosEmpresa(IWebDriver driver)
        {
            if (WaitHandler.IsVisible(driver, EntrevistaUI.InputRazonSocial)
                && Get.InputValue(driver, EntrevistaUI.InputRazonSocial) == "")
            {
                Click.On(driver, EntrevistaUI.InputRazonSocial);
                Enter.Text(driver, EntrevistaUI.InputRazonSocial, "Test QA S.A");
            }
            if (WaitHandler.IsVisible(driver, EntrevistaUI.InputNombreFantasial)
                && Get.InputValue(driver, EntrevistaUI.InputNombreFantasial) == "")
            {
                Enter.Text(driver, EntrevistaUI.InputNombreFantasial, "Test QA S.A");

            }
            if (WaitHandler.IsVisible(driver, EntrevistaUI.SelectNaturalezaJuridica)
                 && Get.InputValue(driver, EntrevistaUI.SelectNaturalezaJuridica) == "0")
            {
                Select.ByValue(driver, EntrevistaUI.SelectNaturalezaJuridica, "3");//SRL
            }

            if (WaitHandler.IsVisible(driver, EntrevistaUI.InputNroRegistro)
               && Get.InputValue(driver, EntrevistaUI.InputNroRegistro) == "")
            {
                Click.On(driver, EntrevistaUI.InputNroRegistro);
                Enter.Text(driver, EntrevistaUI.InputNroRegistro, "111");
            }
        }

        public static void Completar_Domicilio(IWebDriver driver)
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

        public static void Completar_DatosContacto(IWebDriver driver, string telefono = "Celular", 
            string cArea ="299", string numero="4721234", string telefono2 = "Seleccionar",
            string cArea2 = "Seleccionar", string numero2 = "")
        {

            //Verificamos si tiene domicilio
            
            if (Get.InputValue(driver, EntrevistaUI.InputDomicilio) == "") // No tiene nada
            {
                Click.On(driver, EntrevistaUI.BTNOPDOMICILIOREAL);//abre pantalla para completar domuicilio
            }

            //Mail, sino tiene tildamos, de lo contrario dejamos como esta.
            if (Get.InputValue(driver, EntrevistaUI.InputMail) == "")
            {
                Click.On(driver, EntrevistaUI.NoMail);
            }


            //Campos Telefonico 1
            if (Get.InputValue(driver, EntrevistaUI.SelectCodigoArea) == "" ||
                Get.InputValue(driver, EntrevistaUI.InputTelefono) == "")
            {
                Select.ByText(driver, EntrevistaUI.SelectTelefono, telefono);
                Select.ByText(driver, EntrevistaUI.SelectCodigoArea, cArea);
                //Escribimos un numero telefonico 1 
                Click.On(driver, EntrevistaUI.InputTelefono);
                Enter.Text(driver, EntrevistaUI.InputTelefono, numero);
                PressKey.Return(driver, EntrevistaUI.InputTelefono);
            }
            //Campos Telefonico 2
            if (Get.InputValue(driver, EntrevistaUI.SelectCodigoArea2) == "" ||
                Get.InputValue(driver, EntrevistaUI.InputTelefono2) == "")
                Select.ByText(driver, EntrevistaUI.SelectTelefono2, telefono2);
                Select.ByText(driver, EntrevistaUI.SelectCodigoArea2, cArea2);
                //Numero telefonico 2 (Lo dejo vacio)
                Click.On(driver, EntrevistaUI.InputTelefono);
                Enter.Text(driver, EntrevistaUI.InputTelefono, numero2);
                PressKey.Return(driver, EntrevistaUI.InputTelefono);
        }

        public static void IngresosPF(IWebDriver driver, string sector= "Publico", 
            string ingresosDependencia = "20000", string ingresosIndependiente ="20000")
        {
            WaitHandler.Wait(5000);

            //Sector Empleador
            Select.ByText(driver, EntrevistaUI.SelectSectorEmpleador, sector);

            //Importe Ingresos en Depedencia
            Click.On(driver, EntrevistaUI.InputIngresosDepedencia);
            Enter.Text(driver, EntrevistaUI.InputIngresosDepedencia, ingresosDependencia);
            PressKey.Tab(driver, EntrevistaUI.InputIngresosDepedencia);

            if (ingresosIndependiente != "")
            {
                //Importe Ingresos Independiente
                Click.On(driver, EntrevistaUI.InputIngresosIndependiente);
                Enter.Text(driver, EntrevistaUI.InputIngresosIndependiente, ingresosIndependiente);
                PressKey.Tab(driver, EntrevistaUI.InputIngresosIndependiente);
            }
        }

        public static void SeleccionarCuentaCredito(IWebDriver driver)
        {

            Grid.SeleccionarFila(driver, EntrevistaUI.GridCtaDebito, EntrevistaUI.td);
            //Grid.SeleccionarFila(driver, EntrevistaUI.PrimerFila);
            if (WaitHandler.ElementIsPresent(driver, EntrevistaUI.BTNOPELEGIRCTA))
            {
                Click.On(driver, EntrevistaUI.BTNOPELEGIRCTA);
            }
            else
            {   //Cuenta Nueva Select
                Select.ByValue(driver, EntrevistaUI.SelectCuentaBT, "1");
            }
        }

        public static void IngresarDocumento(IWebDriver driver, string documento)
        {          
            //Comparo si documento empieza por 3 para saber si es PJ
            if (documento[0] == "3"[0])
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
