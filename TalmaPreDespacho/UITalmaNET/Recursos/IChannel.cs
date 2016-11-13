using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UITalmaNET.srvSeguridad;
using UITalmaNET.srvPreDespacho;
using System.Configuration;

namespace UITalmaNET.Recursos
{
    public static class IChannel
    {
        public const string UserCurrent = "UserCurrent";        

        public static IsrvSeguridadClient IChannelSeguridad()
        {
            IsrvSeguridadClient channel;
            string endpoint = "BasicHttpBinding_IsrvSeguridad";
            channel = new IsrvSeguridadClient(endpoint, ConfigurationManager.AppSettings["Channel_seguridad"].ToString());
            return channel;
        }

        public static IsrvPreDespachoClient IChannelPreDespacho()
        {
            IsrvPreDespachoClient channel;
            string endpoint = "BasicHttpBinding_IsrvPreDespacho";
            channel = new IsrvPreDespachoClient(endpoint, ConfigurationManager.AppSettings["Channel_predesapcho"].ToString());
            return channel;
        }
    }
}