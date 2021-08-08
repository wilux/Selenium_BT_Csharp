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
   //[TestFixture]
    public class DbTest
    {
     
    // [Test]
        public void Conectar()
        {

           String Consulta = "select top 1 * from BNQFPBL where (BNQFPLMO1 +BNQFPLMO2+BNQFPLMO3 + BNQFPLMO4 + BNQFPLMO5 + BNQFPLMO6 + BNQFPLMO7 + BNQFPLMO8 + BNQFPLMO9 + BNQFPLMO10 + BNQFPLMO11 + BNQFPLMO12)*1000 >= 1500000000  order by newid()";

            DataSet datos = DB.ObtenerDatos(Consulta);

            foreach (DataRow dr in datos.Tables[0].Rows)
            {
         
                //Valores obtenidos
                string BNQFPBLDOC = dr["BNQFPBLDOC"].ToString();
                //string tpnro = dr["tpnro"].ToString();
                //string indice = dr[0].ToString();

                Console.WriteLine(BNQFPBLDOC);

            }
        }

    }
}
