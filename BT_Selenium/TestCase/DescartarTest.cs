using BT_Selenium.PageObject;
using BT_Selenium.Task;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Selenium.TestCase
{
   [TestFixture]
    public class DescartarTest : BaseTest
    {


       // [Test]
        public void Descartar()
        {
            DescartarTareaTask descartarTareaTask = new DescartarTareaTask(driver);
            try
            {
                descartarTareaTask.Descartar();
            }
            catch { }
        }

    }
}
