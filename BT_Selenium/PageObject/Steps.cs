using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject
{
    public class Steps : BasePage
    {


        //Pasamos al Frame step0
        public void PasarFrame_0(IWebDriver driver)
        {

            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("step0");

        }


        //Pasamos al Frame step1


        public void PasarFrame_1(IWebDriver driver)
        {
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("step1");

        }
        public void PasarFrame_1_0(IWebDriver driver)
        {
            IWebElement iframe = driver.FindElement(By.Id("0"));
            driver.SwitchTo().Frame(iframe);
            driver.SwitchTo().Frame("step1");

        }


        //Pasamos al Frame step2
        public void PasarFrame_2(IWebDriver driver)
        {
          
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("step2");



        }

        public void PasarFrame_2_4(IWebDriver driver)
        {

            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(4);
            driver.SwitchTo().Frame("step2");



        }


        //Pasamos al Frame step3
        public void PasarFrame_3(IWebDriver driver)
        {

            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("step3");

        }

        public void PasarFrame_3_4(IWebDriver driver)
        {

            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(4);
            driver.SwitchTo().Frame("step3");

        }

        //Pasamos al Frame step4
        public void PasarFrame_4(IWebDriver driver)
        {

            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("step4");

        }

        public void PasarFrame_4_4(IWebDriver driver)
        {

            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(4);
            driver.SwitchTo().Frame("step4");

        }


    }
}
