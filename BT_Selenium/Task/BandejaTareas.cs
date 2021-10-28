using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;


namespace BT_Selenium.Task
{
    public class BandejaTareas
    {

        public static void BuscarInstancia(IWebDriver driver, string instancia)
        {
            for (int i = 1; i <= 10; i++)
            {
                string SpanInstancia;
                if (i < 10)
                {
                    SpanInstancia = "span__IDINSTANCIA_00" + "0" + i.ToString();
                }
                else
                {
                    SpanInstancia = "span__IDINSTANCIA_00" + i.ToString();
                }

                By locator = By.Id(SpanInstancia);


                if (Get.SpanText(driver, locator) == instancia)
                {
                    Grid.SeleccionarFila(driver, BandejaTareasUI.Grilla_Tareas, locator);
                    Click.On(driver, locator);

                }
                else { continue; }

            }


        }

        public static void BuscarTarea(IWebDriver driver, string tarea)
        {
            for (int i = 1; i <= 10; i++)
            {
                string SpanInstancia;
                if (i < 10)
                {
                    SpanInstancia = "span__TAREA_00" + "0" + i.ToString();
                }
                else
                {
                    SpanInstancia = "span__TAREA_00" + i.ToString();
                }


                By locator = By.Id(SpanInstancia);


                if (Get.SpanText(driver, locator) == tarea)
                {
                    Grid.SeleccionarFila(driver, BandejaTareasUI.Grilla_Tareas, locator);
                    Click.On(driver, locator);

                }
                else { continue; }

            }


        }



        public static void Iniciar(IWebDriver driver)
        {
            Click.On(driver, BandejaTareasUI.BTNOPOINICIAR);
        }

        public static void Seleccionar(IWebDriver driver)
        {
            Grid.SeleccionarFila(driver, BandejaTareasUI.Grilla_Tareas, BandejaTareasUI.PrimerTarea);
            Click.On(driver, BandejaTareasUI.PrimerTarea);
        }


        public static void Filtrar(IWebDriver driver, string nroEntrevista)
        {
            Click.On(driver, BandejaTareasUI.InputBuscarAsunto);
            Enter.Text(driver, BandejaTareasUI.InputBuscarAsunto, nroEntrevista);
            PressKey.Return(driver, BandejaTareasUI.InputBuscarAsunto);
            WaitHandler.Wait(2);
        }

        public static void Siguiente(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitHandler.Wait(2);
            Click.On(driver, BandejaTareasUI.BTNOPOSIGUIENTE);
            Si(driver);
        }

        public static void Si(IWebDriver driver)
        {
            Click.On(driver, BandejaTareasUI.BTNCONFIRMATION);
        }

        public static void Ejecutar(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitHandler.Wait(2); 
            Click.On(driver, BandejaTareasUI.BTNOPOEJECUTAR);
        }

        public static void Tomar(IWebDriver driver)
        {
            Seleccionar(driver);
            WaitHandler.Wait(2);
            Click.On(driver, BandejaTareasUI.BTNOPOTOMAR);

            if (BandejaTareas.GetMensaje(driver) != "")
            {
                Click.On(driver, BandejaTareasUI.BTNOPOEJECUTAR);
            }
            WaitHandler.Wait(2);
        }

        public static string GetMensaje(IWebDriver driver)
        {
            try
            {
                Frame.BuscarFrame(driver, SimulacionProductosUI.MsgTextArriba);
                return Get.SpanText(driver, SimulacionProductosUI.MsgTextArriba);
            }
            catch
            {
                return "";
            }
        }


        ///BTWeb/.\images\icono_mail_inprocess.gif  -> Siguiente o Ejecutar(Probar ambos, Primero intentar siguiente siempre)
        ///BTWeb/.\images\icono_mail_assigned.gif --> Solo Ejecutar
        ///BTWeb/.\images\icono_mail_ready.gif --> Tomar
        public static void Avanzar(IWebDriver driver)
        {
            By img = By.Id("_ZG1_IMGESTADOIMAGE_0001");

            Seleccionar(driver);
            //
            if (Get.ImgSrc(driver, img) == "http://btwebqa.ar.bpn/BTWeb/images/icono_mail_inprocess.gif") 
                {
                Siguiente(driver);
                //WaitHandler.Wait(driver, 2);
                Si(driver);
                //Salto mensaje y no se puede Siguiente entonces Ejecutar
                if (GetMensaje(driver) != "")
                {
                    Ejecutar(driver);
                    //WaitHandler.Wait(driver, 2);
                    Si(driver);
                }
                else
                {
                    Ejecutar(driver);
                    //WaitHandler.Wait(driver, 2);
                    Si(driver);
                }

            }else if (Get.ImgSrc(driver, img) == "http://btwebqa.ar.bpn/BTWeb/images/icono_mail_assigned.gif")
            {
                Ejecutar(driver);
                //WaitHandler.Wait(driver, 2);
                Si(driver);
            }
            else
            {
                Tomar(driver);
                //WaitHandler.Wait(driver, 2);
                Si(driver);
            }
        }

    }
}
