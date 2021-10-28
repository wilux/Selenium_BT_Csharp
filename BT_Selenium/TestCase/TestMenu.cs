using NUnit.Framework;
using BT_Selenium.Task;
using OpenQA.Selenium;
using System;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class TestMenu : BaseTest
    {
      [Test]
        public void Ejecutar()
        {
            Login.In(driver);

            String currentURL = driver.Url;

            EjecutarPrograma.Ejecutar(driver, "hbnqfx23");

            Console.WriteLine(currentURL);
        }

    }
}
