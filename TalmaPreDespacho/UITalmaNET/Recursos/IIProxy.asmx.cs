using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UITalmaNET.srvSeguridad;
using UITalmaNET.srvPreDespacho;

namespace UITalmaNET.Recursos
{
    /// <summary>
    /// Summary description for IIProxy1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IIProxy : System.Web.Services.WebService
    {

        [WebMethod()]
        public static string Valida_Usuario(string AL_USUA, string PW_USUA)
        {
            IsrvSeguridadClient oclient = IChannel.IChannelSeguridad();
            beUsuario be = oclient.Valida_Usuario(AL_USUA, PW_USUA);
            if (be.CO_USUA != "")
                return "true";
            else
                return "false";
        }

        [WebMethod()]
        public static List<bePreDespacho> GetPreDespachos(string ID_GUIA, string CO_USUA, string ST_PRE_DESPACHO, out beLogger logger)
        {
            List<bePreDespacho> ocol = new List<bePreDespacho>();
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            ocol = oclient.GetPreDespachos(out logger, ID_GUIA, CO_USUA, ST_PRE_DESPACHO);
            return ocol;
        }

        [WebMethod()]
        public static List<bePreFactura> GetPreFactura(string ID_GUIA, out beLogger logger)
        {
            List<bePreFactura> ocol = new List<bePreFactura>();
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            ocol = oclient.GetPreFactura(out logger, ID_GUIA);
            return ocol;
        }

        [WebMethod()]
        public static List<beGuia> GetGetGuia_Resumen(string ID_GUIA, out beLogger logger)
        {
            List<beGuia> ocol = new List<beGuia>();
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            ocol = oclient.GetGetGuia_Resumen(out logger, ID_GUIA);
            return ocol;
        }

        [WebMethod()]
        public static List<beTransaccion> GetTransacciones(string ID_GUIA, int ID_ARCH, out beLogger logger)
        {
            List<beTransaccion> ocol = new List<beTransaccion>();
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            ocol = oclient.GetTransacciones(out logger, ID_GUIA, ID_ARCH);
            return ocol;
        }

        [WebMethod()]
        public static List<bePreDespacho_Documento> GetPreDespacho_Documentos(string ID_GUIA, int ID_ARCH, out beLogger logger)
        {
            List<bePreDespacho_Documento> ocol = new List<bePreDespacho_Documento>();
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            ocol = oclient.GetPreDespacho_Documentos(out logger, ID_GUIA, ID_ARCH);
            return ocol;
        }


        [WebMethod()]
        public static bool SetGeneraPreDespacho(string ID_GUIA, string CO_USUA, DateTime? FE_RETI, out beLogger logger) 
        {
            bool result = false;
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            result = oclient.SetGeneraPreDespacho(out logger, ID_GUIA, CO_USUA, FE_RETI);
            return result;
        }

        [WebMethod()]
        public static bool SetGeneraPreFactura(string ID_GUIA, string CO_USUA, DateTime? FE_RETI, out beLogger logger)
        {
            bool result = false;
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            result = oclient.SetGeneraPreFactura(out logger, ID_GUIA, FE_RETI, CO_USUA);
            return result;
        }

        [WebMethod()]
        public static bool UpSert_Transaccion(beTransaccion VOUCHER, out beLogger logger) 
        {
            bool result = false;
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            result = oclient.UpSert_Transaccion(out logger, VOUCHER);
            return result;
        }

        [WebMethod()]
        public static bool UpSert_PreDespacho_Documento(bePreDespacho_Documento DOCU, out beLogger logger)
        {
            bool result = false;
            IsrvPreDespachoClient oclient = IChannel.IChannelPreDespacho();
            result = oclient.UpSert_PreDespacho_Documento(out logger, DOCU);
            return result;
        }
        
    }
}
