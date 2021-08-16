using BT_Selenium.Actions;
using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    /*
     * Clase que representa el webpanel hxwf900 - Bandeja de Entrada de Tareas
     */
    public class BandejaTareasUI  
    {

        public static By Grilla_Tareas = By.Id("GRIDINBOX");
        public static By PrimerTarea = By.Id("span__IDINSTANCIA_0001");
        public static By SegundaTarea = By.Id("span__IDINSTANCIA_0002");
        public static By PrimerAsunto = By.Id("span__ASUNTO_0001");
        public static By BTNOPOSIGUIENTE = By.Id("BTNOPOSIGUIENTE");
        public static By BTNCONFIRMATION = By.Id("BTNCONFIRMATION");
        public static By BTNOPOEJECUTAR = By.Id("BTNOPOEJECUTAR");
        public static By BTNOPDESCARTAR = By.Id("BTNOPDESCARTAR");
        public static By BTNOPOINICIAR = By.Id("BTNOPOINICIAR");
        public static By BTNOPOTOMAR = By.Id("BTNOPOTOMAR");

    }
}
