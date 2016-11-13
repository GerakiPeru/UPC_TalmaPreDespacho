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
    public class daGuia : DAO
    {
        public List<beGuia> GetGuia_Resumen(string ID_GUIA)
        {
            List<beGuia> ocol = new List<beGuia>();
            beGuia oe;
            using (IDataReader dr = db.ExecuteReader("TLMTRADU.PKG_EPE_PREDESPACHO.USP_SEL_GUIA_ID", ID_GUIA, string.Empty))
            {
                while (dr.Read())
                {
                    oe = new beGuia();
                    oe.ID_GUIA = dr["ID_GUIA"].ToString();
                    oe.CO_ENTI_LINE = dr["CO_ENTI_LINE"].ToString();
                    oe.NO_ENTI_LINE = dr["NO_ENTI_LINE"].ToString();
                    oe.NU_VUEL = dr["NU_VUEL"].ToString();
                    oe.FE_LLEG_VUEL = dr["FE_LLEG_VUEL"].ToString() == string.Empty ? oe.FE_LLEG_VUEL : Convert.ToDateTime(dr["FE_LLEG_VUEL"]);
                    oe.NU_MANI_HER = dr["NU_MANI_HER"].ToString();
                    oe.NU_GUIA_MADR = dr["NU_GUIA_MADR"].ToString();
                    oe.NU_GUIA_HIJA = dr["NU_GUIA_HIJA"].ToString();
                    oe.NU_BULT_RECI = Convert.ToInt32(dr["NU_BULT_RECI"]);
                    oe.KG_RECI = Convert.ToDouble(dr["KG_RECI"]);
                    oe.DE_CONTENIDO = dr["DE_CONTENIDO"].ToString();
                    oe.CO_CIUD_ORI = dr["CO_CIUD_ORI"].ToString();
                    oe.CO_CIUD_DES = dr["CO_CIUD_DES"].ToString();
                    oe.NO_ENTI_CONC = dr["NO_ENTI_CONC"].ToString();
                    oe.NO_ENTI_AGRE = dr["NO_ENTI_AGRE"].ToString();
                    oe.FE_PRIMER_BULTO = dr["FE_PRIMER_BULTO"].ToString() == string.Empty ? oe.FE_PRIMER_BULTO : Convert.ToDateTime(dr["FE_PRIMER_BULTO"]);
                    ocol.Add(oe);
                }
            }
            return ocol;
        }

    }
}
