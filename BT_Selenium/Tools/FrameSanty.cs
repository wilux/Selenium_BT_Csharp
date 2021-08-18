using OpenQA.Selenium;
using System.Collections.Generic;

namespace BT_Selenium.Tools
{
    public class FrameSanty
    {

        //Metodo que devuelve el frame actual en el que estoy
        //Es un algoritmo costoso. Hay que mejorarlo.
        public static string get_visible_iframe(IWebDriver driver)
        {
            //print("-- Lista de IFRAMES --")
            driver.SwitchTo().DefaultContent();
            var iframe1 = driver.FindElement(By.Id("0"));
            driver.SwitchTo().Frame(iframe1);

            List<IWebElement> iframes = new List<IWebElement>();
            iframes.Add(driver.FindElement(By.TagName("iframe")));

            var iframe_visible_name = "";


            IList<string> names = new List<string>();

            foreach (var iframe in iframes)
            {
                //print(iframe.get_attribute("name"))
                names.Add(iframe.GetAttribute("name"));
            }
            foreach (var name in names)
            {
                //print("")
                driver.SwitchTo().DefaultContent();
                iframe1 = driver.FindElement(By.Id("0"));
                driver.SwitchTo().Frame(iframe1);
                var iframe2 = driver.FindElement(By.XPath("//iframe[@name='" + name + "']"));
                if (iframe2.Displayed)
                {
                    //print("Visible")
                    iframe_visible_name = name;
                    return iframe_visible_name;
                }//sino?
                else
                {
                    continue;
                }

            }

            return iframe_visible_name;

        }


        //----------------------------------------
        // Funciones para esperar la carga de IFRAMES
        //
        //----------------------------------------
        public static bool esperar_iframe_and_element_id(IWebDriver driver, By element_id, int tiempo_espera = 10000)
        {
            //# Por Ejemplo
            //#    meta_content = "VENTA PRODUCTOS - ENTREVISTA / IDENTIFICACION"
            //#    tiempo_espera = 3
            //#    element_id = "span__BNQFPA2NRO"

            var iframe_visible_temp = "";
            //var iframe_visible_temp2 = "";
            while (true)
            {
                var iframe_name = get_visible_iframe(driver);

                //Borrar
                if (iframe_name == "")
                {
                    iframe_name = Frame.FrameActual(driver);
                }
                //borrar

                if (iframe_visible_temp != iframe_name)
                {
                    iframe_visible_temp = iframe_name;
     
                    // Console.WriteLine("Esperando " + meta_content + "... +" + element_id);
                }
                driver.SwitchTo().DefaultContent();
                var iframe1 = driver.FindElement(By.Id("0"));
                driver.SwitchTo().Frame(iframe1);
                //iframe_name llega sin datos ""
                var iframe2 = driver.FindElement(By.XPath("//iframe[@name='" + iframe_name + "']"));
                driver.SwitchTo().Frame(iframe2);
                //if (driver.FindElement(By.CssSelector("meta[content='" + meta_content + "']")).Displayed)
                if (driver.FindElement(element_id).Displayed)
                {
                    //if (iframe_visible_temp2 != meta_content)
                    //{
                    //    iframe_visible_temp2 = meta_content;
                    //    Console.WriteLine("Encontrado: " + meta_content + "...");
                    //}
                    break;

                }
                else
                {
                    return false;
                }


            }

            return true;
        }
    }
}


