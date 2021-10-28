using OpenQA.Selenium;
using BT_Selenium.Tools;
using System.Threading;

namespace BT_Selenium.Actions
{
    public class Clear
    {
        public static void On(IWebDriver driver, By locator)
        {

            if (Frame.BuscarFrame(driver, locator))
            {

                
                while (true)
                {
                    try
                    {
                        driver.FindElement(locator).Clear();
                        break;
                    }
                    catch {
                        Frame.BuscarFrame(driver, locator);
                        continue; }
                }

            }
        }

    }
}
