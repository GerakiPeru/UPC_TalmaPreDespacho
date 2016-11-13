using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UITalmaNET.Recursos;
using UITalmaNET.srvSeguridad;
using UITalmaNET.srvPreDespacho;
using Telerik.Web.UI;
using System.Web.Services;

namespace UITalmaNET.PreDespachos
{
    public partial class Tracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                beUsuario User = (beUsuario)HttpContext.Current.Session[IChannel.UserCurrent];
                beLogger logger = new beLogger();
                List<bePreDespacho> ocol = IIProxy.GetPreDespachos("", User.CO_USUA, "", out logger);

                grid.DataSource = ocol;
                grid.DataBind();
            }
        }

        protected void btnBuscar_Click(Object sender, EventArgs e)
        {
            beUsuario User = (beUsuario)HttpContext.Current.Session[IChannel.UserCurrent];
            beLogger logger = new beLogger();
            List<bePreDespacho> ocol = IIProxy.GetPreDespachos(txtGuia.Text, User.CO_USUA, cboEstado.SelectedValue, out logger);

            grid.DataSource = ocol;
            grid.DataBind();
        }

        protected void btnGenerar_Click(Object sender, EventArgs e)
        {
            if (dtFechaRetiro.SelectedDate == null)
            {
                ScriptManager.RegisterStartupScript(btnBuscar, btnBuscar.GetType(), "OnShowMessage", string.Format("OnShowMessage('{0}');", "Por favor! ingrese la fecha de retiro"), true);
                return;
            }
            if (txtGuia.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(btnBuscar, btnBuscar.GetType(), "OnShowMessage", string.Format("OnShowMessage('{0}');", "Por favor! ingrese una guía"), true);
                return;
            }

 
            beUsuario User = (beUsuario)HttpContext.Current.Session[IChannel.UserCurrent];
            beLogger logger = new beLogger();
            bool result = IIProxy.SetGeneraPreDespacho(txtGuia.Text, User.CO_USUA, Convert.ToDateTime(dtFechaRetiro.SelectedDate), out logger);
            if (logger.Estado == EstadoLogger.OK)
            {
                List<bePreDespacho> ocol = IIProxy.GetPreDespachos(txtGuia.Text, User.CO_USUA, cboEstado.SelectedValue, out logger);
                grid.DataSource = ocol;
                grid.DataBind();
            }
            else 
            {
                ScriptManager.RegisterStartupScript(btnBuscar, btnBuscar.GetType(),
                    "OnShowMessage", string.Format("OnShowMessage('{0}');", logger.Mensaje), true);
            }
        }
       

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void grid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //RadGrid1.DataSource = EFContext.Cars;
        }

        protected void grid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                ImageButton imgVerPreFactura = (ImageButton)item.FindControl("imgVerPreFactura");
                ImageButton imgVerAduana = (ImageButton)item.FindControl("imgVerAduana");
                ImageButton imgVerLevante = (ImageButton)item.FindControl("imgVerLevante");

                string ID_GUIA = string.Format("{0}", item["ID_GUIA"].Text.Trim());

                string ctrl = "'" + btnBuscar.ClientID + "'";
                string sfun = "'control.click()'";
                string sscript;

                sscript = String.Format("Tracking_PreFactura.aspx?ID_GUIA={0}", ID_GUIA);
                imgVerPreFactura.OnClientClick = String.Format("openPopup('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}',{8});return false;", 
                    sscript, ctrl, "true", sfun, "1000", "350", "100", "30", "true");

                sscript = String.Format("Tracking_Aduana.aspx?ID_GUIA={0}", ID_GUIA);
                imgVerAduana.OnClientClick = String.Format("openPopup('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}',{8});return false;",
                    sscript, ctrl, "true", sfun, "1000", "350", "100", "30", "true");

                sscript = String.Format("Tracking_Levante.aspx?ID_GUIA={0}", ID_GUIA);
                imgVerLevante.OnClientClick = String.Format("openPopup('{0}',{1},{2},{3},'{4}','{5}','{6}','{7}',{8});return false;",
                    sscript, ctrl, "true", sfun, "1000", "350", "100", "30", "true");
            }
        }

    }
}