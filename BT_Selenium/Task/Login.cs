using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using NUnit.Framework;
using System;
using BT_Selenium.Task;
using System.Threading;

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
                    driver.FindElement(LoginUI.UserInput).SendKeys(credenciales.usuario);
                    driver.FindElement(LoginUI.UserInput).Click();

                    driver.FindElement(LoginUI.PasswordInput).SendKeys(credenciales.password);
                    driver.FindElement(LoginUI.LoginButton).Click();

                    if (WaitHandler.SwichToWindowsUrl(driver))
                    {
                        driver.Manage().Window.Maximize();
                    }
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
                driver.FindElement(LoginUI.UserInput).SendKeys(credenciales.usuario);
                driver.FindElement(LoginUI.UserInput).Click();

                driver.FindElement(LoginUI.PasswordInput).SendKeys(credenciales.password);
                driver.FindElement(LoginUI.LoginButton).Click();

                Thread.Sleep(200);
                Assert.That(driver.Url == "http://btwebqa.ar.bpn/BTWeb/hwelcome.aspx");

                if (WaitHandler.SwichToWindowsUrl(driver))
                {
                    driver.Manage().Window.Maximize();
                }

            }
            else
            {
                TestContext.Write("No hay credenciales");
                Assert.That(driver.Url == "http://btwebqa.ar.bpn/BTWeb/hwelcome.aspx");
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
    }
}
