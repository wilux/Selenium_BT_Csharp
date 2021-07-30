using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT_Selenium.Handler
{
    public class Frame
    {

        //----------------------------------------
        // Información de IFRAMES Bantotal
        //
        //----------------------------------------
        public  void FrameActual(IWebDriver driver)
        {

            String frameActual = Get_visible_iframe(driver);
            driver.SwitchTo().Frame(frameActual);
        }

        public String  Get_visible_iframe(IWebDriver driver)
        {
            //print("-- Lista de IFRAMES --")
            driver.SwitchTo().DefaultContent();
            var iframe1 = driver.FindElement(By.Id("0"));
            driver.SwitchTo().Frame(iframe1);
            IList<IWebElement> iframes = driver.FindElements(By.TagName("iframe"));
            string iframe_visible_name = "";
            var names = new List<object>();
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
                    iframe_visible_name = (string)name;
                    return iframe_visible_name;

                }

            }
            return "No hay frames";
        }
    }
}
        ////----------------------------------------
        //// Funciones para esperar la carga de IFRAMES
        ////
        ////----------------------------------------
        //public static object esperar_iframe_and_element_id(object driver, object meta_content, object element_id, object tiempo_espera)
        //{
        //    //# Por Ejemplo
        //    //#    meta_content = "VENTA PRODUCTOS - ENTREVISTA / IDENTIFICACION"
        //    //#    tiempo_espera = 3
        //    //#    element_id = "span__BNQFPA2NRO"
        //    Console.WriteLine("__");
        //    Console.WriteLine("Tiempo de Espera: " + tiempo_espera.ToString());
        //    var iframe_visible_temp = "";
        //    var iframe_visible_temp2 = "";
        //    while (true)
        //    {
        //        var iframe_name = get_visible_iframe(driver);
        //        if (iframe_visible_temp != iframe_name)
        //        {
        //            iframe_visible_temp = iframe_name;
        //            Console.WriteLine("Visible Frame: " + iframe_name);
        //            Console.WriteLine("Esperando " + meta_content + "... +" + element_id);
        //        }
        //        driver.switch_to.default_content();
        //        var iframe1 = driver.find_element_by_id("0");
        //        driver.switch_to.frame(iframe1);
        //        var iframe2 = driver.find_element_by_xpath("//iframe[@name='" + iframe_name + "']");
        //        driver.switch_to.frame(iframe2);
        //        if (driver.find_elements_by_css_selector("meta[content='" + meta_content + "']"))
        //        {
        //            if (iframe_visible_temp2 != meta_content)
        //            {
        //                iframe_visible_temp2 = meta_content;
        //                Console.WriteLine("Encontrado: " + meta_content + "...");
        //            }
        //            if (driver.find_elements_by_id(element_id))
        //            {
        //                Console.WriteLine(iframe_name + " - " + element_id);
        //                break;
        //            }
        //        }
        //        Console.WriteLine(".", end: " ");
        //        time.sleep(tiempo_espera);
        //        //esperar(tiempo_espera)
        //    }
        //    Console.WriteLine("");
        //    esperar(2);
        //}

//public static object esperar_iframe_and_element_name(object driver, object meta_content, object element_name, object tiempo_espera)
//{
//    //# Por Ejemplo
//    //#    meta_content = "VENTA PRODUCTOS - ENTREVISTA / IDENTIFICACION"
//    //#    tiempo_espera = 3
//    //#    element_id = "span__BNQFPA2NRO"
//    var iframe_visible_temp = "";
//    while (true)
//    {
//        var iframe_name = get_visible_iframe(driver);
//        if (iframe_visible_temp != iframe_name)
//        {
//            iframe_visible_temp = iframe_name;
//            Console.WriteLine("Esperando " + meta_content + "... +" + element_name);
//            Console.WriteLine("tiempo_espera: " + tiempo_espera.ToString());
//        }
//        //print("Visible Frame: "+ iframe_name)
//        driver.switch_to.default_content();
//        var iframe1 = driver.find_element_by_id("0");
//        driver.switch_to.frame(iframe1);
//        var iframe2 = driver.find_element_by_xpath("//iframe[@name='" + iframe_name + "']");
//        driver.switch_to.frame(iframe2);
//        if (driver.find_elements_by_css_selector("meta[content='" + meta_content + "']"))
//        {
//            //print("Visible iframe: "+meta_content+"...")
//            if (driver.find_elements_by_name(element_name))
//            {
//                Console.WriteLine(iframe_name + " - " + element_name);
//                break;
//            }
//        }
//        //print("Esperando "+meta_content+"... +" + element_name)
//        Console.WriteLine(".", end: "");
//        time.sleep(tiempo_espera);
//    }
//    Console.WriteLine("");
//    esperar(2);
//}

//public static object print_separador(object texto)
//{
//    Console.WriteLine("");
//    Console.WriteLine("***********************************************");
//    Console.WriteLine("** " + texto);
//    Console.WriteLine("***********************************************");
//    Console.WriteLine("");
//}



