using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BT_Selenium.Tools
{
    //Clase que realiza la conexion con la Base de Dato. 
    //Contiene metodos para insertar y obtener datos de la misma.
    public static class DB
    {
        //private static string _ConnectionString = null;
        static DB() // A static constructor to initialize the connection string
        {
            //_ConnectionString = "Persist Security Info = False; Integrated Security = true; Initial Catalog = BPN_WEB_QA; Server = arcncd07";
        }

        public static void ejecutarQuery(string sql, string db = "BPN_WEB_QA")
        {
            string Connection = $"Persist Security Info = False; Integrated Security = true; Initial Catalog = {db}; Server = arcncd07";
           // string connectionString = _ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);
            string query = sql;
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Close();
            }
            catch { }

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Se insertartó correctamente: "+ sql);
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
        public static DataSet ObtenerDatos(string sql, string db = "BPN_WEB_QA")
        {
            string Connection = $"Persist Security Info = False; Integrated Security = true; Initial Catalog = {db}; Server = arcncd07";
            var ds = new DataSet();
            //var sql = "select * from FST098 where Tpcod = 81100; ";
            using (var con = new SqlConnection(Connection))
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

        public static String ObtenerValorCampo(string sql, string fila, string db = "BPN_WEB_QA")
        {

            //Consultar DB 
            string consulta = sql;
            DataSet respuesta = DB.ObtenerDatos(consulta, db);
            string resultado = "";

            foreach (DataRow dr in respuesta.Tables[0].Rows)
            {
                fila = dr[$"{fila}"].ToString();
            }

            return resultado = fila;

        }

        public static IList ObtenerValoresColumna(string sql, object column, string db = "BPN_WEB_QA")
        {

            //Consultar DB 
            string consulta = sql;
            DataSet respuesta = DB.ObtenerDatos(consulta, db);
            IList<int> resultado = new List<int>();

            foreach (DataRow dr in respuesta.Tables[0].Rows)
            {
                resultado.Add((int)dr[$"{column}"]);
            }

            return (IList)resultado;

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
            Credenciales credenciales = new Credenciales();
            string sql = $"UPDATE J055XZ SET J055XZUsr='{usuario}' WHERE J055XZUad='{credenciales.usuario}'";
            ejecutarQuery(sql);


        }


    }
}
