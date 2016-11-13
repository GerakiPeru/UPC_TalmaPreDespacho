using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using UITalmaNET.srvSeguridad;
using UITalmaNET.Recursos;
using UITalmaNET.srvPreDespacho;
using System.Configuration;

namespace UITalmaNET.PreDespachos
{
    public partial class Tracking_Aduana : System.Web.UI.Page
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

                List<bePreDespacho_Documento> ocol = IIProxy.GetPreDespacho_Documentos(ID_GUIA, 0, out logger);
                documento.DataSource = ocol;
                documento.DataBind();   
            }
        }

        protected void documento_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //RadGrid1.DataSource = EFContext.Cars;
        }

        protected void documento_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                ImageButton imgVerDocumento = (ImageButton)item.FindControl("imgVerDocumento");
                string _base = ConfigurationManager.AppSettings["WEB_IMG_PREDES"].ToString();                 
                string RT_ARCH = string.Format(item["RT_ARCH_WEB"].Text.Trim(), _base);
                imgVerDocumento.OnClientClick = String.Format("window.open('{0}');",RT_ARCH);
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

            string ID_GUIA = Request.QueryString["ID_GUIA"].ToString();
            beUsuario User = (beUsuario)HttpContext.Current.Session[IChannel.UserCurrent];
            beLogger logger = new beLogger();
            bePreDespacho_Documento DOCU = new bePreDespacho_Documento();
            DOCU.BT_ARCH = input;
            List<string> file = uplvoucher.FileName.Split('.').ToList();
            DOCU.ID_GUIA = ID_GUIA;
            DOCU.OB_ARCH = "";
            DOCU.ST_ARCH = "";
            DOCU.CO_USUA_CREA = User.CO_USUA;
            DOCU.CO_USUA_MODI = User.CO_USUA;
            DOCU.EX_ARCH = file[file.Count - 1];
            DOCU.ST_ARCH = "ENV";
            bool result = IIProxy.UpSert_PreDespacho_Documento(DOCU, out logger);

            List<bePreDespacho_Documento> ocol = IIProxy.GetPreDespacho_Documentos(ID_GUIA, 0, out logger);
            documento.DataSource = ocol;
            documento.DataBind();   

            
        }
    }
}