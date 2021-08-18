using BT_Selenium.Tools;
using NUnit.Framework;


namespace BT_Selenium.TestCase
{
   [TestFixture]
    public class DbTest
    {
     
   // [Test]
        public void Conectar()
        {

            //DB.CambiarUsuario("pianciolag");
            string nroEntrevista = "980279";

            //Consultar DB 
            string consulta = $"select * from bnqfpa2 where BNQFPA2Nro='{nroEntrevista}'";
            //string estado =  DB.ObtenerValorCampo(consulta, "BNQFPA2ACD");
            //string mensaje = DB.ObtenerValorCampo(consulta, "BNQFPA2MCD");


        }

    }
}
