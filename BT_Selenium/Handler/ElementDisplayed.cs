using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.Handler { 
    public class ElementDisplayed {

    public bool elementDisplayed(IWebDriver driver, By locator)
    {
        new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(condition: ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        return driver.FindElement(locator).Displayed;
    }
}
}

