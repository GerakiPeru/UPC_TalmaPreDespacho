using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class bePreFactura
    {
        [DataMember]
        public string ID_GUIA { get; set; }
        [DataMember]
        public DateTime FE_EMISION { get; set; }
        [DataMember]
        public int NU_DIAS { get; set; }
        [DataMember]
        public double TI_CAMB { get; set; }
        [DataMember]
        public string CO_CLIE_FACT { get; set; }
        [DataMember]
        public string NO_CLIE_FACT { get; set; }
        [DataMember]
        public string DE_DIRE { get; set; }
        [DataMember]
        public double IM_VENT { get; set; }
        [DataMember]
        public double PC_DCTO { get; set; }
        [DataMember]
        public double IM_DCTO { get; set; }
        [DataMember]
        public double PC_IGVS { get; set; }
        [DataMember]
        public double IM_IGVS { get; set; }
        [DataMember]
        public double IM_TOTAL { get; set; }
        [DataMember]
        public double IM_TOTAL_DOL { get; set; }
        [DataMember]
        public string CO_USUA_CREA { get; set; }
        [DataMember]
        public DateTime FE_USUA_CREA { get; set; }
        [DataMember]
        public List<bePreFactura_Detalle> OB_DETALLE { get; set; }
    }
}