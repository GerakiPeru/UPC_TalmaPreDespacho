using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class bePreDespacho
    {
        [DataMember]
        public string ID_GUIA { get; set; }
        [DataMember]
        public int NU_BULT_RECI { get; set; }
        [DataMember]
        public double KG_RECI { get; set; }
        [DataMember]
        public string NO_ENTI_CONC { get; set; }

        [DataMember]
        public string ST_PRE_DESPACHO { get; set; }
        [DataMember]
        public DateTime FE_INI_PRE_DESPACHO { get; set; }
        [DataMember]
        public DateTime FE_FIN_PRE_DESPACHO { get; set; }
        [DataMember]
        public string ST_PREFACTURA { get; set; }
        [DataMember]
        public DateTime FE_INI_PREFACTURA { get; set; }
        [DataMember]
        public DateTime FE_FIN_PREFACTURA { get; set; }
        [DataMember]
        public double IM_DEBE { get; set; }
        [DataMember]
        public double IM_DEBE_DOL { get; set; }
        [DataMember]
        public double IM_DEPO { get; set; }
        [DataMember]
        public double IM_DEPO_DOL { get; set; }
        [DataMember]
        public string OB_PREFACTURA { get; set; }
        [DataMember]
        public string TI_AGENTE_ADUA { get; set; }
        [DataMember]
        public string CO_AGENTE_ADUA { get; set; }
        [DataMember]
        public string CO_SEMAFORO { get; set; }
        [DataMember]
        public string ST_SUNAT_LEVANTE { get; set; }
        [DataMember]
        public double NU_CIF { get; set; }
        [DataMember]
        public int NU_BULT_ADUA { get; set; }
        [DataMember]
        public double KG_ADUA { get; set; }
        [DataMember]
        public string NU_DUA_LEVANTE { get; set; }
        [DataMember]
        public string TI_CONSIGNATARIO { get; set; }
        [DataMember]
        public string CO_CONSIGNATARIO { get; set; }
        [DataMember]
        public string ST_LEVANTE { get; set; }
        [DataMember]
        public DateTime FE_INI_LEVANTE { get; set; }
        [DataMember]
        public DateTime FE_FIN_LEVANTE { get; set; }
        [DataMember]
        public string OB_LEVANTE { get; set; }
        [DataMember]
        public string ST_DOCU_ADUA { get; set; }
        [DataMember]
        public DateTime FE_INI_DOCU_ADUA { get; set; }
        [DataMember]
        public DateTime FE_FIN_DOCU_ADUA { get; set; }
        [DataMember]
        public string OB_DOCU_ADUA { get; set; }
        [DataMember]      
        public string CO_USUA_CREA { get; set; }
        [DataMember]
        public DateTime FE_USUA_CREA { get; set; }
        [DataMember]
        public string CO_USUA_MODI { get; set; }
        [DataMember]
        public DateTime FE_USUA_MODI { get; set; }

    }
}
