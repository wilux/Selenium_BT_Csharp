using BT_Selenium.Tools;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;

namespace BT_Selenium.Tools
{
    public class LegajoDigital
    {
        public static void Completar(string cuil)
        {

                string db_LegajoDigital = "LegajoDigital_QA";
                string db_Firma = "FirmaGrafometrica_QA";

                //Obtengo idPersona
                string sql_idPersona = $"select idPersona from PERSONA where CuitCuil = '{cuil}'";
                string idPersona = DB.ObtenerValorCampo(sql_idPersona, "idPersona", db_LegajoDigital);

                //Obtengo lista con idTramite
                string sql_idTramite = $"select idTramite from TRAMITE where idPersona = '{idPersona}' and estado = 1";
                IList idTramites = DB.ObtenerValoresColumna(sql_idTramite, "idTramite", db_LegajoDigital);
                List<string> ListaTramites = new List<string>();

                foreach (int tramite in idTramites)
                {
                ListaTramites.Add(tramite.ToString());
                }

                //Obtengo Tramites para una lista de idTramites
                string tramites = string.Join(",", ListaTramites);

                //Aprobar Tramites
                string sql_UpdateTramite = $"UPDATE Tramite set estado = 2 where  idTramite in ({tramites})";
                DB.ejecutarQuery(sql_UpdateTramite, db_LegajoDigital);

                //Aprobar Documentos
                string sql_updateVersionDocumento = $"update VERSIONDOCUMENTO set estado=2 where idVersionDocumento in (select idVersionDocumento from TRAMITEVERSIONDOCUMENTO where idTramite in ({tramites}))";
                DB.ejecutarQuery(sql_updateVersionDocumento, db_LegajoDigital);

                //FirmaDigital
                string sql_updateFirma = $"update Tramite set activo = 0 where CuitCuil = '{cuil}'";
                DB.ejecutarQuery(sql_updateFirma, db_Firma);


        }
    }
}
