using OpenQA.Selenium;


namespace BT_Selenium.Tools
{
    public class Frame
    {

        //Metodo que devuelve el frame actual en el que estoy
        //Es un algoritmo costoso. Hay que mejorarlo.
        public static string FrameActual(IWebDriver driver)
        {



            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string currentFrame = (string)jsExecutor.ExecuteScript("return self.name");

            return currentFrame;

        }

        public static bool BuscarFrame(IWebDriver driver, By locator)
        {


            if (BuscarA(driver, locator) == true)
            {
                return true;
            }
            else if (BuscarB(driver, locator) == true)
            {
                return true;
            }
            else if (BuscarC(driver, locator) == true)
            {
                return true;

            }
            else
            {
                return false;
            }


        }



        //Metodo que cambia al frame que contiene el elemento buscado.
        public static bool BuscarA(IWebDriver driver, By locator)
        {

            for (int i = 0; i < 6; i++)
            {
               // driver.SwitchTo().DefaultContent();

                try
                {
                    driver.SwitchTo().DefaultContent();
                    driver.SwitchTo().Frame(4);
                    driver.SwitchTo().Frame("step" + i);
                     if (WaitActions.ElementIsPresent(driver, locator))
                    {
                        string frameActual = FrameActual(driver);
                        return true;
                        
                        
                    }

                }
                catch{ continue; }
            }


            return false;

        }//Fin 



        public static bool BuscarB(IWebDriver driver, By locator)
        {


            for (int i = 0; i < 6; i++)
            {
                

                try
                {
                    driver.SwitchTo().ParentFrame();

                    driver.SwitchTo().Frame("step"+i);

                    if (WaitActions.ElementIsPresent(driver, locator))
                    {
                       // string frameActual = FrameActual(driver);
                        return true;
                       

                    }

                }
                catch { continue; }
            }

            return false;
        }//Fin 


        public static bool BuscarC(IWebDriver driver, By locator)
        {


            for (int i = 0; i < 10; i++)
            {


                try
                {
                    driver.SwitchTo().DefaultContent();
                    IWebElement iframe = driver.FindElement(By.Id("0"));
                    driver.SwitchTo().Frame(iframe);

                    //Pasamos al Frame step1

                    driver.SwitchTo().Frame("step"+i);

                    //if (driver.FindElement(locator).Displayed)
                    if (WaitActions.ElementIsPresent(driver, locator))
                    {
                        string frameActual = FrameActual(driver);
                        return true;


                    }

                }
                catch { continue; }
            }

            return false;
        }//Fin 
    }
}


