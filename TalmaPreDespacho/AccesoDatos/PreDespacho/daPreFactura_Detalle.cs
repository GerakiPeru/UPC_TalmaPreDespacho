using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EsquemaEntidades.PreDespacho;
using System.Data;
using AccesoDatos.Configuracion;

namespace AccesoDatos.PreDespacho
{
    public class daPreFactura_Detalle : DAO 
    {
        public List<bePreFactura_Detalle> GetPreFactura_Detalle(string ID_GUIA)
        {
            List<bePreFactura_Detalle> ocol = new List<bePreFactura_Detalle>();
            bePreFactura_Detalle oe;
            using (IDataReader dr = db.ExecuteReader("TLMTRADU.PKG_EPE_PREDESPACHO.USP_SEL_PRE_PREFACTURA_DETA", ID_GUIA, string.Empty))
            {
                while (dr.Read())
                {
                    oe = new bePreFactura_Detalle();
                    oe.ID_GUIA = dr["ID_GUIA"].ToString();
                    oe.CO_CPTO = dr["CO_CPTO"].ToString();
                    oe.DE_CPTO = dr["DE_CPTO"].ToString();
                    oe.IM_VENT = Convert.ToDouble(dr["IM_VENT"]);
                    oe.PC_DCTO = Convert.ToDouble(dr["PC_DCTO"]);
                    oe.IM_DCTO = Convert.ToDouble(dr["IM_DCTO"]);
                    oe.PC_IGVS = Convert.ToDouble(dr["PC_IGVS"]);
                    oe.IM_IGVS = Convert.ToDouble(dr["IM_IGVS"]);
                    oe.CO_USUA_CREA = dr["CO_USUA_CREA"].ToString();
                    oe.FE_USUA_CREA = dr["FE_USUA_CREA"].ToString() == string.Empty ? oe.FE_USUA_CREA : Convert.ToDateTime(dr["FE_USUA_CREA"]);
                    ocol.Add(oe);
                }
            }
            return ocol;
        }
    }
}
