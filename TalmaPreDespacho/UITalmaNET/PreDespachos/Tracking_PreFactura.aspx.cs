using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using UITalmaNET.srvSeguridad;
using UITalmaNET.srvPreDespacho;
using UITalmaNET.Recursos;
using System.Configuration;

namespace UITalmaNET.PreDespachos
{
    public partial class Tracking_PreFactura : System.Web.UI.Page
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

                List<bePreFactura> ocolPreFactura = IIProxy.GetPreFactura(ID_GUIA, out logger);
                foreach (bePreFactura be in ocolPreFactura) 
                {
                    dtFechaRetiro.SelectedDate = be.FE_EMISION;
                    txtTotalDolares.Text = be.IM_TOTAL_DOL.ToString("##0.00");
                    txtTotalSoles.Text = be.IM_TOTAL.ToString("##0.00");
                    txtTotalIGV.Text = be.IM_IGVS.ToString("##0.00");
                    txtTotalVenta.Text = be.IM_VENT.ToString("##0.00");
                    txtDias.Text = be.NU_DIAS.ToString();
                    grid.DataSource = be.OB_DETALLE;
                    grid.DataBind();
                }

                List<beTransaccion> ocolTransaccion = IIProxy.GetTransacciones(ID_GUIA, 0, out logger);
                voucher.DataSource = ocolTransaccion;
                voucher.DataBind();
            }
        }

        protected void grid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //RadGrid1.DataSource = EFContext.Cars;
        }

        protected void grid_ItemDataBound(object sender, GridItemEventArgs e)
        {
 
        }

        protected void voucher_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //RadGrid1.DataSource = EFContext.Cars;
        }

        protected void voucher_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {

                GridDataItem item = (GridDataItem)e.Item;

                ImageButton imgVerVoucher = (ImageButton)item.FindControl("imgVerVoucher");
                string _base = ConfigurationManager.AppSettings["WEB_IMG_TRANS"].ToString();
                string RT_ARCH = string.Format(item["RT_ARCH_WEB"].Text.Trim(), _base);
                imgVerVoucher.OnClientClick = String.Format("window.open('{0}');", RT_ARCH);

            }
        }

        protected void btnAdjuntar_Click(Object sender, EventArgs e)
        {
            byte[] input = null;
            if (uplvoucher.HasFile)
            {
                int fileLen = uplvoucher.PostedFile.ContentLength;
                input = new byte[fileLen - 1];
                input = uplvoucher.FileBytes;
            }
            else 
            {
                ScriptManager.RegisterStartupScript(btnAdjuntar, btnAdjuntar.GetType(), "OnShowMessage", string.Format("OnShowMessage('{0}');", "Ud no ha adjuntado ningun voucher"), true);
                return;
            }
            if (txtImporteVoucher.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(btnAdjuntar, btnAdjuntar.GetType(), "OnShowMessage", string.Format("OnShowMessage('{0}');", "Por favor! asegurese de ingresar el monto del Voucher"), true);
                return;
            }
            if(Convert.ToDouble(txtImporteVoucher.Text) == 0) 
            {
                ScriptManager.RegisterStartupScript(btnAdjuntar, btnAdjuntar.GetType(), "OnShowMessage", string.Format("OnShowMessage('{0}');", "Por favor! asegurese de ingresar el monto mayor a cero"), true);
                return;
            }

            double importe = 0;
            foreach (GridDataItem item in voucher.Items) 
            {
                importe = importe + Convert.ToDouble(item["IM_ARCH"].Text);
            }
            if (Convert.ToDouble(txtTotalSoles.Text) < (importe + Convert.ToDouble(txtImporteVoucher.Text)))
            {
                ScriptManager.RegisterStartupScript(btnAdjuntar, btnAdjuntar.GetType(), "OnShowMessage", string.Format("OnShowMessage('{0}');", "Ud. esta realizando depositos que sobrepasan el total"), true);
                return;
            }

            string ID_GUIA = Request.QueryString["ID_GUIA"].ToString();
            beUsuario User = (beUsuario)HttpContext.Current.Session[IChannel.UserCurrent];
            beLogger logger = new beLogger();
            beTransaccion VOUCHER = new beTransaccion();
            VOUCHER.BT_ARCH = input;
            List<string> file = uplvoucher.FileName.Split('.').ToList();
            VOUCHER.ID_GUIA = ID_GUIA;
            VOUCHER.IM_ARCH = Convert.ToDouble(txtImporteVoucher.Text);
            VOUCHER.OB_ARCH = "";
            VOUCHER.ST_ARCH = "";
            VOUCHER.CO_USUA_CREA = User.CO_USUA;
            VOUCHER.CO_USUA_MODI = User.CO_USUA;
            VOUCHER.EX_ARCH = file[file.Count - 1];
            VOUCHER.ST_ARCH = "ENV";
            bool result = IIProxy.UpSert_Transaccion(VOUCHER, out logger);

            txtImporteVoucher.Text = "";
            List<beTransaccion> ocolTransaccion = IIProxy.GetTransacciones(ID_GUIA, 0, out logger);
            voucher.DataSource = ocolTransaccion;
            voucher.DataBind();

            
        }

        protected void dtFechaRetiro_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            beUsuario User = (beUsuario)HttpContext.Current.Session[IChannel.UserCurrent];
            string ID_GUIA = Request.QueryString["ID_GUIA"].ToString();
            beLogger logger = new beLogger();
            bool result = IIProxy.SetGeneraPreFactura(ID_GUIA, User.CO_USUA, Convert.ToDateTime(dtFechaRetiro.SelectedDate), out logger);
            if (logger.Estado == EstadoLogger.OK)
            {

                List<bePreFactura> ocolPreFactura = IIProxy.GetPreFactura(ID_GUIA, out logger);
                foreach (bePreFactura be in ocolPreFactura)
                {
                    dtFechaRetiro.SelectedDate = be.FE_EMISION;
                    txtTotalDolares.Text = be.IM_TOTAL_DOL.ToString("##0.00");
                    txtTotalSoles.Text = be.IM_TOTAL.ToString("##0.00");
                    txtTotalIGV.Text = be.IM_IGVS.ToString("##0.00");
                    txtTotalVenta.Text = be.IM_VENT.ToString("##0.00");
                    txtDias.Text = be.NU_DIAS.ToString();
                    grid.DataSource = be.OB_DETALLE;
                    grid.DataBind();
                }

                List<beTransaccion> ocolTransaccion = IIProxy.GetTransacciones(ID_GUIA, 0, out logger);
                voucher.DataSource = ocolTransaccion;
                voucher.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(btnAdjuntar, btnAdjuntar.GetType(),
                    "OnShowMessage", string.Format("OnShowMessage('{0}');", logger.Mensaje), true);
            }
        }
    }
}