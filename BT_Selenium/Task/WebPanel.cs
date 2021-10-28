using BT_Selenium.Actions;
using BT_Selenium.Tasks;
using BT_Selenium.Tools;
using BT_Selenium.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace BT_Selenium.Task
{
    public class WebPanel
    {

        public static string Titulo(IWebDriver driver)
        {
            Click.On(driver, WebPanelGenericoUI.Titulo);
            return Get.SpanText(driver, WebPanelGenericoUI.Titulo);

        }

        public static string Mensaje(IWebDriver driver)
        {
            Click.On(driver, WebPanelGenericoUI.Titulo);
            return Get.SpanText(driver, WebPanelGenericoUI.Mensaje).Trim();

        }

        //public static void Wait(IWebDriver driver)
        //{

        //    while (true)
        //    {
        //        try
        //        {

        //            if (Frame.Buscar(driver, WebPanelGenericoUI.Wait) && driver.FindElement(WebPanelGenericoUI.Wait).Displayed)
        //            {
        //                continue;

        //            }
        //            else { break; }
        //        }
        //        catch { break; }
        //    }
        //}
    }
 }

