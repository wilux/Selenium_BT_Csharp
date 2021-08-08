using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BT_Selenium.Handler
{
    public static class DB
    {
        private static string _ConnectionString = null;
        static DB() // A static constructor to initialize the connection string
        {
            _ConnectionString = "Persist Security Info = False; Integrated Security = true; Initial Catalog = BPN_WEB_QA; Server = arcncd07";
            }
        public static DataSet ObtenerDatos(string sql)
        {
            var ds = new DataSet();
            //var sql = "select * from FST098 where Tpcod = 81100; ";
            using (var con = new SqlConnection(_ConnectionString))
            {
                using (var cmd = new SqlCommand(sql, con))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            
            return ds;
        }

        public static String  ObtenerCuit()
            {

            String Consulta = "select top 1 * from BNQFPBL where (BNQFPLMO1 +BNQFPLMO2+BNQFPLMO3 + BNQFPLMO4 + BNQFPLMO5 + BNQFPLMO6 + BNQFPLMO7 + BNQFPLMO8 + BNQFPLMO9 + BNQFPLMO10 + BNQFPLMO11 + BNQFPLMO12)*1000 >= 1500000000  order by newid()";

            DataSet datos = DB.ObtenerDatos(Consulta);
            string BNQFPBLDOC = "";

            foreach (DataRow dr in datos.Tables[0].Rows)
            {
                BNQFPBLDOC = dr["BNQFPBLDOC"].ToString();
                //Valores obtenidos

                //string tpnro = dr["tpnro"].ToString();
                //string indice = dr[0].ToString();

                Console.WriteLine(BNQFPBLDOC);

            }
            return BNQFPBLDOC;
        }


}
}
