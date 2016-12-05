using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EsquemaEntidades.PreDespacho;
using EsquemaEntidades.Log;
using LogicaNegocio.PreDespacho;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EsquemaEntidades.Perfiles;

namespace ComunicaServicioWCF.PreDespacho
{
    /// <summary>
    /// Summary description for srvPreDespacho
    /// </summary>
    [WebService(Namespace = "http://www.talmanet.com.pe/services/srvADUTalma/PreDespacho/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class srvPreDespacho : System.Web.Services.WebService
    {

        /*
        [WebMethod]
        public List<bePreDespacho> GetPreDespachos(string ID_GUIA, string CO_USUA, string ST_PRE_DESPACHO, out beLogger logger)
        {
            List<bePreDespacho> ocol = new List<bePreDespacho>();
            blPreDespacho bl = new blPreDespacho();
            ocol = bl.GetPreDespachos(ID_GUIA, CO_USUA, ST_PRE_DESPACHO, out logger);
            return ocol;
        }
         */

        [WebMethod]
        public bool SetGeneraPreDespacho(string ID_GUIA, string CO_USUA, DateTime? FE_RETI, out beLogger logger)
        {
            bool result;
            blPreDespacho bl = new blPreDespacho();
            result = bl.SetGeneraPreDespacho(ID_GUIA, CO_USUA, FE_RETI, out logger);
            return result;
        }
        /*
        [WebMethod]
        public List<bePreFactura> GetPreFactura(string ID_GUIA, out beLogger logger)
        {
            List<bePreFactura> ocol = new List<bePreFactura>();
            blPreFactura bl = new blPreFactura();
            ocol = bl.GetPreFactura(ID_GUIA, out logger);
            return ocol;
        }*/

        [WebMethod]
        public bool SetGeneraPreFactura(string ID_GUIA, DateTime? FE_SALI, string CO_USUA, out beLogger logger)
        {
            bool result;
            blPreFactura bl = new blPreFactura();
            result = bl.SetGeneraPreFactura(ID_GUIA, FE_SALI, CO_USUA, out logger);
            return result;
        }

        /*
        [WebMethod]
        public List<beGuia> GetGetGuia_Resumen(string ID_GUIA, out beLogger logger)
        {
            List<beGuia> ocol = new List<beGuia>();
            blGuia bl = new blGuia();
            ocol = bl.GetGetGuia_Resumen(ID_GUIA, out logger);
            return ocol;
        }*/

        [WebMethod]
        public List<beTransaccion> GetTransacciones(string ID_GUIA, int ID_ARCH, out beLogger logger)
        {
            List<beTransaccion> ocol = new List<beTransaccion>();
            blTransaccion bl = new blTransaccion();
            ocol = bl.GetTransacciones(ID_GUIA, ID_ARCH, out logger);
            return ocol;
        }

        [WebMethod]
        public bool UpSert_Transaccion(beTransaccion be, out beLogger logger)
        {
            bool result;
            blTransaccion bl = new blTransaccion();
            result = bl.UpSert_Transaccion(be, out logger);
            return result;
        }

        [WebMethod]
        public List<bePreDespacho_Documento> GetPreDespacho_Documentos(string ID_GUIA, int ID_ARCH, out beLogger logger)
        {
            List<bePreDespacho_Documento> ocol = new List<bePreDespacho_Documento>();
            blPreDespacho_Documento bl = new blPreDespacho_Documento();
            ocol = bl.GetPreDespacho_Documentos(ID_GUIA, ID_ARCH, out logger);
            return ocol;
        }

        [WebMethod]
        public bool UpSert_PreDespacho_Documento(bePreDespacho_Documento be, out beLogger logger)
        {
            bool result;
            blPreDespacho_Documento bl = new blPreDespacho_Documento();
            result = bl.UpSert_PreDespacho_Documento(be, out logger);
            return result;
        }

        //[WebMethod]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Valida_Usuario/{AL_USUA}/{PW_USUA}")]        
        [WebMethod]
        public beUsuario Valida_Usuario(string AL_USUA, string PW_USUA)
        {
            List<beUsuario> lista = new List<beUsuario>();
            beUsuario be;
            be = new beUsuario() { CO_USUA = "00000000000001", AL_USUA = "agrey", NO_USUA = "Allan Davis", AP_USUA = "Grey", AM_USUA = "Ferrari", PW_USUA = "12345678" };
            lista.Add(be);
            be = new beUsuario() { CO_USUA = "00000000000002", AL_USUA = "jjara", NO_USUA = "Julisa", AP_USUA = "Jara", AM_USUA = "Garro", PW_USUA = "02345678" };
            lista.Add(be);
            be = new beUsuario() { CO_USUA = "00000000000003", AL_USUA = "hvega", NO_USUA = "Hector", AP_USUA = "Vega", AM_USUA = "Gonzales", PW_USUA = "92345678" };
            lista.Add(be);

            be = new beUsuario();
            foreach (var o in lista.Where(o => o.AL_USUA == AL_USUA.ToLower() && o.PW_USUA == PW_USUA).ToList())
                be = o;

            return be;
        }

    }
}
