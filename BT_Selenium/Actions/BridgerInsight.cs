using BT_Selenium.Tools;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;

namespace BT_Selenium.Actions
{
    public class BridgerInsight
    {
        public static void Consultar(string cuil, string usuario, int sucursal=26)
        {
                string sql_InsertBridgerInsight = $"insert into BPNC37 select '{usuario}',{sucursal},'0.10.6.116',GETDATE(),penom,pendoc,'R','N' from fsd001 where pendoc = '{cuil}'";
                DB.ejecutarQuery(sql_InsertBridgerInsight);


        }
    }
}
