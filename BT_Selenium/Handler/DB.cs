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

        public static void ejecutarQuery(string sql)
        {

            string connectionString = _ConnectionString;
            SqlConnection connection = new SqlConnection(@connectionString);
            string query = sql;
            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }

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

        public static String ObtenerValorCampo(string sql, string fila)
        {

            //Consultar DB 
            string consulta = sql;
            DataSet respuesta = DB.ObtenerDatos(consulta);
            string resultado = "";

            foreach (DataRow dr in respuesta.Tables[0].Rows)
            {
                fila = dr[$"{fila}"].ToString();
            }

            return resultado = fila;



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


        public static void CambiarUsuario(string usuario)
        {
            
            string sql = $"UPDATE J055XZ SET J055XZUsr='{usuario}' WHERE J055XZUad='floresnes'";
            ejecutarQuery(sql);


        }


    }
}
