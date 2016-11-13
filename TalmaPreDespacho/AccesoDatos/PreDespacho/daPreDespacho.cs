using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EsquemaEntidades.PreDespacho;
using AccesoDatos.Configuracion;
using System.Collections;

namespace AccesoDatos.PreDespacho
{
    public class daPreDespacho : DAO
    {
        public List<bePreDespacho> GetPreDespachos(string ID_GUIA, string CO_USUA, string ST_PRE_DESPACHO)
        {
            List<bePreDespacho> ocol = new List<bePreDespacho>();
            bePreDespacho oe;
            using (IDataReader dr = db.ExecuteReader("TLMTRADU.PKG_EPE_PREDESPACHO.USP_SEL_PRE_DESPACHO", ID_GUIA, CO_USUA, ST_PRE_DESPACHO, string.Empty))
            {
                while (dr.Read())
                {
                    oe = new bePreDespacho();
                    oe.ID_GUIA = dr["ID_GUIA"].ToString();
                    oe.NU_BULT_RECI = Convert.ToInt32(dr["NU_BULT_RECI"]);
                    oe.KG_RECI = Convert.ToDouble(dr["KG_RECI"]);
                    oe.NO_ENTI_CONC = dr["NO_ENTI_CONC"].ToString();                    

                    oe.ST_PRE_DESPACHO = dr["ST_PRE_DESPACHO"].ToString();  
                    oe.FE_INI_PRE_DESPACHO = dr["FE_INI_PRE_DESPACHO"].ToString() == string.Empty? oe.FE_INI_PRE_DESPACHO: Convert.ToDateTime(dr["FE_INI_PRE_DESPACHO"]);  
                    oe.FE_FIN_PRE_DESPACHO = dr["FE_FIN_PRE_DESPACHO"].ToString() == string.Empty? oe.FE_FIN_PRE_DESPACHO: Convert.ToDateTime(dr["FE_FIN_PRE_DESPACHO"]);

                    oe.ST_PREFACTURA = dr["ST_PREFACTURA"].ToString();   
                    oe.FE_INI_PREFACTURA = dr["FE_INI_PREFACTURA"].ToString() == string.Empty? oe.FE_INI_PREFACTURA: Convert.ToDateTime(dr["FE_INI_PREFACTURA"]);
                    oe.FE_FIN_PREFACTURA = dr["FE_FIN_PREFACTURA"].ToString() == string.Empty? oe.FE_FIN_PREFACTURA: Convert.ToDateTime(dr["FE_FIN_PREFACTURA"]);
                    oe.IM_DEBE = Convert.ToDouble(dr["IM_DEBE"]);
                    oe.IM_DEBE_DOL = Convert.ToDouble(dr["IM_DEBE_DOL"]);
                    oe.IM_DEPO = Convert.ToDouble(dr["IM_DEPO"]);
                    oe.IM_DEPO_DOL = Convert.ToDouble(dr["IM_DEPO_DOL"]);
                    oe.OB_PREFACTURA = dr["OB_PREFACTURA"].ToString();

                    oe.TI_AGENTE_ADUA = dr["TI_AGENTE_ADUA"].ToString();
                    oe.CO_SEMAFORO = dr["CO_SEMAFORO"].ToString();
                    oe.ST_SUNAT_LEVANTE = dr["ST_SUNAT_LEVANTE"].ToString();
                    oe.NU_CIF = Convert.ToDouble(dr["NU_CIF"]);
                    oe.NU_BULT_ADUA = Convert.ToInt32(dr["NU_BULT_ADUA"]);
                    oe.KG_ADUA = Convert.ToDouble(dr["KG_ADUA"]);
                    oe.NU_DUA_LEVANTE = dr["NU_DUA_LEVANTE"].ToString();
                    oe.TI_CONSIGNATARIO = dr["TI_CONSIGNATARIO"].ToString();
                    oe.CO_CONSIGNATARIO = dr["CO_CONSIGNATARIO"].ToString();
                    oe.ST_LEVANTE = dr["ST_LEVANTE"].ToString();
                    oe.FE_INI_LEVANTE = dr["FE_INI_LEVANTE"].ToString() == string.Empty? oe.FE_INI_PRE_DESPACHO: Convert.ToDateTime(dr["FE_INI_LEVANTE"]);
                    oe.FE_FIN_LEVANTE = dr["FE_FIN_LEVANTE"].ToString() == string.Empty? oe.FE_FIN_LEVANTE: Convert.ToDateTime(dr["FE_FIN_LEVANTE"]);
                    oe.OB_LEVANTE = dr["OB_LEVANTE"].ToString();

                    oe.ST_DOCU_ADUA = dr["ST_DOCU_ADUA"].ToString();
                    oe.FE_INI_DOCU_ADUA = dr["FE_INI_DOCU_ADUA"].ToString() == string.Empty? oe.FE_INI_DOCU_ADUA: Convert.ToDateTime(dr["FE_INI_DOCU_ADUA"]);
                    oe.FE_FIN_DOCU_ADUA = dr["FE_FIN_DOCU_ADUA"].ToString() == string.Empty? oe.FE_FIN_DOCU_ADUA: Convert.ToDateTime(dr["FE_FIN_DOCU_ADUA"]);
                    oe.OB_DOCU_ADUA = dr["OB_DOCU_ADUA"].ToString();

                    oe.CO_USUA_CREA = dr["CO_USUA_CREA"].ToString();
                    oe.FE_USUA_CREA = dr["FE_USUA_CREA"].ToString() == string.Empty? oe.FE_USUA_CREA: Convert.ToDateTime(dr["FE_USUA_CREA"]);
                    oe.CO_USUA_MODI = dr["CO_USUA_MODI"].ToString();
                    oe.FE_USUA_MODI = dr["FE_USUA_MODI"].ToString() == string.Empty? oe.FE_USUA_MODI: Convert.ToDateTime(dr["FE_USUA_MODI"]);
                    ocol.Add(oe);
                }
            }
            return ocol;
        }

        public QueueTransact SetGeneraPreDespacho(string ID_GUIA, string CO_USUA) 
        {
            ArrayList args = new ArrayList();
            args.Add(ID_GUIA);
            args.Add(CO_USUA);
            QueueTransact queue = new QueueTransact()
            {
                procedure = "TLMTRADU.PKG_EPE_PREDESPACHO.USP_GEN_PRE_DESPACHO",
                param = args
            };            
            return queue;
        }

        public QueueTransact SetCancelaPreDespacho(string ID_GUIA, string CO_USUA)
        {
            ArrayList args = new ArrayList();
            args.Add(ID_GUIA);
            args.Add(CO_USUA);
            QueueTransact queue = new QueueTransact()
            {
                procedure = "TLMTRADU.PKG_EPE_PREDESPACHO.USP_CAN_PRE_DESPACHO",
                param = args
            };
            return queue;
        }
    }
}
