using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EsquemaEntidades.PreDespacho;
using System.Data;
using AccesoDatos.Configuracion;
using System.Collections;

namespace AccesoDatos.PreDespacho
{
    public class daPreFactura : DAO
    {

        public List<bePreFactura> GetPreFactura(string ID_GUIA)
        {
            List<bePreFactura> ocol = new List<bePreFactura>();
            bePreFactura oe;
            using (IDataReader dr = db.ExecuteReader("TLMTRADU.PKG_EPE_PREDESPACHO.USP_SEL_PRE_PREFACTURA", ID_GUIA, string.Empty))
            {
                while (dr.Read())
                {
                    oe = new bePreFactura();
                    oe.ID_GUIA = dr["ID_GUIA"].ToString();
                    oe.FE_EMISION = dr["FE_EMISION"].ToString() == string.Empty ? oe.FE_EMISION : Convert.ToDateTime(dr["FE_EMISION"]);
                    oe.NU_DIAS = Convert.ToInt32(dr["NU_DIAS"]);
                    oe.TI_CAMB = Convert.ToDouble(dr["TI_CAMB"]);
                    oe.CO_CLIE_FACT = dr["CO_CLIE_FACT"].ToString();
                    oe.NO_CLIE_FACT = dr["NO_CLIE_FACT"].ToString();
                    oe.DE_DIRE = dr["DE_DIRE"].ToString();
                    oe.IM_VENT = Convert.ToDouble(dr["IM_VENT"]);
                    oe.PC_DCTO = Convert.ToDouble(dr["PC_DCTO"]);
                    oe.IM_DCTO = Convert.ToDouble(dr["IM_DCTO"]);
                    oe.PC_IGVS = Convert.ToDouble(dr["PC_IGVS"]);
                    oe.IM_IGVS = Convert.ToDouble(dr["IM_IGVS"]);
                    oe.IM_TOTAL = Convert.ToDouble(dr["IM_TOTAL"]);
                    oe.IM_TOTAL_DOL = Convert.ToDouble(dr["IM_TOTAL_DOL"]);
                    oe.CO_USUA_CREA = dr["CO_USUA_CREA"].ToString();
                    oe.FE_USUA_CREA = dr["FE_USUA_CREA"].ToString() == string.Empty ? oe.FE_USUA_CREA : Convert.ToDateTime(dr["FE_USUA_CREA"]);
                    oe.OB_DETALLE = new daPreFactura_Detalle().GetPreFactura_Detalle(oe.ID_GUIA);
                    ocol.Add(oe);
                }
            }
            return ocol;
        }

        public QueueTransact SetGeneraPreFactura(string ID_GUIA, DateTime? FE_SALI, string CO_USUA)
        {
            ArrayList args = new ArrayList();
            args.Add(ID_GUIA);
            args.Add(FE_SALI);
            args.Add(CO_USUA);
            QueueTransact queue = new QueueTransact()
            {
                procedure = "TLMTRADU.PKG_EPE_PREDESPACHO.USP_GEN_PRE_FACTURA",
                param = args
            };
            return queue;
        }
    }
}
