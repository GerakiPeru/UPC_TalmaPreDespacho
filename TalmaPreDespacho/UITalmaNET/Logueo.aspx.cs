using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using UITalmaNET.srvSeguridad;
using UITalmaNET.Recursos;

namespace UITalmaNET
{
    public partial class Logueo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod()]
        public static bool Valida_Usuario(string AL_USUA, string PW_USUA)
        {
            IsrvSeguridadClient oclient = IChannel.IChannelSeguridad();
            beUsuario be = oclient.Valida_Usuario(AL_USUA, PW_USUA);
            HttpContext.Current.Session[IChannel.UserCurrent] = be;
            if (be.CO_USUA != "")
                return true;
            else
                return false;
        }
    }
}