using BT_Selenium.Actions;
using BT_Selenium.UI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using BT_Selenium.Tools;
using BT_Selenium.Tasks;

namespace BT_Selenium.TestCase
{

    [TestFixture]
    public class BridgerInsightTest
    {   
        //Descomentar el que se usara

        //[TestCase("20303879618")]    --> Mas de uno
       // [TestCase] 
        public void RFXX()
        {
            BridgerInsight.Consultar("20258594593", "dechands");

        }

    }
}
