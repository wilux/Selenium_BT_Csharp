using BT_Selenium.Actions;
using OpenQA.Selenium;

namespace BT_Selenium.UI
{
    /*
     * Clase que representa el webpanel hxwf900 - Bandeja de Entrada de Tareas
     */
    public class BandejaTareasUI  
    {
        //Bandeja de Entrada
        // if (driver.FindElement(By.CssSelector("meta[content='" + meta_content + "']")).Displayed)
        //public static By meta_conte = By.CssSelector("Bandeja de Entrada");
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
        public static By InputBuscarAsunto = By.Id("_BASU");
       //<INPUT id = _ZG1_IMGESTADOIMAGE_0001 type=hidden value =.\images\icono_mail_inprocess.gif name = _ZG1_IMGESTADOIMAGE_0001 > --> sobre con sol .. para ejecutar
       //<INPUT id= _ZG1_IMGESTADOIMAGE_0001 type= hidden value=.\images\icono_mail_assigned.gif name = _ZG1_IMGESTADOIMAGE_0001 > --->sobre asignado solo ejecutar
       //<INPUT id=_ZG1_IMGESTADOIMAGE_0001 type=hidden value=.\images\icono_mail_ready.gif name=_ZG1_IMGESTADOIMAGE_0001>   --> sobre cerrado para tomar

    }
}
