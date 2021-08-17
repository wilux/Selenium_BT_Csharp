using BT_Selenium.Actions;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;
using System;


namespace BT_Selenium.Task
{
    /*
     * Clase que lista todas las tareas para simular un prestamo persona 
     */
    public class DescartarTarea
    {
        public static void Descartar(IWebDriver driver)
        {

            WaitHandler.ElementIsPresent(driver, BandejaTareasUI.BTNOPDESCARTAR);
            Click.On(driver, BandejaTareasUI.BTNOPDESCARTAR);

            WaitHandler.ElementIsPresent(driver, BandejaTareasUI.BTNCONFIRMATION);
            Click.On(driver, BandejaTareasUI.BTNCONFIRMATION);

        }

            public static void DescartarTareas(IWebDriver driver)
        {

            //Ingreso al menu hasta -> BandejaTareas
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);

            string asunto  = Get.Text(driver, BandejaTareasUI.PrimerAsunto);

            while(asunto != "Venta de Productos" || asunto != "")
            {
                WaitHandler.ElementIsPresent(driver, BandejaTareasUI.PrimerTarea);

                if (asunto != "Venta de Productos")
                {
                    Click.On(driver, BandejaTareasUI.PrimerTarea);
                }
                else
                {
                    Click.On(driver, BandejaTareasUI.PrimerTarea);
                    Click.On(driver, BandejaTareasUI.BTNOPOEJECUTAR);

                    Select.ByText(driver, EntrevistaUI.SelectTipo, "C.U.I.L.");

                    //Ingreso CUIL/CUIT del Cliente a entrevistar
                    Enter.Text(driver, EntrevistaUI.InputDocumento, "20322717564");
                    Click.On(driver, EntrevistaUI.BTNOPVALIDAR);
                    
                    WaitHandler.ElementIsPresent(driver, BandejaTareasUI.BTNOPDESCARTAR);
                    Click.On(driver, BandejaTareasUI.BTNOPDESCARTAR);

                    WaitHandler.ElementIsPresent(driver, BandejaTareasUI.BTNCONFIRMATION);
                    Click.On(driver, BandejaTareasUI.BTNCONFIRMATION);

                }

                Click.On(driver, BandejaTareasUI.BTNOPOEJECUTAR);
                WaitHandler.ElementIsPresent(driver, BandejaTareasUI.BTNOPDESCARTAR);
                Click.On(driver, BandejaTareasUI.BTNOPDESCARTAR);


                WaitHandler.ElementIsPresent(driver, BandejaTareasUI.BTNCONFIRMATION);
                Click.On(driver, BandejaTareasUI.BTNCONFIRMATION);

           
                //Descartar hasta que no haya mas
            } 






        }
   }
       
}
