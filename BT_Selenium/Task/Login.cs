using OpenQA.Selenium;
using BT_Selenium.Actions;
using BT_Selenium.UI;

namespace BT_Selenium.Tasks
{
    public class Login
    {
        public static void As(IWebDriver driver, string user, string passWord)
        {
            Credenciales credenciales = new Credenciales();
            Enter.Text(driver, LoginUI.UserInput, user);
            Enter.Text(driver, LoginUI.PasswordInput, passWord);
            Click.On(driver, LoginUI.LoginButton);
        }

        public static void In(IWebDriver driver)
        {
            Credenciales credenciales = new Credenciales();
            Enter.Text(driver, LoginUI.UserInput, credenciales.usuario);
            Enter.Text(driver, LoginUI.PasswordInput, credenciales.password);
            Click.On(driver, LoginUI.LoginButton);
        }
    }
}
