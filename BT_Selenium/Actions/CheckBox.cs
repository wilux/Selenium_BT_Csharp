using OpenQA.Selenium;
using BT_Selenium.Tools;
using BT_Selenium.Task;

namespace BT_Selenium.Actions
{
    public class CheckBox
    {
        public static void Check(IWebDriver driver, By locator)
        {
            WaitHandler.ElementIsPresent(driver, locator, 20);
            IWebElement checkBoxElement = driver.FindElement(locator);
            bool isSelected = checkBoxElement.Selected;
            if (isSelected == false)
            {
                while (true)
                {
                    try
                    {
                        
                        WaitHandler.ElementIsPresent(driver, locator, 20);
                        driver.FindElement(locator).Click();
                        IWebElement checkBoxElement2 = driver.FindElement(locator);
                        bool isSelected2 = checkBoxElement2.Selected;
                        if (isSelected2 == true)
                        {
                            break;
                        }
                    }
                    catch { continue; }
                }
            }
        }

        public static void UnCheck(IWebDriver driver, By locator)
        {
            WaitHandler.ElementIsPresent(driver, locator, 20);
            IWebElement checkBoxElement = driver.FindElement(locator);
            bool isSelected = checkBoxElement.Selected;
                if (isSelected == true) {
                while (true)
                {
                    try
                    {
                        
                        WaitHandler.ElementIsPresent(driver, locator, 20);
                        driver.FindElement(locator).Click();
                        IWebElement checkBoxElement2 = driver.FindElement(locator);
                        bool isSelected2 = checkBoxElement2.Selected;
                        if (isSelected2 == false)
                        {
                            break;
                        }
                    }
                    catch { continue; }
                }
            }
        }

    }
}

