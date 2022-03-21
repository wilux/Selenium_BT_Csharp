using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;
using NUnit.Framework;
using System;
using BT_Selenium.Task;
using System.Threading;
using System.Drawing;

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

        public static void In(IWebDriver driver, bool full=true)
        {

            Credenciales credenciales = new Credenciales();
            if (credenciales.usuario != "" && credenciales.password != "")
            {
                driver.FindElement(LoginUI.UserInput).SendKeys(credenciales.usuario);
                driver.FindElement(LoginUI.UserInput).Click();

                driver.FindElement(LoginUI.PasswordInput).SendKeys(credenciales.password);
                driver.FindElement(LoginUI.LoginButton).Click();

                Thread.Sleep(200);
                if (driver.Url != "http://btwebqa.ar.bpn/BTWeb/hwelcome.aspx")
                {
                    Console.WriteLine("Credenciales Inválidas");
                }
                else
                {

                    if (WaitHandler.SwichToWindowsUrl(driver))
                    {
                        driver.Manage().Window.Maximize();
                    }

                    if (full == false)
                    {
                        driver.Manage().Window.Size = new Size(780, 920);
                    }
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
