using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;
using BT_Selenium.Tools;

namespace BT_Selenium.Tasks
{
    public class Login
    {
        public static void As(IWebDriver driver, string user)
        {
            DB.CambiarUsuario(user);

            Credenciales credenciales = new Credenciales();
            if (credenciales.usuario != "" && credenciales.password != "")
            {
                Enter.Text(driver, LoginUI.UserInput, credenciales.usuario);
                Click.Simple(driver, LoginUI.PasswordInput);
                Enter.Text(driver, LoginUI.PasswordInput, credenciales.password);
                Click.Simple(driver, LoginUI.LoginButton);
            }
            else
            {
                if (driver != null)
                {
                    driver.Quit();
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
}
