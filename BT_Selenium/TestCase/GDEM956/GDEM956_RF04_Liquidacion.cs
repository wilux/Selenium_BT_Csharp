using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using BT_Selenium.Task;

namespace BT_Selenium.TestCase.GDEM956
{
    // Al momento de liquidar se vuelve a verificar estado 

    // Si condicion cambio y no puede se rechaza


    [TestFixture, Description("Liquida CA USD")]
    public class GDEM956_RF04_Liquidacion : BaseTest
    {
        [TestCase("27174708121")]
        [TestCase("23255760114")]
        public void Paquete(string documento)
        {

            LegajoDigital.Completar(documento);
            Login.As(driver, "liriac");

            //Menu
            Menu.Inicio(driver);
            Menu.WorkFlow(driver);
            Menu.BandejaTareas(driver);

            //Bandeja
            BandejaTareas.Filtrar(driver, documento);
            BandejaTareas.Seleccionar(driver);
            BandejaTareas.Tomar(driver);

            //Gerente
            RevisionProductos.Observaciones(driver);
            RevisionProductos.Confirmar(driver);
            Capturar.Pantalla(driver, "InstanciaSuperior", documento);


            
        }

       
    }

}
