using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UITalmaNET.srvSeguridad;
using UITalmaNET.srvPreDespacho;
using UITalmaNET.Recursos;

namespace UITalmaNET.PreDespachos
{
    public partial class Tracking_Levante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                beUsuario User = (beUsuario)HttpContext.Current.Session[IChannel.UserCurrent];
                string ID_GUIA = Request.QueryString["ID_GUIA"].ToString();
                beLogger logger = new beLogger();
                List<beGuia> ocolGuia = IIProxy.GetGetGuia_Resumen(ID_GUIA, out logger);
                foreach (beGuia be in ocolGuia)
                {
                    txtIdGuia.Text = be.ID_GUIA;
                    txtBultos.Text = be.NU_BULT_RECI.ToString("##0");
                    txtKilos.Text = be.KG_RECI.ToString("##0.00");

                    txtFechaVuelo.Text = be.FE_LLEG_VUEL.ToString("dd/MM/yyyy");
                    txtOrigen.Text = be.CO_CIUD_ORI;
                    txtDestino.Text = be.CO_CIUD_DES;

                    txtLineaAerea.Text = be.NO_ENTI_LINE;
                    txtVuelo.Text = be.NU_VUEL;

                    txtConsignatario.Text = be.NO_ENTI_CONC;
                    txtFechaIngreso.Text = be.FE_PRIMER_BULTO.ToString("dd/MM/yyyy");
                    txtAgenteCarga.Text = be.NO_ENTI_AGRE;

                }

            }
        }
    }
}