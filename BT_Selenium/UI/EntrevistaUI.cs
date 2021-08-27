using BT_Selenium.Actions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BT_Selenium.UI
{
    //HBNQFCB8 Flujo de Entrevista
    public class EntrevistaUI
    {

        //Tramite
        public static By campoTramite = By.Id("span__BNQFPA2NRO");
        public static By inputTramite = By.Id("_BNQFPA2NRO");

        //Datos personales
        public static By inputApellido = By.Id("_BNQFPA2APE");
        public static By inputNombre = By.Id("_BNQFPA2NOM"); 
        public static By inputFechaNac = By.Id("_BNQFPA2FNA");
        public static By SelectCapacidadLegal = By.Id("_PFCAPL");
        public static By SelectSexo = By.Id("_BNQFPA2SEX");
        public static By SelectNacionalidad = By.Id("_PFPNAC");
        public static By SelectPaisCiudadania = By.Id("_PAIS");
        public static By SelectProvincia = By.Id("_SNGC11DPTO");
        public static By inputLocalidad = By.Id("_SNGC11PROV");//326 Neuquen
        public static By SelectOcupacion = By.Id("_SNGC60OCUP");
        public static By BTNOPDOMICILIOREAL = By.Id("BTNOPDOMICILIOREAL");
        public static By CampoDomicilio = By.Id("span__BNQFPA2DOM");
        public static By InputDomicilio = By.Id("_BNQFPA2DOM");
        public static By SelectTipo = By.Name("_BNQFPA2TDO");
        public static By InputDocumento = By.Id("_BNQFPA2NDO");
        public static By BTNOPVALIDAR = By.Id("BTNOPVALIDAR");
        public static By InputMail = By.Name("_BNQFPA2MAI");
        public static By NoMail = By.Name("_NOTIENEEMAIL");
        public static By SelectTelefono = By.Name("_BNQFPA2TT1");
        public static By SelectTelefono2 = By.Name("_BNQFPA2TT2");
        public static By SelectCodigoArea = By.Name("_CODIGODEAERAT1");
        public static By SelectCodigoArea2 = By.Name("_CODIGODEAERAT2");
        public static By InputTelefono = By.Name("_BNQFPA2TE1");
        public static By InputTelefono2 = By.Name("_BNQFPA2TE2");
        public static By GridCtaCredito = By.Id("GRIDACRED");

        public static By BTNOPCAMBIARCTA = By.Id("BTNOPCAMBIARCTA");
        public static By BTNOPELEGIRCTA = By.Id("BTNOPELEGIRCTA");
        public static By BTNOPCONFIRMAR = By.Id("BTNOPCONFIRMAR");
        public static By BTN_SI = By.Id("BTNCONFIRMATION");
        public static By BTN_NO = By.Id("BTNCANCELCONFIRMATION");
        public static By BTNOPCERRAR = By.Id("BTNOPCERRAR");

        //Datos del Negocio 
        public static By InputFechaNegocio = By.Name("_SNGC60FINI");
        public static By InputNombreEmpresa = By.Name("_SNGC60RZSO");
        public static By SelectSegmento = By.Name("_PJSEGMENTO");


        // Datos de la Empresa PJ
        public static By InputRazonSocial = By.Name("_PJRAZS");
        public static By InputNombreFantasial = By.Name("_SNGC11AUX");
        public static By SelectNaturalezaJuridica = By.Name("_NJCOD");
        public static By InputFechaConstitucion = By.Name("_PJFCON");
        public static By InputNroRegistro = By.Name("_SNGC70VAL");

        //Modelo de Riesgo
        public static By TexareaObsvaciones = By.Name("_BNQFPA2OBS");
        

        //MsgText
        public static By MsgText = By.ClassName("MsgText");

        //Cuenta Credito
        public static By tabla_HTMLTBLCAT245 = By.Id("HTMLTBLCAT245");
        public static By GRIDACRED = By.Id("GRIDACRED");
        public static By td = By.TagName("td");
        public static By CampoAcreditaBPN = By.Name("span__ACREDITAENBPN_0001");
        public static By PrimerFila = By.Name("span__BNQFPA4CTA_0001");
        //span__BNQFPA4CTA_0001
        //input hidden _ACREDITAENBPN_0001 SI o NO 
        //span__ACREDITAENBPN_0001
        //_BNQFPA4EST_0001

        //_BNQFPA2CTA
        public static By SelectCuentaBT = By.Name("_BNQFPA2CTA");
        public static By SelectSectorEmpleador = By.Name("_BNQFPA2ORD");
        public static By InputIngresosDepedencia = By.Name("_BNQFPA2IRD");
        public static By InputIngresosIndependiente = By.Name("_BNQFPA2IIN");
       

        public static By TipoPersona = By.Id("_PETIPO");

       
    }
}
