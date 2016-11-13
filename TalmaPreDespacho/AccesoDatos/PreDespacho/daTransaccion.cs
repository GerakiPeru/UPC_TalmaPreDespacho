using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos.Configuracion;
using EsquemaEntidades.PreDespacho;
using System.Data;
using System.Collections;

namespace AccesoDatos.PreDespacho
{
    public class daTransaccion : DAO
    {
        public List<beTransaccion> GetTransacciones(string ID_GUIA, int ID_ARCH)
        {
            List<beTransaccion> ocol = new List<beTransaccion>();
            beTransaccion oe;
            using (IDataReader dr = db.ExecuteReader("TLMTRADU.PKG_EPE_PREDESPACHO.USP_SEL_TRANSAC_PREFACT", ID_GUIA, ID_ARCH, string.Empty))
            {
                while (dr.Read())
                {
                    oe = new beTransaccion();
                    oe.ID_GUIA = dr["ID_GUIA"].ToString();
                    oe.ID_ARCH = Convert.ToInt32(dr["ID_ARCH"]);
                    oe.EX_ARCH = dr["EX_ARCH"].ToString();
                    oe.FE_ARCH_UPLOAD = dr["FE_ARCH_UPLOAD"].ToString() == string.Empty ? oe.FE_ARCH_UPLOAD : Convert.ToDateTime(dr["FE_ARCH_UPLOAD"]);
                    oe.RT_ARCH_FILE = dr["RT_ARCH_FILE"].ToString();
                    oe.RT_ARCH_WEB = dr["RT_ARCH_WEB"].ToString();
                    oe.IM_ARCH = Convert.ToDouble(dr["IM_ARCH"]);
                    oe.ST_ARCH = dr["ST_ARCH"].ToString();
                    oe.OB_ARCH = dr["OB_ARCH"].ToString();
                    oe.CO_USUA_CREA = dr["CO_USUA_CREA"].ToString();
                    oe.FE_USUA_CREA = dr["FE_USUA_CREA"].ToString() == string.Empty ? oe.FE_USUA_CREA : Convert.ToDateTime(dr["FE_USUA_CREA"]);
                    oe.CO_USUA_MODI = dr["CO_USUA_MODI"].ToString();
                    oe.FE_USUA_MODI = dr["FE_USUA_MODI"].ToString() == string.Empty ? oe.FE_USUA_MODI : Convert.ToDateTime(dr["FE_USUA_MODI"]);
                    ocol.Add(oe);
                }
            }
            return ocol;
        }

        public QueueTransact UpSert_Transaccion(beTransaccion be)
        {
            ArrayList args = new ArrayList();
            args.Add(be.ID_GUIA);
            args.Add(be.ID_ARCH);
            args.Add(be.EX_ARCH);
            args.Add(be.FE_ARCH_UPLOAD);
            args.Add(be.RT_ARCH_FILE);
            args.Add(be.RT_ARCH_WEB);
            args.Add(be.IM_ARCH);
            args.Add(be.ST_ARCH);
            args.Add(be.OB_ARCH);
            args.Add(be.CO_USUA_MODI);
            QueueTransact queue = new QueueTransact()
            {
                procedure = "TLMTRADU.PKG_EPE_PREDESPACHO.USP_UPD_TRANSAC_PREFACT",
                param = args
            };
            return queue;
        }
    }
}
