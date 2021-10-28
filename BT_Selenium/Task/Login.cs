using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using NUnit.Framework;
using System;
using BT_Selenium.Task;

namespace BT_Selenium.Task
{
    public class Login
    {
        public static void As(IWebDriver driver, string user)
        {
            DB.CambiarUsuario(user);

            if (driver != null)
            {
                Credenciales credenciales = new Credenciales();
                if (credenciales.usuario != "" && credenciales.password != "")
                {
                    Enter.Text(driver, LoginUI.UserInput, credenciales.usuario);
                    Click.Simple(driver, LoginUI.PasswordInput);
                    Enter.Text(driver, LoginUI.PasswordInput, credenciales.password);
                    Click.Simple(driver, LoginUI.LoginButton);
                    //WaitHandler.Wait(2);
                    //driver.SwitchTo().Window(driver.WindowHandles[1]);
                    //driver.Manage().Window.Maximize();
                }
                else
                {
                    if (driver != null)
                    {
                        driver.Quit();
                    }
                }
            }
        }

        public static void In(IWebDriver driver)
        {
            Credenciales credenciales = new Credenciales();
            if (credenciales.usuario != "" && credenciales.password != "")
            {
                Enter.Text(driver, LoginUI.UserInput, credenciales.usuario);
                Click.Simple(driver, LoginUI.PasswordInput);
                Enter.Text(driver, LoginUI.PasswordInput, credenciales.password);
                Click.Simple(driver, LoginUI.LoginButton);
               // WaitHandler.Wait(2);
                //try
                //{
                //    driver.SwitchTo().Window(driver.WindowHandles[1]);
                //    driver.Manage().Window.Maximize();
                //}
                //catch (Exception e)
                //{
                //    TestContext.Write(e);
                //    if (driver != null)
                //    {
                //        driver.Quit();
                //    }
                //}
            }
            else
            {
                TestContext.Write("No hay credenciales");
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
    }
}
