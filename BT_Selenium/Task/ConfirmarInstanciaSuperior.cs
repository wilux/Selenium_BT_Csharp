using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using BT_Selenium.Task;
using OpenQA.Selenium.Interactions;

namespace BT_Selenium.TestCase
{

    public class ConfirmarInstanciaSuperior
    {

           public static void Gerente(IWebDriver driver, string documento, string usuario = "liriac")
        {
            LegajoDigital.Completar(documento);
            Login.As(driver, usuario);

            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);


            //bandeja
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Tomar(driver);


            //Gerente
            RevisionProductos.Observaciones(driver);
            RevisionProductos.Confirmar(driver);

        }

        public static void Creditos(IWebDriver driver, string documento, string usuario = "totij")
        {
            Login.As(driver, usuario);

            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);


            //bandeja
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Tomar(driver);

            RevisionProductos.Observaciones(driver);
            RevisionProductos.Confirmar(driver);
            RevisionProductos.PerfilRiesgo(driver);
            MatrizRiesgo.Si(driver);
            MatrizRiesgo.Confirmar(driver);
            MatrizRiesgo.Cerrar(driver);
            //En perfil riesgo aceptar y cerrar
            //Liquidar
            RevisionProductos.Liquidar(driver);
            Entrevista.Cerrar(driver);
           // RevisionProductos.Finalizar(driver);

        }
    }
}
