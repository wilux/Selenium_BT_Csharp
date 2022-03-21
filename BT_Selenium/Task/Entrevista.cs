using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace BT_Selenium.Task
{
    public class Entrevista
    {


        //Incia una entrevitsa, completa los datos basicos.
        //public static void Completar(IWebDriver driver)
        //{
        //    //Iniciar(driver);
        //    //IngresarDocumento(driver, documento);
        //    DatosPersonales(driver);
        //    DatosContacto(driver);
        //    DatosEmpresa(driver);
        //    Ingresos(driver);
        //    Confirmar(driver);
        //    Cerrar(driver);
        //}


        public static void Completar(IWebDriver driver, string documento, string sector="PUB", string ingresoDependiente="200000", string ingresoIndependiente="200000")
        {

            ////Iniciar hasta CUIL/CUIT
            //Entrevista.Iniciar(driver);
            Entrevista.IngresarDocumento(driver, documento);


            //Para pruebas - Retoma tramite
            ////Pantalla Entrevista
            //IrHasta.BandejaDeTareas(driver);
            //BandejaTareas.Filtrar(driver, documento);
            ////BandejaTareas.Ejecutar(driver);

            ////Completar
            //Cronometro.start();
            //Entrevista.DatosPersonales2(driver);
            //Cronometro.stop("Datos Personales");

            Entrevista.Ocupacion(driver);
            Entrevista.DatosContacto(driver);

            //Seleccionar Cuenta
            Entrevista.BuscarCuenta(driver);

            //Ingresos
            Entrevista.Ingresos(driver, sector, ingresoDependiente, ingresoIndependiente);


            ////Confirmar Entrevista
            Entrevista.Confirmar(driver);
            Entrevista.Cerrar(driver);

        }

        public static void Confirmar(IWebDriver driver)
        {
            //Thread.Sleep(3000);
            Click.On(driver, EntrevistaUI.BTNOPCONFIRMAR);
            //Thread.Sleep(3000);
        }

        public static void Cerrar(IWebDriver driver)
        {
            Click.On(driver, EntrevistaUI.BTNOPCERRAR);
            //Thread.Sleep(3000);
        }

        public static string NroEntrevista(IWebDriver driver)
        {
            return Get.InputValue(driver, EntrevistaUI.inputTramite);
        }



        public static void IraBandejaTareas(IWebDriver driver)
        {
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);
        }

        public static void Iniciar(IWebDriver driver)
        {
            // WaitHandler.Wait(7000);
            // driver.SwitchTo().Window(driver.WindowHandles[1]);
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


        public static void BuscarCuenta(IWebDriver driver)
        {
  
                //Elijo la primer fila por defecto
                Grid.SeleccionarFila(driver, EntrevistaUI.GridCtaCredito, EntrevistaUI.PrimerFila);
                WaitHandler.Wait(1);
                //driver.FindElement(EntrevistaUI.BTNOPELEGIRCTA).Click();
                Click.On(driver, EntrevistaUI.BTNOPELEGIRCTA);


            //if (WaitHandler.IsVisible(driver, EntrevistaUI.BTNOPELEGIRCTA))
            //{

            //    for (int i = 1; i <= 5; i++)
            //    {

            //        try
            //        {
            //            string SpanInstancia;

            //            if (i < 10)
            //            {
            //                SpanInstancia = "span__ACREDITAENBPN_00" + "0" + i.ToString();
            //            }
            //            else
            //            {
            //                SpanInstancia = "span__ACREDITAENBPN_00" + i.ToString();
            //            }

            //            By locator = By.Id(SpanInstancia);


            //            if (Get.SpanText(driver, locator) == "SI")
            //            {
            //                Grid.SeleccionarFila(driver, EntrevistaUI.GridCtaCredito, locator);
            //                Click.On(driver, EntrevistaUI.BTNOPELEGIRCTA);
            //                Thread.Sleep(5000);
            //                break;

            //            }
            //        }
            //        catch
            //        {
            //            continue;
            //        }

            //    }
            //    //Si alterminar for el bt elegir cta sigue activo 
            //    if (WaitHandler.IsVisible(driver, EntrevistaUI.BTNOPELEGIRCTA))
            //    {
            //        //Elijo la primer fila por defecto
            //        Grid.SeleccionarFila(driver, EntrevistaUI.GridCtaCredito, EntrevistaUI.CampoAcreditaBPN);
            //        Click.On(driver, EntrevistaUI.BTNOPELEGIRCTA);
            //        Thread.Sleep(5000);
            //    }

            //}
            //else if (!WaitHandler.IsVisible(driver, EntrevistaUI.BTNOPCAMBIARCTA))
            //{   //Ya esta seleccionada la cuenta
            //   Select.ByValue(driver, EntrevistaUI.SelectCuentaBT, "1");
            //}


        }

        public static void Ingresos(IWebDriver driver, string sector = "PUB",
            string ingresosDependencia = "500000", string ingresosIndependiente = "500000")
        {

            try
            {

                if (Get.SelectValue(driver, EntrevistaUI.SelectSectorEmpleador) == "")
                {
                    Select.ByValue(driver, EntrevistaUI.SelectSectorEmpleador, sector);
                    PressKey.Tab(driver, EntrevistaUI.SelectSectorEmpleador);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }


            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputIngresosDepedencia) != null)
                {

                    PressKey.Delete(driver, EntrevistaUI.InputIngresosDepedencia);
                    // Thread.Sleep(200);
                    Enter.Text(driver, EntrevistaUI.InputIngresosDepedencia, ingresosDependencia);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }


            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputIngresosIndependiente) !=  null )
                {
                    int i = 0;
                    while (i < 3) {
                        i++;
                        PressKey.Backspace(driver, EntrevistaUI.InputIngresosIndependiente);
                    }
                    // Thread.Sleep(200);
                    //Enter.Text(driver, EntrevistaUI.InputIngresosIndependiente, ingresosIndependiente);
                    driver.FindElement(EntrevistaUI.InputIngresosIndependiente).SendKeys(ingresosIndependiente);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }


        }


        public static void DatosPersonales(IWebDriver driver, string nombre = "John", string apellido = "Doe",
            string fecha = "01/01/1981", string capacidadLegal = "1", string sexo = "M", string nacionalidad = "80",
            string provincia = "15", string localidad = "326", string ciudadania = "80")
        {
            try
            {

                if (Get.InputValue(driver, EntrevistaUI.inputNombre) == "")
                {
                    Enter.Text(driver, EntrevistaUI.inputNombre, nombre);
                }

            }
            catch (Exception e) { Console.WriteLine(e); }


            try
            {
                if (Get.InputValue(driver, EntrevistaUI.inputApellido) == "")
                {
                    Enter.Text(driver, EntrevistaUI.inputApellido, apellido);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.inputFechaNac).Contains("/"))
                {
                    Enter.JSTextById(driver, "_BNQFPA2FNA", fecha);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }


            try
            {
                if (Get.InputValue(driver, EntrevistaUI.inputFechaIngresoPais).Contains("/"))
                {
                    Enter.JSTextById(driver, "_SNGC11DAT2", fecha);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.SelectValue(driver, EntrevistaUI.SelectCapacidadLegal) == "")
                {
                    Select.ByValue(driver, EntrevistaUI.SelectCapacidadLegal, capacidadLegal);// 1 Mayor edad
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.SelectValue(driver, EntrevistaUI.SelectSexo) == "")
                {
                    Select.ByValue(driver, EntrevistaUI.SelectSexo, sexo);//M Masculino
                }
            }
            catch (Exception e) { Console.WriteLine(e); }


            try
            {
                //EstadoCivil
                // Requiere tiempo despues
                if (Get.SelectValue(driver, EntrevistaUI.SelectEstadoCivil) == "")
                {
                    Select.ByValue(driver, EntrevistaUI.SelectEstadoCivil, "4");
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                //PaisNacimiento
                // Requiere tiempo despues
                if (Get.SelectValue(driver, EntrevistaUI.SelectNacionalidad) != "80")
                {
                    //Thread.Sleep(200);
                    Select.ByValue(driver, EntrevistaUI.SelectNacionalidad, nacionalidad);//80 argentina
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                //Provincia
                // Requiere tiempo despues
                if (Get.SelectValue(driver, EntrevistaUI.SelectProvincia)!="15")
                {
                    //Thread.Sleep(200);
                    Select.ByValue(driver, EntrevistaUI.SelectProvincia, provincia);//15 Neuquen
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.inputLocalidad) == "0")
                {
                    Clear.On(driver, EntrevistaUI.inputLocalidad);//326 Neuquen.
                   // Thread.Sleep(200);
                    Enter.Text(driver, EntrevistaUI.inputLocalidad, localidad);//326 Neuquen
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                //PaisCiudadania
                // Requiere tiempo despues
                if (Get.SelectValue(driver, EntrevistaUI.SelectPaisCiudadania) != "80")
                {
                    //Thread.Sleep(200);
                    Select.ByValue(driver, EntrevistaUI.SelectPaisCiudadania, ciudadania);//80 argentina
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

        }





        public static void DatosPersonales2(IWebDriver driver, string nombre = "John", string apellido = "Doe",
            string fecha = "01/01/1981", string capacidadLegal = "1", string sexo = "M", string nacionalidad = "80",
            string provincia = "15", string localidad = "326", string ciudadania = "80")
        {


            if (Frame.BuscarFrame(driver, EntrevistaUI.inputNombre))
            {
                try
                {

                    if (Get.InputValue2(driver, EntrevistaUI.inputNombre) == "")
                    {
                        Enter.Text2(driver, EntrevistaUI.inputNombre, nombre);
                    }

                }
                catch (Exception e) { Console.WriteLine(e); }


                try
                {
                    if (Get.InputValue2(driver, EntrevistaUI.inputApellido) == "")
                    {
                        Enter.Text2(driver, EntrevistaUI.inputApellido, apellido);
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }

                try
                {
                    if (Get.InputValue2(driver, EntrevistaUI.inputFechaNac).Contains("/"))
                    {
                        Enter.JSTextById(driver, "_BNQFPA2FNA", fecha);
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }


                try
                {
                    if (Get.InputValue2(driver, EntrevistaUI.inputFechaIngresoPais).Contains("/"))
                    {
                        Enter.JSTextById(driver, "_SNGC11DAT2", fecha);
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }

                try
                {
                    if (Get.SelectValue2(driver, EntrevistaUI.SelectCapacidadLegal) == "")
                    {
                        Select.ByValue2(driver, EntrevistaUI.SelectCapacidadLegal, capacidadLegal);// 1 Mayor edad
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }

                try
                {
                    if (Get.SelectValue2(driver, EntrevistaUI.SelectSexo) == "")
                    {
                        Select.ByValue2(driver, EntrevistaUI.SelectSexo, sexo);//M Masculino
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }


                try
                {
                    //EstadoCivil
                    // Requiere tiempo despues
                    if (Get.SelectValue2(driver, EntrevistaUI.SelectEstadoCivil) == "")
                    {
                        Select.ByValue2(driver, EntrevistaUI.SelectEstadoCivil, "4");
                        Thread.Sleep(5000);
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }

                try
                {
                    //PaisNacimiento
                    // Requiere tiempo despues
                    if (Get.SelectValue2(driver, EntrevistaUI.SelectNacionalidad) != "80")
                    {
                        //Thread.Sleep(200);
                        Select.ByValue2(driver, EntrevistaUI.SelectNacionalidad, nacionalidad);//80 argentina
                        Thread.Sleep(5000);
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }

                try
                {
                    //Provincia
                    // Requiere tiempo despues
                    if (Get.SelectValue2(driver, EntrevistaUI.SelectProvincia) != "15")
                    {
                        //Thread.Sleep(200);
                        Select.ByValue2(driver, EntrevistaUI.SelectProvincia, provincia);//15 Neuquen
                        Thread.Sleep(5000);
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }

                try
                {
                    if (Get.InputValue2(driver, EntrevistaUI.inputLocalidad) == "0")
                    {
                        Clear.On2(driver, EntrevistaUI.inputLocalidad);//326 Neuquen.
                                                                      // Thread.Sleep(200);
                        Enter.Text2(driver, EntrevistaUI.inputLocalidad, localidad);//326 Neuquen
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }

                try
                {
                    //PaisCiudadania
                    // Requiere tiempo despues
                    if (Get.SelectValue2(driver, EntrevistaUI.SelectPaisCiudadania) != "80")
                    {
                        //Thread.Sleep(200);
                        Select.ByValue2(driver, EntrevistaUI.SelectPaisCiudadania, ciudadania);//80 argentina
                        Thread.Sleep(5000);
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }
            }


     
        }



        public static void Ocupacion(IWebDriver driver, string ocupacion = "1")
        {
            try
            {
                //Ocupacion
                // Requiere tiempo despues
                if (Get.SelectValue(driver, EntrevistaUI.SelectOcupacion) == "0")
                {
                    Select.ByValue(driver, EntrevistaUI.SelectOcupacion, ocupacion);//1 empleado x defecto
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputFechaNegocio) == "")
                {
                    Click.On(driver, EntrevistaUI.InputFechaNegocio);
                    Enter.JSTextById(driver, "_SNGC60FINI", "01/01/1981");
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputNombreEmpresa) == "")
                {
                    Enter.Text(driver, EntrevistaUI.InputNombreEmpresa, "Test QA S.A");

                }

            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.inputActividad) == "")
                {
                    Enter.Text(driver, EntrevistaUI.inputActividad, "11");

                }
            }
            catch (Exception e) { Console.WriteLine(e); }

        }

        public static void DatosEmpresa(IWebDriver driver)
        {
            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputRazonSocial) == "")
            {
                //Click.On(driver, EntrevistaUI.InputRazonSocial);
                Enter.Text(driver, EntrevistaUI.InputRazonSocial, "Test QA S.A");
            }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputNombreFantasial) == "")
            {
                Enter.Text(driver, EntrevistaUI.InputNombreFantasial, "Test QA S.A");

            }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.SelectNaturalezaJuridica) == "0")
            {
                Select.ByValue(driver, EntrevistaUI.SelectNaturalezaJuridica, "3");//SRL
               // WaitHandler.Wait(2);
            }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputNroRegistro) == "")
            {
                //Click.On(driver, EntrevistaUI.InputNroRegistro);
                Enter.Text(driver, EntrevistaUI.InputNroRegistro, "111");
               // WaitHandler.Wait(2);
            }
            }
            catch (Exception e) { Console.WriteLine(e); }

        }

        public static void Domicilio(IWebDriver driver)
        {
            //Ver de agregar tiempos entre cada operacion
            Select.ByValue(driver, DetalleDireccionUI.SelectCalle, "1");
            Enter.Text(driver, DetalleDireccionUI.InputCalle, "Calle Falsa");
            Enter.Text(driver, DetalleDireccionUI.InputNumero, "123");
            Select.ByValue(driver, DetalleDireccionUI.SelectPais, "80");
            Select.ByValue(driver, DetalleDireccionUI.SelectLocalidad, "326");
            Enter.Text(driver, DetalleDireccionUI.InputCodigoPostal, "Q8300NQN");
            Click.On(driver, DetalleDireccionUI.BTNOPBTNCONFIRMAR);
           // WaitHandler.Wait(2);
        }

        public static void DatosContacto(IWebDriver driver, string telefono = "Celular",
            string cArea = "299", string numero = "4721234")
        {
            //Verificamos si tiene domicilio

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputDomicilio) == "") // No tiene nada
            {
                //No esta completo el bot que genera nuevo domicilio.
                Click.On(driver, EntrevistaUI.BTNOPDOMICILIOREAL);//abre pantalla para completar domuicilio
                DetalleDireccion.Completar(driver);
              //  Thread.Sleep(5000);

            }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                //Fila 1
                if (Get.SelectValue(driver, EntrevistaUI.SelectTelefono) == "0"){
                    Select.ByText(driver, EntrevistaUI.SelectTelefono, telefono);
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.SelectValue(driver, EntrevistaUI.SelectCodigoArea) == "0")
                {
                    Select.ByText(driver, EntrevistaUI.SelectCodigoArea, cArea);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                if (Get.InputValue(driver, EntrevistaUI.InputTelefono) == "")
                {
                    Enter.Text(driver, EntrevistaUI.InputTelefono, numero);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            //Fila 2


            try
            {
                Select.ByIndex(driver, EntrevistaUI.SelectTelefono2, 0);
                Thread.Sleep(5000);
                Select.ByIndex(driver, EntrevistaUI.SelectCodigoArea2, 0);
                Clear.On(driver, EntrevistaUI.InputTelefono2);
            }
            catch (Exception e) { Console.WriteLine(e); }

            try
            {
                //Mail, (si no tiene ponemos uno falso para hacer mas rapido)
                if (Get.InputValue(driver, EntrevistaUI.InputMail) == "" || Get.InputValue(driver, EntrevistaUI.InputMail) == null)
            {
                Enter.Text(driver, EntrevistaUI.InputMail, "notiene@notiene.com");
                //Thread.Sleep(200);
                //Click.On(driver, EntrevistaUI.NoMail);
                //Thread.Sleep(5000);

            }
            }
            catch (Exception e) { Console.WriteLine(e); }
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
