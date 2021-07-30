using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.PageObject
{
    /*
     * Clase para representar la pagina de Login
     */
   public class LoginPage : BasePage
    {


        //Localizadores
        protected By UserInput = By.Id("_USER");
        protected By PasswordInput = By.Id("_PASSWORD");
        protected By LoginButton = By.Id("BTNOPINICIARSESION");

        //Construtor que lanza una excpecion si la url no es la correcta.
        public LoginPage(IWebDriver Driver)
        {
            driver = Driver;
        }

        //Metodo para escribir Usuario
        public void EscribirUsuario(String usuario)
        {
            driver.FindElement(UserInput).SendKeys(usuario);
        }

        //Metodo para escribir Password
        public void EscribirPassword(String password)
        {
            driver.FindElement(PasswordInput).Click();
            driver.FindElement(PasswordInput).Clear();
            driver.FindElement(PasswordInput).SendKeys(password);
        }

        //Metodo para hacer click en el boton de Login
        public void ClickLoginButton()
        {
            driver.FindElement(LoginButton).Click();
        }

        //Metodo para loguearse. Retorna la pagina principal de BT.
        public PrincipalPage IngresarComo(string usuario, string password)
        {
            EscribirUsuario(usuario);
            EscribirPassword(password);
            ClickLoginButton();
            return new PrincipalPage(driver);
        }

        public PrincipalPage Ingresar()
        {
            EscribirUsuario("floresnes");
            EscribirPassword("Carme2022");
            ClickLoginButton();
            return new PrincipalPage(driver);
        }

    }
}
