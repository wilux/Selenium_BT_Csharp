using BT_Selenium.Tools;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace BT_Selenium.Tools
{
    public class BridgerInsight
    {
        private static Random _random = new Random();
        public static void Consultar(string cuil, string usuario, int sucursal=26)
        {
            

            //Fecha BT
            string sql_FechaBT = "select Pgfape from fst017";
            string fechaBT = DB.ObtenerValorCampo(sql_FechaBT, "Pgfape");

            //Paso String a Date
            string format = "dd/MM/yyyy H:mm:ss";
            DateTime date = DateTime.ParseExact(fechaBT, format, CultureInfo.InvariantCulture);

            //Le agrego segundos aleatorios
            int num = _random.Next(10, 9000 );
            DateTime date2 = date.AddSeconds(num);

            //Inserto consulta falsa // Sumar tiempo (sacar hora real)
            string sql_InsertBridgerInsight = $"insert into BPNC37 select '{usuario}',{sucursal},11.10.6.116',{date2},penom,pendoc,'R','N' from fsd001 where pendoc = '{cuil}'";
            DB.ejecutarQuery(sql_InsertBridgerInsight);


        }
    }
}
