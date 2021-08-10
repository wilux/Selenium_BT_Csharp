using BT_Selenium.PageObject;
using BT_Selenium.Task;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT_Selenium.Handler;
using System.Data.SqlClient;
using System.Data;

namespace BT_Selenium.TestCase
{
   [TestFixture]
    public class DbTest
    {
     
   // [Test]
        public void Conectar()
        {

         DB.CambiarUsuario("pianciolag");

        }

    }
}
