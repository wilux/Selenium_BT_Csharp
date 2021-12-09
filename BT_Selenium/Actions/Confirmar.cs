using BT_Selenium.Tools;
using OpenQA.Selenium;

namespace BT_Selenium.Actions
{
    public class Confirmar
    {
        public static void Si(IWebDriver driver)
        {
            Click.On(driver, By.Id("BTNOPCONFIRMAR"));
            Click.On(driver, By.Id("BTNCONFIRMATION"));
        }

        public static void No(IWebDriver driver)
        {
            Click.On(driver, By.Id("BTNOPCONFIRMAR"));
            Click.On(driver, By.Id("BTNCANCELCONFIRMATION"));
        }
    }
}
