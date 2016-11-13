using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace EsquemaEntidades.PreDespacho
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class bePreFactura_Detalle
    {
        [DataMember]
        public string ID_GUIA { get; set; }
        [DataMember]
        public string CO_CPTO { get; set; }
        [DataMember]
        public string DE_CPTO { get; set; }
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
        public string CO_USUA_CREA { get; set; }
        [DataMember]
        public DateTime FE_USUA_CREA { get; set; }
    }
}