using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using NUnit.Framework;
using System;

namespace BT_Selenium.Tasks
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
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                    driver.Manage().Window.Maximize();
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
                //Prueba para error aleatorio de incio
                WaitHandler.Wait(driver, 3);
                try
                {
                    driver.SwitchTo().Window(driver.WindowHandles[1]);
                }
                catch (Exception e)
                {
                    TestContext.Write(e);
                    driver.Close();
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    driver.Navigate().Refresh();
                    In(driver);
                }
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
