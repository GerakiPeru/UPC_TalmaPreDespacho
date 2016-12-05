using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    public class bePreDespacho
    {

        public string ID_GUIA { get; set; }

        public int NU_BULT_RECI { get; set; }

        public double KG_RECI { get; set; }

        public string NO_ENTI_CONC { get; set; }


        public string ST_PRE_DESPACHO { get; set; }

        public DateTime FE_INI_PRE_DESPACHO { get; set; }

        public DateTime FE_FIN_PRE_DESPACHO { get; set; }

        public string ST_PREFACTURA { get; set; }

        public DateTime FE_INI_PREFACTURA { get; set; }

        public DateTime FE_FIN_PREFACTURA { get; set; }

        public double IM_DEBE { get; set; }

        public double IM_DEBE_DOL { get; set; }

        public double IM_DEPO { get; set; }

        public double IM_DEPO_DOL { get; set; }

        public string OB_PREFACTURA { get; set; }

        public string TI_AGENTE_ADUA { get; set; }

        public string CO_AGENTE_ADUA { get; set; }

        public string CO_SEMAFORO { get; set; }

        public string ST_SUNAT_LEVANTE { get; set; }

        public double NU_CIF { get; set; }

        public int NU_BULT_ADUA { get; set; }

        public double KG_ADUA { get; set; }

        public string NU_DUA_LEVANTE { get; set; }

        public string TI_CONSIGNATARIO { get; set; }

        public string CO_CONSIGNATARIO { get; set; }

        public string ST_LEVANTE { get; set; }

        public DateTime FE_INI_LEVANTE { get; set; }

        public DateTime FE_FIN_LEVANTE { get; set; }

        public string OB_LEVANTE { get; set; }

        public string ST_DOCU_ADUA { get; set; }

        public DateTime FE_INI_DOCU_ADUA { get; set; }

        public DateTime FE_FIN_DOCU_ADUA { get; set; }

        public string OB_DOCU_ADUA { get; set; }
      
        public string CO_USUA_CREA { get; set; }

        public DateTime FE_USUA_CREA { get; set; }

        public string CO_USUA_MODI { get; set; }

        public DateTime FE_USUA_MODI { get; set; }

    }
}
