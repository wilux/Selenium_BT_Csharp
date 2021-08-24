using OpenQA.Selenium;
using BT_Selenium.Tools;


namespace BT_Selenium.Actions
{
    public class CheckBox
    {
        public static void Check(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            IWebElement checkBoxElement = driver.FindElement(locator);
            bool isSelected = checkBoxElement.Selected;

            if (isSelected == false)
            {
                Click.On(driver, locator);
                //WaitHandler.Wait(8000);
            }
        }

        public static void UnCheck(IWebDriver driver, By locator)
        {
            Frame.BuscarFrame(driver, locator);
            IWebElement checkBoxElement = driver.FindElement(locator);
            bool isSelected = checkBoxElement.Selected;

            if (isSelected == true)
            {
                Click.On(driver, locator);
                //WaitHandler.Wait(8000);
            }
        }

    }
}

